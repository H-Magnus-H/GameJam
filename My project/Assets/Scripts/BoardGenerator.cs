using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject tilePrefab;

    [Header("Board Settings")]
    [SerializeField] private int width = 8;
    [SerializeField] private int height = 8;
    [SerializeField] private float tileSize = 1f;

    [Header("Colors")]
    [SerializeField] private Color lightColor = new Color(0.93f, 0.93f, 0.93f);
    [SerializeField] private Color darkColor = new Color(0.20f, 0.20f, 0.20f);

    private SpriteRenderer[,] tileRenderers;

    private void Awake()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        if (tilePrefab == null)
        {
            Debug.LogError("BoardGenerator: tilePrefab is not assigned.");
            return;
        }

        tileRenderers = new SpriteRenderer[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 offset = new Vector3(
                    (width - 1) * tileSize / 2f,
                    (height - 1) * tileSize / 2f,
                    0f
                );

                Vector3 pos = new Vector3(x * tileSize, y * tileSize, 0f) - offset;

                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
                tile.name = $"Tile_{x}_{y}";

                var sr = tile.GetComponent<SpriteRenderer>();
                if (sr == null)
                {
                    Debug.LogError("Tile prefab needs a SpriteRenderer.");
                    return;
                }

                bool isLight = (x + y) % 2 == 0;
                sr.color = isLight ? lightColor : darkColor;

                tileRenderers[x, y] = sr;
            }
        }
    }

    public void HighlightTile(int x, int y, Color color)
    {
        if (tileRenderers == null) return;
        if (x < 0 || x >= width || y < 0 || y >= height) return;

        tileRenderers[x, y].color = color;
    }
}
