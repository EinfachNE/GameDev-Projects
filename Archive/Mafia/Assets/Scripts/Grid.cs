using UnityEngine;
using System;

public class Grid<TGridObject>
{

    public event EventHandler<OnGridValueChangedEventArgs> OnGridObjectChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }


    private int width;
    private int height;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;
    private float gridSize;
    public Grid(int width, int height, float gridSize, Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {

        this.width = width;
        this.height = height;
        this.gridSize = gridSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridArray[x, y] = createGridObject(this, x, y);
            }
        }

        this.originPosition = originPosition;
    }
    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * gridSize, y * gridSize, 0) + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / gridSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / gridSize);
    }


    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    public TGridObject GetGridObject(int x, int y)
    {
        return gridArray[x, y];
    }

    public void TriggerObjectChanged(int x, int y)
    {
        if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
    }

}

