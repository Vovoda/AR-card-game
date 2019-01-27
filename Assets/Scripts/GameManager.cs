using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool canTurn = true;
    public enum Step { ConstructingMap, Travelling, Selling, CalculatingPoints};
    public Step gameStep;

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
        currentCity = new City("test", "voila", 50, 50, 50, 50);
        gameStep = Step.ConstructingMap;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStep == Step.Travelling && canTurn)
        {
            if (player.transform.rotation.eulerAngles.y > 80 && player.transform.rotation.eulerAngles.y < 100 && Input.GetKeyDown("r"))
            {
                mapInitializer.TurnRight();
                canTurn = false;
            }
            else if (player.transform.rotation.eulerAngles.y < 280 && player.transform.rotation.eulerAngles.y > 260 && && Input.GetKeyDown("l"))
            {
                mapInitializer.TurnLeft();
                canTurn = false;
            }
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
        gold += (currentStuff.Price * currentCity.GetTypePercentage(currentStuff.MyType.ToString()) / 100);

        goldText.text = gold.ToString();
    }

    public void EstimateStuffPrice(Stuff currentStuff)
    {
        float estimatedPrice = currentStuff.Price * currentCity.GetTypePercentage(currentStuff.MyType.ToString()) / 100;
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
        Debug.Log("MapComplete");
    }

    public void CharacterFace()
    {
        if(gameStep == Step.Travelling)
        {
            mapInitializer.gameObject.SetActive(false);
            gameStep = Step.Selling;
            Debug.Log("Selling");
            canTurn = true;
        }
    }

    public void CharacterBack()
    {
        if (gameStep == Step.Selling)
        {
            mapInitializer.gameObject.SetActive(true);
            gameStep = Step.Travelling;
            Debug.Log("Travelling");
        }
    }
}
