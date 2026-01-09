using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public static GridManager instance { get; private set; }


    private Grid<Pipe_Script> grid;
    public GameObject objectToPlace;
    public Pipe_Script startPipe;
    public int expandRows = 5;
    public float expandBuffer = 1f;

    void Start()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Pipe_Script pipe = Instantiate(startPipe);
        Destroy(pipe.gameObject.GetComponent<card>());
        grid = new (10, 10, 1f, Vector3.zero, pipe);
        instance = this;
        Vector3 pos = grid.GetWorldPositionCentered(0, 0);
        grid.GetValue(0, 0).transform.position = pos;

    }

    void Update()
    {
        ExpandGridIfNeeded();

    }

    void ExpandGridIfNeeded()
    {
        Camera cam = Camera.main;

        float cameraBottom = cam.transform.position.y - cam.orthographicSize;

        float gridBottom = grid.GetOriginPosition().y;

        if (cameraBottom < gridBottom + expandBuffer)
        {
            Debug.Log("it is expanding");
            grid.ExpandDown(expandRows);
        }
    }


    public bool HandlePlacement(card pipeToPlace)
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;



        grid.GetXY(mouseWorldPos, out int x, out int y);

        if (grid.GetValue(x, y))
        {
            return false;
        }
        Debug.Log(grid.GetValue(x, y));

        Pipe_Script pipe = pipeToPlace.gameObject.GetComponent<Pipe_Script>();

        List<Direction> directions = pipe.GetOpenings();

        bool foundLatchPipe = false;

        for (int i = 0; i < directions.Count && !foundLatchPipe ; i++)
        {
            switch (directions[i])
            {
                case Direction.UP:
                    if (grid.GetValue(x, y + 1))
                    foundLatchPipe = grid.GetValue(x, y + 1).GetOpenings().Contains(Direction.DOWN);
                    break;
                case Direction.DOWN:
                    if (grid.GetValue(x, y - 1))
                        foundLatchPipe = grid.GetValue(x, y - 1).GetOpenings().Contains(Direction.UP);
                    break;
                case Direction.RIGHT:
                    if (grid.GetValue(x + 1, y))
                        foundLatchPipe = grid.GetValue(x + 1, y).GetOpenings().Contains(Direction.LEFT);
                    break;
                case Direction.LEFT:
                    if (grid.GetValue(x - 1, y))
                        foundLatchPipe = grid.GetValue(x - 1, y).GetOpenings().Contains(Direction.RIGHT);
                    break;
            }
        }
if (!foundLatchPipe)
        {
            return false;
        }
        Vector3 pos = grid.GetWorldPositionCentered(x, y);

        pipeToPlace.transform.position = pos;



        grid.SetValue(x, y, pipe);


        Destroy(pipeToPlace);
        Debug.Log(x + " " + y);
        return true;
    }
}

//using UnityEngine;

//public class GridManager : MonoBehaviour
//{
//    private Grid<bool> grid;

//    public int expandRows = 5;
//    public float expandBuffer = 1f;

//    void Start()
//    {
//        grid = new Grid<bool>(10, 10, 1f, Vector3.zero);
//    }

//    void Update()
//    {
//        ExpandGridIfNeeded();


//    }

//    void ExpandGridIfNeeded()
//    {
//        Camera cam = Camera.main;

//        float cameraBottom =
//            cam.transform.position.y - cam.orthographicSize;

//        float gridBottom =
//            grid.GetOriginPosition().y;

//        if (cameraBottom < gridBottom + expandBuffer)
//        {
//            grid.ExpandDown(expandRows);
//        }
//    }

//    public void HandlePlacement(GameObject pipeToPlace)
//    {
//        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        mouseWorldPos.z = 0;

//        grid.GetXY(mouseWorldPos, out int x, out int y);

//        Vector3 pos = grid.GetWorldPositionCentered(x, y);
//        Instantiate(pipeToPlace, pos, Quaternion.identity);

//        grid.SetValue(x, y, true);
//    }
//}

