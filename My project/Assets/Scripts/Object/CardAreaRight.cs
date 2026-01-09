using UnityEngine;

public class CardAreaRight : MonoBehaviour, ICardDropArea
{
    public card cardInPlace;
    public void OnCardDrop(card card1)
    {
        if (cardInPlace == null)
        {
            card1.transform.position = transform.position;
            Debug.Log("Card was sropped in the right area");
            cardInPlace = card1;
        }

    }
    //[SerializeField] private GameObject objectToSpawn;

    //public void OnCardDrop(card card)
    //{
    //    Destroy(card.gameObject);
    //    Instantiate(objectToSpawn, transform.position, transform.rotation);
    //}
}
