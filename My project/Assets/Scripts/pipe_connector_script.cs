using Unity.VisualScripting;
using UnityEngine;

public class pipe_connector_script : MonoBehaviour
{
    public int pipe_id = 0;
    [Header("Colliders")]
    [SerializeField] public Collider2D pipeColliderUp;
    [SerializeField] public Collider2D pipeColliderDown;

    private void pipeConnection()
    {
        if (pipeColliderUp.IsTouching(pipeColliderDown) && Input.GetKey(KeyCode.B))
        {

        }
    }
}
