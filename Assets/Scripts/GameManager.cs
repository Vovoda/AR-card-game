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
    [SerializeField] private GameObject casque;
    [SerializeField] private GameObject chaussures;
    [SerializeField] private GameObject haut;
    [SerializeField] private GameObject armes;

    //Database

    private Stuff[] listStuff;
    private City[] listCity;

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

    }

    // Update is called once per frame
    void Update()
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
}
