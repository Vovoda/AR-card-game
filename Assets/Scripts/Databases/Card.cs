using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private string cardName;
    [SerializeField] private Sprite cardSprite;

    public Sprite CardSprite { get => cardSprite; set => cardSprite = value; }
    protected string CardName { get => cardName; set => cardName = value; }
}
