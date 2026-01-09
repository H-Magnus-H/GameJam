using UnityEngine;
[RequireComponent (typeof(Collider2D))]
public class card : MonoBehaviour
{
    private Collider2D coll;

    private Vector3 startDragPosition;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        transform.position = GetMousePositionInWorldSpace();
        

    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
        
    }
    private void OnMouseUp()
    {
        coll.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        coll.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
        {
            cardDropArea.OnCardDrop(this);  
        }
        else if (hitCollider  != null && hitCollider.TryGetComponent<CanvasRenderer>(out _))
        {
            transform.position = startDragPosition;
        }
        else
        {
            if (!GridManager.instance.HandlePlacement(this))
            {
                transform.position = startDragPosition;
            }
            //cardDropArea 
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
    private void OnDestroy()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Pipe_Script>().enabled = true;
    }
}
