using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("Location")]
    [SerializeField] private int x;
    [SerializeField] private int y;

    [Header("Information")]
    [SerializeField] private PlotContent content;

    
    public void Initialize(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public PlotContent GetContent()
    {
        return content;
    }
    public void SetContent(PlotContent content)
    {
        this.content = content;
        content.Initialize(this);
    }
    public Vector2Int GetXY()
    {
        return new Vector2Int(x, y);
    }
}
