using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;

public class Stuff : Card, ITrackableEventHandler
{
    private TrackableBehaviour trackableBehaviour;
    public enum StuffType {Casque, Chaussures, Haut, Arme};
    [SerializeField] StuffType myType;
    [SerializeField] private int number;
    [SerializeField] private int price;
    private enum State { Sold, Equipped, None};
    [SerializeField] State state;
    private bool isSeen = false;
    private float widthCameraPercentageSell = 0.3f;
    private float heightCameraPercentageSell = 0.7f;

    public Stuff(StuffType newType, int newNumber, int newPrice)
    {
        myType = newType;
        number = newNumber;
        price = newPrice;
    }

    public void DisplayCharacterictics()
    {
        string textToDisplay = CardName + "\n " + myType.ToString() + "\n" + price + " G";
        GameManager.instance.SetSideText(textToDisplay);
    }

    public IEnumerator CheckSell()
    {
        Vector3 positionInScreen = Camera.main.WorldToScreenPoint(this.transform.position);
        if (positionInScreen.y > (heightCameraPercentageSell * Screen.height) && positionInScreen.x < (widthCameraPercentageSell * Screen.width))
        {
            Timer.instance.StartTimer(2);
            while (!Timer.instance.TimerFinished())
            {
                yield return null;
            }
            GameManager.instance.SetBottomText("Vendu");
        }
    }

    void Update()
    {
        if (isSeen && state == State.None)
        {
            GameManager.instance.ChangeBottomTextPosition(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z));
            GameManager.instance.ChangeSideTextPosition(new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z));
            GameManager.instance.SetSpriteObject(CardSprite);
            GameManager.instance.ChangeSpriteObjectPosition(transform.position);
            if (!Timer.instance.TimerOn)
            {
                StartCoroutine(CheckSell());
            }
            DisplayCharacterictics();
        }
    }

    void Start()
    {
        state = State.None;
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        widthCameraPercentageSell = 0.3f;
        heightCameraPercentageSell = 0.7f;

        if (trackableBehaviour)
            trackableBehaviour.RegisterTrackableEventHandler(this);
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
        isSeen = true;
    }

    private void onTrackingLost()
    {
        isSeen = false;
        state = State.None;
        GameManager.instance.SetBottomText("");
        GameManager.instance.SetSideText("");
        GameManager.instance.SetSpriteObject(null);
    }
}
