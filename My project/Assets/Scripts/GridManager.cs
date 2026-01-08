using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid<bool> grid;

    public int expandRows = 5;
    public float expandBuffer = 1f;

    void Start()
    {
        grid = new Grid<bool>(10, 10, 1f, Vector3.zero);
    }

    void Update()
    {
        ExpandGridIfNeeded();


    }

    void ExpandGridIfNeeded()
    {
        Camera cam = Camera.main;

        float cameraBottom =
            cam.transform.position.y - cam.orthographicSize;

        float gridBottom =
            grid.GetOriginPosition().y;

        if (cameraBottom < gridBottom + expandBuffer)
        {
            grid.ExpandDown(expandRows);
        }
    }

    public void HandlePlacement(GameObject pipeToPlace)
    {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            grid.GetXY(mouseWorldPos, out int x, out int y);

            Vector3 pos = grid.GetWorldPositionCentered(x, y);
            Instantiate(pipeToPlace, pos, Quaternion.identity);

            grid.SetValue(x, y, true);
    }
}

    