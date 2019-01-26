using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bottomText;
    [SerializeField] private GameObject sideText;

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
        
    }

    public void StuffAppear(Stuff stuff)
    {
        ChangeBottomTextPosition(new Vector3(stuff.transform.position.x, stuff.transform.position.y - 0.5f, stuff.transform.position.z));
        ChangeSideTextPosition(new Vector3(stuff.transform.position.x+0.5f, stuff.transform.position.y, stuff.transform.position.z));
        stuff.CheckSell();
        stuff.CheckSell();
        stuff.DisplayCharacterictics();
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
}
