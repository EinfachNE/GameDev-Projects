using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    private long totalGameMinutes = 0;
    [SerializeField] private float secondsPerIngameMinute;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Tick();
    }

    private float currentTick = 0;
    public void Tick()
    {
        currentTick += Time.deltaTime;
        if (currentTick >= secondsPerIngameMinute)
        {
            currentTick = 0;
            totalGameMinutes++;
        }
    }

    public int GetDay()
    {
        return (int)(totalGameMinutes / 1440) + 1;
    }
    public int GetHour()
    {
        return (int)((totalGameMinutes % 1440) / 60);
    }
    public int GetMinute()
    {
        return (int)(totalGameMinutes % 60);
    }
    public long GetTotalTime()
    {
        return totalGameMinutes;
    }
}
