using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    public string inputText;

    public int number;

    float x1 = -8;
    float y1 = 1;

    float x2 = -6;
    float y2 = 1;

    float x3 = -6;
    float y3 = -1;

    float x4 = -8;
    float y4 = -1;

    public bool validated = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (validated == true)
        {
            float topWidth = x2 - x1;
            float bottomWidth = x3 - x4;
            

            for (int i = 0; i < number; i++)
            {

                float  topSpace = topWidth * i;
                float bottomSpace = bottomWidth * i;

                Vector2 topLeft = new Vector2(x1 + topSpace, y1);
                Vector2 topRight = new Vector2(x2 + topSpace, y2);
                Vector2 bottomRight = new Vector2(x3 + bottomSpace, y3);
                Vector2 bottomLeft = new Vector2(x4 + bottomSpace, y4);

                Debug.DrawLine(topLeft, topRight, Color.red);
                Debug.DrawLine(topRight, bottomRight, Color.red);
                Debug.DrawLine(bottomRight, bottomLeft, Color.red);
                Debug.DrawLine(bottomLeft, topLeft, Color.red);
            }
        }
    }

    public void readText(string s)
    {
        inputText = s;
        Debug.Log("You've entered " + inputText);
    }

    public void generateRow()
    {
       

        if (int.TryParse(inputText, out number))
        {
           validated = true;
        }
        else
        {
            Debug.Log("Invalid input. Please enter a valid number.");
        }
    }
}
