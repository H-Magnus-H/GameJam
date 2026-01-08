using UnityEngine;
using System.Collections;

public class SpriteSequence : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = new Sprite[4];
    [SerializeField] private float delay = 0.5f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }

    private void Start()
    {
        PlaySequence();
    }


    public void PlaySequence()
    {
        StartCoroutine(ChangeSprites());
    }

    private IEnumerator ChangeSprites()
    {
        for (int i = 1; i < sprites.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            spriteRenderer.sprite = sprites[i];
        }
    }
}
