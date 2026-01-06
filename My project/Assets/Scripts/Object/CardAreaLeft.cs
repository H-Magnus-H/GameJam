using UnityEngine;

public class CardAreaLeft : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(card card1)
    {
        card1.transform.position = transform.position;
        Debug.Log("Card was sropped in the left area");
    }
}
