using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MapInitialization : MonoBehaviour
{
    public static int mapSize = 4;
    string[] map;
    int curMapIndex;

    private void Start()
    {
        map = new string[mapSize];
        curMapIndex = 0;
    }

    void Update()
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
            //Debug.Log("Trackable: " + tb.TrackableName);

            if (curMapIndex < mapSize)
            {
                if (Array.IndexOf(map, tb.TrackableName) == -1)
                {
                    map[curMapIndex] = tb.TrackableName;
                    Debug.Log("Added : " + tb.TrackableName);
                    curMapIndex++;
                }
            }
            else
            {
                Debug.Log("Map is full");
            }

        }
    }
}
