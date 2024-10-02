using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realtimeclock : MonoBehaviour
{
    // Reference for the time stick things for transforming
    public Transform hourTransform, minuteTransform, secondTransform;

    // Create float variables for rotation for each of the time sticks
    public float degreesInHour, degreesInMinute, degreesInSecond;

    // Variable for analog and digital selection
    public bool analog;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate how many degrees a stick will rotate per hour / minute / second
        // 360 degrees devided by amount in hour / minute or second
        degreesInHour =   360 / 12;
        degreesInMinute = 360 / 60;
        degreesInSecond = 360 / 60;
    }

    // Update is called once per frame
    void Update()
    {
        // Position of time stick things isn't correct
        if (analog)
        {
            TimeSpan timespan = DateTime.Now.TimeOfDay;

            //Debug.Log("Current analog time: " + timespan);

            hourTransform.localRotation = Quaternion.Euler((float)timespan.TotalHours * degreesInHour, 0f, 0f);
            minuteTransform.localRotation = Quaternion.Euler((float)timespan.TotalMinutes * degreesInMinute, 0f, 0f);
            secondTransform.localRotation = Quaternion.Euler((float)timespan.TotalSeconds * degreesInSecond, 0f, 0f);
        }
        else
        {
            DateTime time = DateTime.Now;

            //Debug.Log("Current time: " + time);

            hourTransform.localRotation = Quaternion.Euler(time.Hour * degreesInHour, 0f, 0f);
            minuteTransform.localRotation = Quaternion.Euler(time.Minute * degreesInMinute, 0f, 0f);
            secondTransform.localRotation = Quaternion.Euler(time.Second * degreesInSecond, 0f, 0f);
        }
    }
}
