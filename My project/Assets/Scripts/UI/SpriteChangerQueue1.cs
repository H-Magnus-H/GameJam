using System.Collections;
using UnityEngine;

public class SpriteChangerQueue : MonoBehaviour
{
    [Header("Block Stages (4 Sprites)")]
    [SerializeField] private Sprite[] stages = new Sprite[4];

    [SerializeField] private float delayBetweenStages = 0.5f;

    private SpriteRenderer spriteRenderer;

    //Queue management
    private static int nextPlacementIndex = 0;
    private static int activeIndex = 0;
    private int myIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Safety check
        if (stages.Length != 4)
        {
            Debug.LogError($"{name} does not have exactly 4 sprites assigned.");
            enabled = false;
            return;
        }

        spriteRenderer.sprite = stages[0];

        // Assign block placed order
        myIndex = nextPlacementIndex;
        nextPlacementIndex++;
    }

    //Stars the coroutine
    private void Start()
    {
        StartCoroutine(WaitAndPlayStages());
    }

    private IEnumerator WaitAndPlayStages()
    {
        //Wait for turn
        while (myIndex != activeIndex)
            yield return null;

        //Loop through sprites 
        for (int i = 1; i < stages.Length; i++)
        {
            yield return new WaitForSeconds(delayBetweenStages);
            spriteRenderer.sprite = stages[i];
        }

        //Next placed block starts 
        activeIndex++;
    }
}
