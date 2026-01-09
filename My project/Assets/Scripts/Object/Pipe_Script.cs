using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Alchemy.Inspector;

public class Pipe_Script : MonoBehaviour
{
    int maxWaterLevel = 100; // the max level a pipe can keep of water
    private Pipe_Script nextPipe;



    public void SetNextPipe(Pipe_Script pipe)
    {
        nextPipe ??= pipe;
        
    }



    public List<Direction> openings;
    // alcamy is magic <3
    // if you don't have it get it.
    [Button]
    public List<Direction> GetOpenings()
    {
        List<Direction> newOpenings = new List<Direction>();


        int offset = Math.DivRem(Mathf.FloorToInt(this.transform.eulerAngles.z), 90, out _);

        foreach (Direction direction in openings)
        {
            newOpenings.Add((Direction)(((int) direction + offset) % 4));


        }

        return newOpenings;
    }




    // sprite changer 
    #region Sprite changer 

    //[Header("Block Stages (4 Sprites)")]
    //[SerializeField] private Sprite[] stages = new Sprite[4];

    //[SerializeField] private float delayBetweenStages = 8f;
    //[SerializeField] private float delayBetweenTimeChange = 0.04f;

    //private SpriteRenderer spriteRenderer;

    ////Queue management
    //private static int nextPlacementIndex = 0;
    //private static int activeIndex = 0;
    //private int myIndex;

    //private void Awake()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();

    //    // Safety check
    //    if (stages.Length != 4)
    //    {
    //        Debug.LogError($"{name} does not have exactly 4 sprites assigned.");
    //        enabled = false;
    //        return;
    //    }

    //    spriteRenderer.sprite = stages[0];

    //    // Assign block placed order
    //    myIndex = nextPlacementIndex;
    //    nextPlacementIndex++;
    //}

    ////Stars the coroutine
    //private void Start()
    //{
    //    StartCoroutine(WaitAndPlayStages());
    //    StartCoroutine(CountDownStage());
    //}

    //private IEnumerator WaitAndPlayStages()
    //{
    //    //Wait for turn
    //    while (myIndex != activeIndex)
    //        yield return null;

    //    //Loop through sprites 
    //    for (int i = 1; i < stages.Length; i++)
    //    {
    //        yield return new WaitForSeconds(delayBetweenStages);
    //        spriteRenderer.sprite = stages[i];
    //    }

    //    //Next placed block starts 
    //    activeIndex++;
    //}
    //private IEnumerator CountDownStage()
    //{
    //    //Wait for turn
    //    while (myIndex != activeIndex)
    //        yield return null;

    //    //Loop through sprites 

    //    yield return new WaitForSeconds(delayBetweenTimeChange);


    //    //Next placed block starts 
    //    activeIndex++;
    //}


    //// end of sprite changer 
    #endregion




}
public enum Direction
{
    UP = 0,
    RIGHT = 1,
    DOWN = 2,
    LEFT = 3,
}


