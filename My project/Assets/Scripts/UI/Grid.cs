using UnityEngine;

public class Grid<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private TGridObject[,] gridArray;
    private Vector3 originPosition;

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
    }

  
    public void ExpandDown(int extraRows)
    {
        int newHeight = height + extraRows;
        TGridObject[,] newArray = new TGridObject[width, newHeight];

        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                newArray[x, y + extraRows] = gridArray[x, y];
            }
        }

        gridArray = newArray;
        height = newHeight;

        // flytter grid ned med worldspace
        originPosition += Vector3.down * extraRows * cellSize;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
        }
    }

    public TGridObject GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        return default;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return originPosition + new Vector3(x * cellSize, y * cellSize);
    }

    public Vector3 GetWorldPositionCentered(int x, int y)
    {
        return originPosition + new Vector3(
            (x + 0.5f) * cellSize,
            (y + 0.5f) * cellSize
        );
    }

    public int GetWidth() => width;
    public int GetHeight() => height;
    public Vector3 GetOriginPosition() => originPosition;
}
