using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Card
{
    [SerializeField] private string cityEffect;
    [SerializeField] private int helmetPercentage, topPercentage,bottomPercentage, weaponPercentage;
    private City leftCity;
    private City rightCity;

    public City LeftCity { get => leftCity; set => leftCity = value; }
    public City RightCity { get => rightCity; set => rightCity = value; }

    public City(string newName, string newEffect)
    {
        CardName = newName;
        cityEffect = newEffect;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
