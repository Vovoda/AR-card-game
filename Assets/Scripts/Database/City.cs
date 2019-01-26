using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Card
{
    [SerializeField] private string cityEffect;

    public City(string newName, string newEffect)
    {
        cardName = newName;
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
