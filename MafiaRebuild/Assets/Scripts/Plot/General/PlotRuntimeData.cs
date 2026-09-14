using UnityEngine;

public class PlotRuntimeData : MonoBehaviour
{

    [SerializeField] private EntityType isOwnedBy = EntityType.NPC;

    public void SetIsOwnedBy(EntityType type)
    {
        isOwnedBy = type;
    }
    public EntityType GetIsOwnedBy()
    {
        return isOwnedBy;
    }
}
