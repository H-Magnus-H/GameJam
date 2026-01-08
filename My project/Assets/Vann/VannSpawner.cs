using UnityEngine;
using UnityEngine.InputSystem;

public class VannSpawner : MonoBehaviour
{

    public GameObject prefab;
    public Vector2 spawnPosition;

    void Start()
    {
       
    }


    void Update()
    {
        Instantiate(prefab, spawnPosition, Quaternion.identity);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(prefab, spawnPosition, Quaternion.identity);
        //}
    }
}
