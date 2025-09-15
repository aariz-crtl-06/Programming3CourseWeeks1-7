using UnityEngine;

public class methodExamples : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        DrawBoxAtPosition(mousePos, Vector2.one, new Color(1f, 1f, 1f, 0.5f));
    }

    void DrawBoxAtPosition(Vector2 position, Vector2 size, Color color)
    {
        float halfWidth = size.x / 2;
        float halfHeight = size.y / 2;

        Vector2 topLeft = position + new Vector2(-halfWidth, halfHeight);
        Vector2 topRight = topLeft + new Vector2(size.x, 0);
        Vector2 bottomRight = topRight + new Vector2(0, -size.y);
        Vector2 bottomLeft = bottomRight + new Vector2(-size.x, 0);

        Debug.DrawLine(topLeft, topRight, color, 0.05f);
        Debug.DrawLine(topRight, bottomRight, color, 0.05f);
        Debug.DrawLine(bottomRight, bottomLeft, color, 0.05f);
        Debug.DrawLine(bottomLeft, topLeft, color, 0.05f);
    }
}
