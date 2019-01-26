using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrackingCard : MonoBehaviour
{
    //this is your object that you want to have the UI element hovering over
    [SerializeField] private GameObject WorldObject;

    //First you need the RectTransform component of your canvas
    private RectTransform CanvasRect;

    [SerializeField] private bool showText;

    public GameObject WorldObject1 { get => WorldObject; set => WorldObject = value; }

    // Start is called before the first frame update
    void Start()
    {
        CanvasRect = this.transform.parent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showText)
        {
            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(WorldObject.transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

            //now you can set the position of the ui element
            this.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
        }
    }
}
