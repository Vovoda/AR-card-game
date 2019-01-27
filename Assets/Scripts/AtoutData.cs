using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtoutData : MonoBehaviour
{

    public struct CityStruct
    {
        public int carreauValue;
        public int piqueValue;
        public int trefleValue;
        public int coeurValue;

        public string effect;

        public CityStruct(int caV, int piV, int trV, int coV)
        {
            carreauValue = caV;
            piqueValue = piV;
            trefleValue = trV;
            coeurValue = coV;
            effect = "";
        }

        public CityStruct (int caV, int piV, int trV, int coV, string e)
        {
            carreauValue = caV;
            piqueValue = piV;
            trefleValue = trV;
            coeurValue = coV;
            effect = e;
        }

    }
    

    public static Dictionary<string, CityStruct> InitAtoutData()
    {
        Dictionary<string, CityStruct> data = new Dictionary<string, CityStruct>();

        data.Add("atouts_1", new CityStruct(50, 75, 75, 50));
        data.Add("atouts_2", new CityStruct(50, 75, 50, 75));
        data.Add("atouts_3", new CityStruct(75, 50, 50, 75));
        data.Add("atouts_4", new CityStruct(75, 50, 75, 50));

        data.Add("atouts_5", new CityStruct(25, 150, 25, 50));
        data.Add("atouts_6", new CityStruct(50, 25, 150, 25));
        data.Add("atouts_7", new CityStruct(25, 50, 25, 150));
        data.Add("atouts_8", new CityStruct(150, 25, 50, 25));

        data.Add("atouts_9", new CityStruct(50, 50, 100, 50));
        data.Add("atouts_10", new CityStruct(50, 50, 50, 100));
        data.Add("atouts_11", new CityStruct(50, 100, 50, 50));
        data.Add("atouts_12", new CityStruct(100, 50, 50, 50));

        data.Add("atouts_13", new CityStruct(25, 50, 25, 50, "Tailleur"));
        data.Add("atouts_14", new CityStruct(50, 25, 50, 25, "Tailleur"));
        data.Add("atouts_15", new CityStruct(25, 75, 25, 25, "Coursier"));
        data.Add("atouts_16", new CityStruct(25, 25, 25, 75, "Coursier"));
        data.Add("atouts_17", new CityStruct(75, 50, 25, 50, "Voyante"));
        data.Add("atouts_18", new CityStruct(25, 50, 75, 50, "Voyante"));
        data.Add("atouts_19", new CityStruct(50, 25, 50, 25, "Receleur"));
        data.Add("atouts_20", new CityStruct(25, 50, 25, 50, "Receleur"));
        data.Add("atouts_21", new CityStruct(33, 33, 33, 33, "Faussaire"));

        return data;
    }
    

    /*public CityStruct GetCityStructByName(string s)
    {
        return data[s];
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
