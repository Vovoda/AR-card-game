using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

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
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Stuff stuff = tb.GetComponent<Stuff>();
            if (stuff != null)
            {
                GameManager.instance.StuffAppear(stuff);
            }
        }
    }
}
