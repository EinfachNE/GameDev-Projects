using UnityEngine;
using System;

public  class TickHandler : MonoBehaviour
{
    public static event Action onTick;

    [SerializeField] private float ticksPerSecond;
    private float timeSinceLastTick = 0f;

    void Update()
    {
        if (timeSinceLastTick > ticksPerSecond)
        {
            onTick?.Invoke();
            
            timeSinceLastTick = 0f;
        }
        else
        {
            timeSinceLastTick += Time.deltaTime;
        }
    }
}
