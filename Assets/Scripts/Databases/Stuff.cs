using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuff : Card
{
    public enum StuffType {Casque, Chaussures, Haut, Arme};
    [SerializeField] StuffType myType;
    [SerializeField] private int number;
    [SerializeField] private int price;

    public Stuff(StuffType newType, int newNumber, int newPrice)
    {
        myType = newType;
        number = newNumber;
        price = newPrice;
    }

    public void DisplayCharacterictics()
    {
        string textToDisplay = CardName + "\n " + myType.ToString() + "\n" + price + " G";
        GameManager.instance.SetSideText(textToDisplay);
    }

    public void CheckSell()
    {
        if (this.transform.position.y < -0f)
        {
            GameManager.instance.SetBottomText("Vendu");
        }
        else
        {
            GameManager.instance.SetBottomText("");
        }
    }
}
