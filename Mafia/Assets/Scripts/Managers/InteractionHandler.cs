using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InteractionHandler : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerMovement player;

    private PlayerInputActions inputActions;
    

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
        inputActions.Gameplay.Select.performed += OnSelect;
    }
    private void OnDisable()
    {
        inputActions.Gameplay.Select.performed -= OnSelect;
        inputActions?.Gameplay.Disable();
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 worldPos = GetMouseToWorldPosition();
            Interact(gridManager.GetPlotFromWorldPos(worldPos));
        }
    }
    public Vector2 GetMouseToWorldPosition()
    {
        Vector2 mousePos = Pointer.current.position.ReadValue();
        Vector2Int worldPos = Vector2Int.RoundToInt(cam.ScreenToWorldPoint(mousePos));
        return worldPos;
    }
    public void Interact(Plot plot)
    {
        Vector2 playerPos = player.transform.position; 
        PlotContent content = plot?.GetContent();
        if (content != null)
        {
            if (Vector2.Distance(playerPos, content.GetInteractionPoint()) > 1)
            {
                player.ClickMoveTowards(content.GetInteractionPoint());
            }
            else
            {
                switch (content.GetPlotContentType())
                {
                    case PlotContentType.Building:
                        Building building = content as Building;
                        uiManager.OpenBuildingUI(building);
                        break;

                    case PlotContentType.MeetingLocation:
                        MeetingLocation location = content as MeetingLocation;
                        uiManager.OpenMeetingLocationUI(location);
                        break;

                }
            }
        }
    }
}
