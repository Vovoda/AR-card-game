using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class TrackList : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    private TextMesh text;

    void Start()
    {
        text = textObject.GetComponent<TextMesh>();
    }


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
            textObject.transform.position = tb.transform.position;
            textObject.transform.position = new Vector3(tb.transform.position.x, tb.transform.position.y - 0.5f, tb.transform.position.z);
            if (tb.transform.position.x < -0.5f)
            {
                text.text = "Vendu";
            }
            else if (tb.transform.position.x > 0.5f)
            {
                text.text = "Equipé";

            }
            else
            {
                text.text = "";
            }
        }
    }
}
