using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MapInitialization : MonoBehaviour
{
    public int mapSize = 14;
    List<string> atoutsId;
    private int currentLevel;

    Map map;

    public GameObject cityUIPrefab;
    public GameObject canvas;

    public bool isMapSetUp;

    private void Start()
    {
        atoutsId = new List<string>();
        isMapSetUp = false;
        currentLevel = 0;
    }

    void Update()
    {
        if (atoutsId.Count < mapSize)
        {
            // Get the Vuforia StateManager
            StateManager sm = TrackerManager.Instance.GetStateManager();

            // Query the StateManager to retrieve the list of
            // currently 'active' trackables 
            //(i.e. the ones currently being tracked by Vuforia)
            IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

            // Iterate through the list of active trackables
            foreach (TrackableBehaviour tb in activeTrackables)
            {
                if(!atoutsId.Contains(tb.TrackableName))
                {
                    atoutsId.Add(tb.TrackableName);
                    Debug.Log("Added : " + tb.TrackableName);
                }
            }
        }
        else if (isMapSetUp == false)
        {
            //The list of names of atout is complete, let's start transforming it into the map
            map = new Map(QuickCities(atoutsId), mapSize);
            
            //create UI from map
            List<RectTransform> mapUIPositions = MapUIPositions(map);

            //stop the loop
            isMapSetUp = true;
            GameManager.instance.MapComplete();
        }
        
        //Temporary testing

        if (Input.GetKeyDown(KeyCode.Space))
        {
            map.curCity = null;
        }
    }

    public static List<List<City>> FillCityList(int initialRowSize, int totalNumberOfCities, int numberOfRows, List<City> initialList)
    {
        List<List<City>> finalList = new List<List<City>>();
        int k = 0;
        for (int i = 0; i < numberOfRows; i++)
        {
            int curK = k;
            if (i <= (numberOfRows - 1) / 2)
            {
                List<City> tempList = new List<City>();
                while (k < curK + i + initialRowSize)
                {
                    tempList.Add(initialList[k]);
                    k++;
                }
                finalList.Add(tempList);
            }
            else
            {
                List<City> tempList = new List<City>();
                while (k < curK + (numberOfRows - 1) - i + initialRowSize)
                {
                    tempList.Add(initialList[k]);
                    k++;
                }
                finalList.Add(tempList);
            }
            
        }
        return finalList;
    }

    public static City QuickCity(string s, int i)
    {
        return new City(s, s, i, i, i, i);
    }

    public static List<City> QuickCities(List<string> s)
    {
        List<City> cities = new List<City>();
        for (int i = 0; i < s.Count; i ++)
        {
            cities.Add(QuickCity(s[i], i));
        }

        return cities;
    }

    public List<RectTransform> MapUIPositions(Map map)
    {
        List<RectTransform> mapUIPositions = new List<RectTransform>();

        //Settings
        double padding = 0.5; //this will leave the space equivalent of 0.5 empty CityUI above and beneath the map

        double cityUIHeight = canvas.GetComponent<RectTransform>().sizeDelta.y / (padding * 2 + map.RowOfCities.Count);

        Debug.Log(cityUIHeight);
        Debug.Log(map.RowOfCities.Count);

        for (int i = 0; i < map.RowOfCities.Count; i++)
        {
            double yPos = (map.RowOfCities.Count / 2.0 - i) * cityUIHeight;
            

            for (int j = 0; j < map.RowOfCities[i].Count; j++)
            {
                double xPos = ((map.RowOfCities[i].Count) / 2.0 - j - 0.5) * cityUIHeight * 1.89;
                GameObject newCityUI = Instantiate(cityUIPrefab, this.transform);
                newCityUI.GetComponent<RectTransform>().localPosition = new Vector3((float)xPos, (float)yPos);
                newCityUI.GetComponent<RectTransform>().localRotation = Quaternion.identity;
                newCityUI.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (float)cityUIHeight);
                map.RowOfCities[i][j].CityUI = newCityUI.GetComponent<CityUIManager>();
            }
            
        }
        return mapUIPositions;
    }

    public void TurnRight()
    {
        if (map.curCity == null)
        {
            currentLevel++;
            if (map.RowOfCities[0].Count == 2)
            {
                map.curCity = map.RowOfCities[0][1];
            }
            else
            {
                map.curCity = map.RowOfCities[0][0];
            }
            
        } else
        {
            map.curCity.CityUI.SetSelected(false);
            if (map.curCity.RightCity != null)
            {
                currentLevel++;
                map.curCity = map.curCity.RightCity;
            }
        }
        map.curCity.CityUI.SetSelected(true);
    }

    public void TurnLeft()
    {
        if (map.curCity == null)
        {
            currentLevel++;
            map.curCity = map.RowOfCities[0][0];
        }
        else
        {
            map.curCity.CityUI.SetSelected(false);
            if (map.curCity.LeftCity != null)
            {
                currentLevel++;
                map.curCity = map.curCity.LeftCity;
            }
        }
        map.curCity.CityUI.SetSelected(true);
    }

    public City getCurCity()
    {
        return map.curCity;
    }
}
