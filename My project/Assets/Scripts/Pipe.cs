using UnityEngine;

public class Pipe : MonoBehaviour
{
    // this script lets you pick up a pipe-card object and drag and drop it into the grid
    // it spawns the associated pipe prefab in the closest grid and then deletes itself

    private Collider2D col;
    public GridManager gridM;

    public GameObject pipe;

    void Start()
    {
        col = GetComponent<Collider2D>();
        gridM = GameObject.Find("GridManager").GetComponent<GridManager>();
    }

    private void OnMouseDown()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }


    private void OnMouseUp()
    {
        gridM.HandlePlacement(pipe);
        Destroy(gameObject);
        Debug.Log("generate new card");
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }

}
