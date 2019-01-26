using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackList : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        // Iterate through the list of active trackables
        Debug.Log("List of trackables currently active (tracked): ");
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Debug.Log("Trackable: " + tb.TrackableName);
            Debug.Log("Position" + tb.transform.position);
            if(tb.transform.position.x < -0.5f)
            {
                tb.transform.GetComponentInChildren<TextMesh>().text = "Vendu";
            }
            else if (tb.transform.position.x > 0.5f)
            {
                tb.transform.GetComponentInChildren<TextMesh>().text = "Equipé";

            }
            else
            {
                tb.transform.GetComponentInChildren<TextMesh>().text = "";
            }
        }
    }
}
