using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;




public class Pipe_selector_script : MonoBehaviour
{

    #region variables
    [Header("Variables")]
    private GameObject pipeObject; // pipe to be instantiated 
    #endregion

    // The list with all the pipes in it.
    public List<GameObject> pipeList;
    #region pipes
    [SerializeField] private GameObject straightPipe;
    [SerializeField] private GameObject curvePipe;
    [SerializeField] private GameObject splitPipe;

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
        
    }
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Awake()
    {
        // Adds the pipe objects to the pipeList.
        pipeList.Add(straightPipe);
        pipeList.Add(curvePipe);
        pipeList.Add(splitPipe);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
