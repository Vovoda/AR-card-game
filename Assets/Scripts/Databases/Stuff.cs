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
    public enum State { Sold, Equipped, None, Counted};
    [SerializeField] public State state;
    private bool isSeen = false;
    private float widthCameraPercentageSell = 0.3f;
    private float heightCameraPercentageSell = 0.7f;
    private bool selling = false;
    private bool estimating = false;
    private float currentTime;
    private float maxTime=2;

    public int Price { get => price; set => price = value; }
    public StuffType MyType { get => myType; set => myType = value; }
    public global::System.Int32 Number { get => number; set => number = value; }

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

    void Update()
    {
        if (isSeen && GameManager.instance.gameStep == GameManager.Step.Selling && state == State.None)
        {
            GameManager.instance.ChangeBottomTextPosition(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z));
            GameManager.instance.ChangeSideTextPosition(new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z));
            GameManager.instance.SetSpriteObject(CardSprite);
            GameManager.instance.ChangeSpriteObjectPosition(transform.position);
            Vector3 positionInScreen = Camera.main.WorldToScreenPoint(this.transform.position);
            if (!selling && positionInScreen.y > (heightCameraPercentageSell * Screen.height) && positionInScreen.x < (widthCameraPercentageSell * Screen.width))
            {
                currentTime = 0;
                selling = true;
            }
            if (!selling && positionInScreen.y > 0 && positionInScreen.y < (heightCameraPercentageSell * Screen.height) && positionInScreen.x < (widthCameraPercentageSell * Screen.width))
            {
                GameManager.instance.EstimateStuffPrice(this);
                //GameManager.instance.ChangeBoursePosition(Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x, this.transform.position.y, 0)));
                estimating = true;
            }
            if(estimating && positionInScreen.x > (widthCameraPercentageSell * Screen.width))
            {
                estimating = false;
                GameManager.instance.HideBourse();
            }
        }
        if (selling && state!=State.Sold)
        {
            currentTime += Time.deltaTime;
            if (currentTime > maxTime)
            {
                Vector3 positionInScreen = Camera.main.WorldToScreenPoint(this.transform.position);
                if (positionInScreen.y > (heightCameraPercentageSell * Screen.height) && positionInScreen.x < (widthCameraPercentageSell * Screen.width))
                {
                    GameManager.instance.SetBottomText("Vendu");
                    GameManager.instance.SellStuff(this);
                    state = State.Sold;
                    estimating = false;
                    GameManager.instance.HideBourse();
                }
                selling = false;
            }
        }
    }

    void Start()
    {
        state = State.None;
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        widthCameraPercentageSell = 0.3f;
        heightCameraPercentageSell = 0.7f;
        maxTime = 2;

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
        if (estimating)
        {
            GameManager.instance.HideBourse();
        }
    }
}
