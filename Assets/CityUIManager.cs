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
    // Start is called before the first frame update
    void Start()
    {
        
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
}
