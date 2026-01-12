using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Threading;
using System;
public class FortyYardDash : MonoBehaviour
{
    //test

    public Text timertext;
    public GameObject StartPoint;
    public GameObject End;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject == StartPoint)
        {
            timer.Start();
            

        }
        if (trigger.gameObject == End)
        {
            timer.Stop();
            //stop
        }
    }
   public void Update()
    {
        

        
           
        TimeSpan ts = timer.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:000}", ts.Seconds, ts.Milliseconds);
        timertext.text = elapsedTime;

        
    }
    public Stopwatch timer = new Stopwatch();
    

    void Timer()
    {
        timer.Start();
    }

    //ctr
    



}
