using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private Transform Hours, Minutes, Seconds;

    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        Hours.localRotation = Quaternion.Euler(30 * (float)time.TotalHours, 0, 0);
        Minutes.localRotation = Quaternion.Euler(6 * (float)time.TotalMinutes, 0, 0);
        Seconds.localRotation = Quaternion.Euler(6 * (float)time.TotalSeconds, 0, 0);
    }
}