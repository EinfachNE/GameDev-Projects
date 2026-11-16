using System;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    private TimeManager timeManager;
    [SerializeField] TextMeshProUGUI day;
    [SerializeField] TextMeshProUGUI hour;
    [SerializeField] TextMeshProUGUI minute;
    void Start()
    {
        timeManager = TimeManager.Instance;
    }

    void Update()
    {
        day.text = "Day " + timeManager.GetDay().ToString();
        hour.text = timeManager.GetHour().ToString();
        if (timeManager.GetMinute() < 10)
        {
            minute.text = "0" + timeManager.GetMinute().ToString();
        }
        else
        {
            minute.text = timeManager.GetMinute().ToString();
        }
    }
}
