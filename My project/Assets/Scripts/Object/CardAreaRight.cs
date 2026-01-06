using UnityEngine;

public class CardAreaRight : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(card card1)
    {
        card1.transform.position = transform.position;
        Debug.Log("Card was sropped in the right area");
    }
    //[SerializeField] private GameObject objectToSpawn;

    //public void OnCardDrop(card card)
    //{
    //    Destroy(card.gameObject);
    //    Instantiate(objectToSpawn, transform.position, transform.rotation);
    //}
}
