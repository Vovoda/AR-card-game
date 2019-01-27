using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityUIManager : MonoBehaviour
{
    public Text valueCarreau;
    public Text valuePique;
    public Text valueTrefle;
    public Text valueCoeur;

    public Image selected;
    // Start is called before the first frame update
    void Start()
    {
        /*List<List<int>> truc = new List<List<int>>();
        int a = 3;
        List<int> truc2 = new List<int>();
        List<int> truc3 = new List<int>();

        truc2.Add(a);
        truc.Add(truc2);
        a = 4;
        Debug.Log(truc[0][0]);

        truc2.Add(7);
        Debug.Log(truc[0][0]);
        Debug.Log(truc[0][1]);*/

        List<List<City>> hola = new List<List<City>>();
        //hola = MapInitialization.FillCityList(2, 14, 5, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateValueCarreau(int _value)
    {
        valueCarreau.text = _value + " ♦";
    }
    public void UpdateValuePique(int _value)
    {
        valuePique.text = _value + " ♠";
    }
    public void UpdateValueTrefle(int _value)
    {
        valueTrefle.text = _value + " ♣";
    }
    public void UpdateValueCoeur(int _value)
    {
        valueCoeur.text = _value + " ♥";
    }

    public void SetSelected(bool set)
    {
        if (set)
        {
            selected.enabled = true;
        } else
        {
            selected.enabled = false;
        }
    }
}
