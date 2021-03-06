﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bottomText;
    [SerializeField] private GameObject sideText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spriteObject;
    [SerializeField] private MapInitialization mapInitializer;
    [SerializeField] private GameObject casque;
    [SerializeField] private GameObject chaussures;
    [SerializeField] private GameObject haut;
    [SerializeField] private GameObject armes;
    [SerializeField] private GameObject bourse;
    [SerializeField] private GameObject infos;

    private bool canTurn = true;
    public enum Step { ConstructingMap, Travelling, Selling, CalculatingPoints };
    public Step gameStep;

    int ones = 0;
    int twos = 0;
    int threes = 0;
    int fours = 0;
    int fives = 0;
    int carreaux = 0;
    int piques = 0;
    int trefles = 0;
    int coeurs = 0;

    //Database
    private Stuff[] listStuff;
    private City[] listCity;
    private int gold;
    private City currentCity;
    //UI
    [SerializeField] private Text goldText;

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    
        gameStep = Step.ConstructingMap;
        gameStep = Step.Travelling;
        infos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStep == Step.Travelling && canTurn)
        {
            if (player.transform.rotation.eulerAngles.y > 80 && player.transform.rotation.eulerAngles.y < 100 || Input.GetKeyDown("r"))
            {
                mapInitializer.TurnRight();
                canTurn = false;
            }
            else if (player.transform.rotation.eulerAngles.y < 280 && player.transform.rotation.eulerAngles.y > 260 || Input.GetKeyDown("l"))
            {
                mapInitializer.TurnLeft();
                canTurn = false;
            }
        }
        else if (gameStep == Step.CalculatingPoints)
        {
            EndGameScore();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetSideText(string text)
    {
        sideText.GetComponent<TextMesh>().text = text;
    }

    public void SetBottomText(string text)
    {
        bottomText.GetComponent<TextMesh>().text = text;
    }

    public void ChangeBottomTextPosition(Vector3 position)
    {
        bottomText.transform.position = position;
    }

    public void ChangeSideTextPosition(Vector3 position)
    {
        sideText.transform.position = position;
    }

    public void SetSpriteObject(Sprite sprite)
    {
        spriteObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void ChangeSpriteObjectPosition(Vector3 position)
    {
        spriteObject.transform.position = position;
    }

    public void SellStuff(Stuff currentStuff)
    {
        gold += (currentStuff.Price * mapInitializer.getCurCity().GetTypePercentage(currentStuff.MyType.ToString()) / 100);

        goldText.text = gold.ToString();
    }

    public void EstimateStuffPrice(Stuff currentStuff)
    {
        float estimatedPrice = currentStuff.Price * mapInitializer.getCurCity().GetTypePercentage(currentStuff.MyType.ToString()) / 100;
        bourse.SetActive(true);
        bourse.transform.GetChild(1).GetComponent<Text>().text = estimatedPrice.ToString() + "G";
    }

    public void ChangeBoursePosition(Vector3 position)
    {
        bourse.transform.position = position;
    }

    public void HideBourse()
    {
        bourse.SetActive(false);
    }

    public void MapComplete()
    {
        gameStep = Step.Travelling;
        infos.SetActive(true);
        Debug.Log("MapComplete");
    }

    public void CharacterFace()
    {
        Debug.Log("coclco");
        if (gameStep == Step.Travelling)
        {
            Debug.Log(mapInitializer.CurrentLevel);
            if (mapInitializer.CurrentLevel <6)
            {
                mapInitializer.gameObject.SetActive(false);
                gameStep = Step.Selling;
                canTurn = true;
            }
        }
        if (mapInitializer.CurrentLevel == 6)
        {
            Debug.Log("Score");
            gameStep = Step.CalculatingPoints;
        }
    }

    public void CharacterBack()
    {
        if (gameStep == Step.Selling)
        {
            if(mapInitializer.CurrentLevel == 5)
            {
                mapInitializer.CurrentLevel++;
                currentCity = new City("End", null, 100, 100, 100, 100);
                Debug.Log("EndGame " + mapInitializer.CurrentLevel);
            }
            else if(mapInitializer.CurrentLevel < 6)
            {
                mapInitializer.gameObject.SetActive(true);
                gameStep = Step.Travelling;
            }
            Debug.Log("Travelling");
        }
    }

    public void EndGameScore()
    {

        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        // Iterate through the list of active trackables
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Stuff savedStuff = tb.transform.GetComponent<Stuff>();
            if (savedStuff != null && savedStuff.state != Stuff.State.Counted) {
                savedStuff.state = Stuff.State.Counted;
                gold += savedStuff.Price;
                goldText.text = gold.ToString();
                //Check number
                if (savedStuff.Number == 1)
                {
                    ones++;
                }
                else if (savedStuff.Number == 2)
                {
                    twos++;
                }
                else if (savedStuff.Number == 3)
                {
                    threes++;
                }
                else if (savedStuff.Number == 4)
                {
                    fours++;
                }
                else if (savedStuff.Number == 5)
                {
                    fives++;
                }
                //Check Figure
                if (savedStuff.MyType == Stuff.StuffType.Casque)
                {
                    carreaux++;
                }
                else if (savedStuff.MyType == Stuff.StuffType.Chaussures)
                {
                    trefles++;
                }
                else if (savedStuff.MyType == Stuff.StuffType.Haut)
                {
                    coeurs++;
                }
                else if (savedStuff.MyType == Stuff.StuffType.Arme)
                {
                    piques++;
                }

                if (ones == 4)
                {
                    ones++;
                    gold += 250;
                    goldText.text = gold.ToString();
                }
                if (twos == 4)
                {
                    twos++;
                    gold += 225;
                    goldText.text = gold.ToString();
                }
                if (threes == 4)
                {
                    threes++;
                    gold += 200;
                    goldText.text = gold.ToString();
                }
                if (fours == 4)
                {
                    fours++;
                    gold += 175;
                    goldText.text = gold.ToString();
                }
                if (fives == 4)
                {
                    fives++;
                    gold += 150;
                    goldText.text = gold.ToString();
                }

                if (carreaux == 5)
                {
                    carreaux++;
                    gold += 250;
                    goldText.text = gold.ToString();
                }
                if (coeurs == 5)
                {
                    coeurs++;
                    gold += 250;
                    goldText.text = gold.ToString();
                }
                if (piques == 5)
                {
                    piques++;
                    gold += 250;
                    goldText.text = gold.ToString();
                }
                if (trefles == 5)
                {
                    trefles++;
                    gold += 250;
                    goldText.text = gold.ToString();
                }
            }
        }
    }
}
