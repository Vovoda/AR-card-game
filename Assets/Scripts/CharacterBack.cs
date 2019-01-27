using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;

public class CharacterBack : MonoBehaviour, ITrackableEventHandler
{

    bool isSeen=false;

    private TrackableBehaviour trackableBehaviour;

    void Start()
    {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
            trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    void Update()
    {
        //this.transform.position = 
    }

    public void OnTrackableStateChanged(
      TrackableBehaviour.Status previousStatus,
      TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            OnTrackingFound();
        else
            onTrackingLost();
    }

    private void OnTrackingFound()
    {
        GameManager.instance.CharacterBack();
        isSeen = true;
    }

    private void onTrackingLost()
    {
        isSeen = false;
    }
}
