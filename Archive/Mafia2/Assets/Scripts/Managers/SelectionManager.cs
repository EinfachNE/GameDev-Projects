using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private PlotUIManager plotUIManager;
    [SerializeField] private GridManager gridManager;
    private bool isPanelOpen = false;

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
        if (!isPanelOpen && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePos = Pointer.current.position.ReadValue();
            Vector2Int worldPos = Vector2Int.RoundToInt(cam.ScreenToWorldPoint(mousePos));

            Plot plot = gridManager.GetPlot(worldPos);
            if (plot != null && plot.GetPlotStaticData().GetPlotType() != PlotType.Street)
            {
                plotUIManager.OpenPlotPanel(plot);
                isPanelOpen = true;
            }
        }
    }
    public void SetIsPanelOpen(bool value)
    {
        isPanelOpen=value;
    }
}
