using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance = null;

    private float currentTime;
    private float maxTime;
    private bool timerOn;

    public bool TimerOn { get => timerOn; set => timerOn = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            timerOn = false;
        }
    }

    public void StartTimer(float time)
    {
        if (!timerOn)
        {
            timerOn = true;
            currentTime = 0;
            maxTime = time;
            Debug.Log("lol");
        }
    }

    public bool TimerFinished()
    {
        if (timerOn)
        {
            return false;
        }
        else
        {
            Debug.Log("youlou");
            return true;
        }
    }
}
