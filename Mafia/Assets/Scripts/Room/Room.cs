using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private RoomDefinition definition;

    [SerializeField] private List<Placable> placables = new List<Placable>();
    private int maxCapacity;
    private int currentCapacity;


    public event Action OnPlacablesChanged;

    public void Setup()
    {
        maxCapacity = definition.GetBaseCapacity();
        currentCapacity = 0;

    }
    public RoomType GetRoomType()
    {
        return definition.GetRoomType();
    }

    public int GetCurrentCapacity() { return currentCapacity; }
    public int GetMaxCapacity() { return maxCapacity; }
    public bool HasSpace(Placable placable)
    {
        return currentCapacity + placable.GetCapacityCost() <= maxCapacity;
    }
    public bool AddPlacable(Placable placable)
    {
        if (HasSpace(placable))
        {
            placables.Add(placable);
            currentCapacity += placable.GetCapacityCost();
            OnPlacablesChanged?.Invoke();
            return true;
        }
        return false;
    }
    public List<Placable> GetPlacables() 
    {
        return placables;
    }
    public Placable GetPlacable(int index) 
    {
        return placables[index];
    }
}
