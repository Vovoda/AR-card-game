using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuff : MonoBehaviour
{
    enum StuffType {helmet, bottom, top, weapon};
    [SerializeField] StuffType myType;
    [SerializeField] private int number;
    [SerializeField] private int price;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
