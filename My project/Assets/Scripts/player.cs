
using UnityEngine;

public class player : MonoBehaviour
{
    public int cardsInHand;
    public Transform s1;
    public Transform s2;
    public Transform s3;

    public GameObject[] pipeCardPrefabs;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cardsInHand = GameObject.FindGameObjectsWithTag("PipeCard").Length;

        if (cardsInHand <= 0)
        {
            generateHand();
        }
    }

    public void generateHand()
    {
        GameObject card1 = Instantiate(pipeCardPrefabs[Random.Range(0, pipeCardPrefabs.Length)], new Vector3(7, -4, 0), Quaternion.identity, s1);
        GameObject card2 = Instantiate(pipeCardPrefabs[Random.Range(0, pipeCardPrefabs.Length)], new Vector3(6, -4, 0), Quaternion.identity, s2);
        GameObject card3 = Instantiate(pipeCardPrefabs[Random.Range(0, pipeCardPrefabs.Length)], new Vector3(5, -4, 0), Quaternion.identity, s3);

        card1.transform.localPosition = Vector3.zero;
        card2.transform.localPosition = Vector3.zero;
        card3.transform.localPosition = Vector3.zero;
    }

}
