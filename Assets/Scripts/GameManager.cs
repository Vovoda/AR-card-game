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
    private enum State { ConstructingMap, Travelling, Selling, CalculatingPoints};
    private State gameStep;

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
        gameStep = State.ConstructingMap;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStep == State.Travelling)
        {
            if (player.transform.rotation.eulerAngles.y > 60 && player.transform.rotation.eulerAngles.y < 120)
            {
                Debug.Log("Gauche");
            }
            else if (player.transform.rotation.eulerAngles.y < 300 && player.transform.rotation.eulerAngles.y > 240)
            {
                Debug.Log("Droite");
            }
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
    public void InitData()
    {
        listStuff[0] = new Stuff(Stuff.StuffType.Casque, 1, 100);
        listStuff[1] = new Stuff(Stuff.StuffType.Casque, 2, 200);
        listStuff[2] = new Stuff(Stuff.StuffType.Casque, 3, 300);
        listStuff[3] = new Stuff(Stuff.StuffType.Casque, 4, 400);
        listStuff[4] = new Stuff(Stuff.StuffType.Casque, 5, 500);
        listStuff[5] = new Stuff(Stuff.StuffType.Chaussures, 1, 100);
        listStuff[6] = new Stuff(Stuff.StuffType.Chaussures, 2, 200);
        listStuff[7] = new Stuff(Stuff.StuffType.Chaussures, 3, 300);
        listStuff[8] = new Stuff(Stuff.StuffType.Chaussures, 4, 400);
        listStuff[9] = new Stuff(Stuff.StuffType.Chaussures, 5, 500);
        listStuff[10] = new Stuff(Stuff.StuffType.Haut, 1, 100);
        listStuff[11] = new Stuff(Stuff.StuffType.Haut, 2, 200);
        listStuff[12] = new Stuff(Stuff.StuffType.Haut, 3, 300);
        listStuff[13] = new Stuff(Stuff.StuffType.Haut, 4, 400);
        listStuff[14] = new Stuff(Stuff.StuffType.Haut, 5, 500);
        listStuff[15] = new Stuff(Stuff.StuffType.Arme, 1, 100);
        listStuff[16] = new Stuff(Stuff.StuffType.Arme, 2, 200);
        listStuff[17] = new Stuff(Stuff.StuffType.Arme, 3, 300);
        listStuff[18] = new Stuff(Stuff.StuffType.Arme, 4, 400);
        listStuff[19] = new Stuff(Stuff.StuffType.Arme, 5, 500);
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
        gameStep = State.Travelling;
        Debug.Log("MapComplete");
    }
}
