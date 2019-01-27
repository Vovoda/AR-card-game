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

    public City(string newName, string newEffect, int newHelmet, int newTop, int newBottom, int newWeapon)
    {
        CardName = newName;
        cityEffect = newEffect;
        helmetPercentage = newHelmet;
        topPercentage = newTop;
        bottomPercentage = newBottom;
        weaponPercentage = newWeapon;
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
