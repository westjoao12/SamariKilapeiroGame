using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    private const float REAL_SECONDS_PER_INGAME_DAY = 360f;

    public Transform ClockHourHandTransform;
    public Transform ClockMinuteHandTransform;
    public Text timeText;

    private float day;


    //private void Awake()
    //{
    //    ClockHourHandTransform = transform.Find("hourHand");
    //    ClockMinuteHandTransform = transform.Find("minuteHand");
    //    timeText = transform.Find("timeText").GetComponent<Text>();
    //}


    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        float rotationDedreesPerDay = 360f;
        ClockHourHandTransform.eulerAngles = new Vector3(0,0, -dayNormalized * rotationDedreesPerDay);

        float hoursPerDay = 24f;
        ClockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDedreesPerDay * hoursPerDay);

        string hoursString = Mathf.Floor(dayNormalized * 24f).ToString("00");

        float minutesPerHour = 60f;
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;
    }
}
