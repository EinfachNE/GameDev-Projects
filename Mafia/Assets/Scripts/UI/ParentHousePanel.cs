using TMPro;
using UnityEngine;

public class ParentHousePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI room0UIText;

    public void Populate(Building building)
    {
        room0UIText.text = building.GetRoomType(0).ToString();
    }
}
