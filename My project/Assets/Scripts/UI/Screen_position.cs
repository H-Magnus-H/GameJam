using UnityEngine;

public class Screen_position : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    void Update()
    {
        screenPosition = Input.mousePosition;


        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        //if (Physics2D.Raycast(ray, out RaycastHit2D hitData)
        //    {

        //    }

        transform.position = worldPosition;
    }
}
