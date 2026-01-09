
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int cardsInHand;
    public CardAreaRight[] cardPositions;

    public card[] pipeCardPrefabs;


    public void Awake()
    {

    }
    void Start()
    {
        cardPositions = this.GetComponentsInChildren<CardAreaRight>();
    }

    void Update()
    {
        foreach (CardAreaRight area in cardPositions)
        {
            if (area.cardInPlace != null)
            {
                return;
            }
        }


        generateHand();

    }

    public void generateHand()
    {
        foreach (CardAreaRight area in cardPositions)
        {
            card card1 = Instantiate(pipeCardPrefabs[Random.Range(0, pipeCardPrefabs.Length)], new Vector3(0, 0, 0), Quaternion.identity);
            card1.transform.localPosition = Vector3.zero;
            area.OnCardDrop(card1);
        }


    }

}
