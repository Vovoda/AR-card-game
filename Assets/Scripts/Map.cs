using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    List<List<City>> rowOfCities;
    int totalSize;



    public Map(List<List<City>> _rowOfCities)
    {
        rowOfCities = _rowOfCities;
    }

    public Map(List<City> _cities, int _size)
    {
        List<City> tempList;
        switch (_size)
        {
            case 4:

                break;
            default:
                break;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCitiesChildren()
    {
        for (int i = 0; i < rowOfCities.Count - 1; i++)
        {
            if (rowOfCities[i].Count < rowOfCities[i+1].Count)
            {
                for (int j = 0; j < rowOfCities[i].Count; j++)
                {
                    rowOfCities[i][j].LeftCity = rowOfCities[i + 1][j];
                    rowOfCities[i][j].RightCity = rowOfCities[i + 1][j + 1];
                }
            } else
            {
                rowOfCities[i][0].RightCity = rowOfCities[i + 1][0];
                for (int j = 1; j < rowOfCities[i].Count - 1; j++)
                {
                    rowOfCities[i][j].LeftCity = rowOfCities[i + 1][j - 1];
                    rowOfCities[i][j].RightCity = rowOfCities[i + 1][j];
                }
                rowOfCities[i][rowOfCities[i].Count - 1].LeftCity = rowOfCities[i + 1][rowOfCities[i + 1].Count - 1];
            }
        }
    }
}
