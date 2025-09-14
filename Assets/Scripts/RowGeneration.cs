using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    //Variables to hold info
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

    //Secure check to see if the inputed value 
    public bool validated = false;

    void Start()
    {
        
    }
    void Update()
    {

        //Once the user input is validated to see if they string is converted to an int, the loop can start to create the row
        if (validated == true)
        {
            //Checks the space from the right and left side of the square
            float topWidth = x2 - x1;
            float bottomWidth = x3 - x4;
            
            //Loop runs on the users inputed number
            for (int i = 0; i < number; i++)
            {
                //As the loop goes through each number, the space between the next square is more to create that side by side look
                float  topSpace = topWidth * i;
                float bottomSpace = bottomWidth * i;

                Vector2 topLeft = new Vector2(x1 + topSpace, y1);
                Vector2 topRight = new Vector2(x2 + topSpace, y2);
                Vector2 bottomRight = new Vector2(x3 + bottomSpace, y3);
                Vector2 bottomLeft = new Vector2(x4 + bottomSpace, y4);

                //Draws each square in the row
                Debug.DrawLine(topLeft, topRight, Color.red);
                Debug.DrawLine(topRight, bottomRight, Color.red);
                Debug.DrawLine(bottomRight, bottomLeft, Color.red);
                Debug.DrawLine(bottomLeft, topLeft, Color.red);
            }
        }
    }
    //Function that runs on the input field to get the users inputed text
    public void readText(string s)
    {
        inputText = s;
        Debug.Log("You've entered " + inputText);
    }
    //Function runs on generate button
    public void generateRow()
    {

        //Checks to see that the value can be converted to int
        if (int.TryParse(inputText, out number))
        {
           validated = true;
        }
        //Otherwise it displays an error message
        else
        {
            Debug.Log("Invalid input. Please enter a valid number.");
        }
    }
}
