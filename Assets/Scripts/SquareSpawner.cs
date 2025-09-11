using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    //Creating variables for each corner point of the square which will be stored in vector2's

    float x1 = -1;
    float y1 =  1;

    float x2 =  1;
    float y2 =  1;

    float x3 =  1;
    float y3 = -1;

    float x4 = -1;
    float y4 = -1;

    //This is to track the mouse position and convert it from screen space to world space
    public Vector2 screenPos;
    public Vector2 worldPos;

    //Arraylist to hold all the squares vector points once a click happens
    List<Vector2[]> squareSpawner = new List<Vector2[]>();

    void Start()
    {
        
    }

    void Update()
    {
        //Creating the lines as vectors for each side of the square
        Vector2 topLeft = new Vector2(x1, y1);
        Vector2 topRight = new Vector2(x2, y2);
        Vector2 bottomRight = new Vector2(x3, y3);
        Vector2 bottomLeft = new Vector2(x4, y4);

        //This stores the mouse position
        screenPos = Input.mousePosition;

        //Using the camera, the screen position of the mouse can be tracked in world space
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        //Each point of the square is being added with the world space so it's always moving with the mouse
        topLeft += worldPos;
        topRight += worldPos;
        bottomRight += worldPos;
        bottomLeft += worldPos;

        //This draws the preview square that always follows the mouse
        Debug.DrawLine(topLeft, topRight, Color.gray);
        Debug.DrawLine(topRight, bottomRight, Color.gray);
        Debug.DrawLine(bottomRight, bottomLeft, Color.gray);
        Debug.DrawLine(bottomLeft, topLeft, Color.gray);

        if (Input.GetMouseButtonDown(0))
        {
            //Creates a new array to store each of the vector points of the square whenever mouse is clicked
            Vector2[] squareSpawn = new Vector2[4];
            squareSpawn[0] = topLeft;
            squareSpawn[1] = topRight;
            squareSpawn[2] = bottomRight;
            squareSpawn[3] = bottomLeft;

            //Adds each of the stored arrays to the list 
            squareSpawner.Add(squareSpawn);
        }

        // This loops through the list of arrays and ends at the count of the list so it adds squares as often as clicked
        for (int i = 0; i < squareSpawner.Count; i++)
        {
            //Creates a new vector2 array to redraw each square that was stored in the list
            Vector2[] squareArray = squareSpawner[i];

            //Draws each side of the square in white
            Debug.DrawLine(squareArray[0], squareArray[1], Color.white);
            Debug.DrawLine(squareArray[1], squareArray[2], Color.white);
            Debug.DrawLine(squareArray[2], squareArray[3], Color.white);
            Debug.DrawLine(squareArray[3], squareArray[0], Color.white);
        }


    }
}