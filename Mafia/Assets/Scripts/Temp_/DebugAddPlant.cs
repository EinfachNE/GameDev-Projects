using System;
using UnityEngine;

public class DebugAddPlant : MonoBehaviour
{
    private Player player;
    [SerializeField] ItemDefinition itemDefinition;
    [SerializeField] ItemDefinition flowerpot;
    void Start()
    {
        player = Player.Instance;
    }

    public void AddPlant()
    {
        player.GetComponent<Inventory>().AddItem(itemDefinition, 1);
    }
    public void AddFlowerpot()
    {
        player.GetComponent<Inventory>().AddItem(flowerpot, 1);
    }
}
