using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Alchemy.Inspector;

public class Pipe_Script : MonoBehaviour
{
    int maxWaterLevel = 100; // the max level a pipe can keep of water




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

}
public enum Direction
{
    UP = 0,
    RIGHT = 1,
    DOWN = 2,
    LEFT = 3,
}