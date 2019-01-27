﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{
    [SerializeField] private string cityEffect;
    [SerializeField] private int helmetPercentage, topPercentage,bottomPercentage, weaponPercentage;
    private CityUIManager cityUI;
    private City leftCity;
    private City rightCity;

    private string cardName;

    public CityUIManager CityUI { get => cityUI; set => cityUI = value; }
    public City LeftCity { get => leftCity; set => leftCity = value; }
    public City RightCity { get => rightCity; set => rightCity = value; }

    public City(string newName, string newEffect, int newHelmet, int newTop, int newBottom, int newWeapon)
    {
        cardName = newName;
        cityEffect = newEffect;
        helmetPercentage = newHelmet;
        topPercentage = newTop;
        bottomPercentage = newBottom;
        weaponPercentage = newWeapon;
    }

    public int GetTypePercentage(string stuff)
    {
        if(stuff == "Casque")
        {
            return helmetPercentage;
        }
        else if(stuff == "Chaussures")
        {
            return topPercentage;
        }
        else if(stuff == "Haut")
        {
            return bottomPercentage;
        }
        else if(stuff == "Arme")
        {
            return weaponPercentage;
        } else
        {
            return -1;
        }
    }

}
