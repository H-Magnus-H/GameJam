using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;




public class Pipe_selector_script : MonoBehaviour
{

    #region variables
    [Header("Variables / Other")]
    private GameObject pipeObject; // pipe to be instantiated 
    [Space(2)]
    [Header("bools")]
    private bool pipePlaced = false;
    private bool pipeCreated = false;
    #endregion

    // The list with all the pipes in it.
    public List<GameObject> pipeList;
    #region pipes
    
    [SerializeField] private GameObject straightPipePrefab;
    [SerializeField] private GameObject curvePipePrefab;
    [SerializeField] private GameObject splitPipePrefab;

    #endregion
    #region Pipe Selection
    // pipe selector finds one of the pipe designs and selects it as the object to be created (spawned).
    public void pipeSelector()
    {
        // counts all the pipe objects in the list
        int listObject = pipeList.Count;

        // finds a random pipe object's list number
        int listNumber = Random.Range(0, listObject);

        // finds the random object from the list and selects it as the object to be created
        pipeObject = pipeList[listNumber];
    }
    #endregion
    #region Pipe Generation 
    // Pipe generator gets the pipe ment to be created and places it in the scene.
    private void pipeGenerator(int index)
    {
        for (int i = 0; i < index; i++)
        {
            pipeSelector();

            GameObject newPipe = GameObject.Instantiate(pipeObject, this.transform);

        }
    }
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Awake()
    {
        // Adds the pipe objects to the pipeList.
        pipeList.Add(straightPipePrefab);
        pipeList.Add(curvePipePrefab);
        pipeList.Add(splitPipePrefab);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
