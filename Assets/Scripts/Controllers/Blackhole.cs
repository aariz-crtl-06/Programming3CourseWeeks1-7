using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public Transform playPos;

    int numberOfSides = 16;
    float radius = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        //to track space between player and black hole
        float dist = Vector3.Distance(transform.position, playPos.position);

        //List for each of the points in circle
        List<Vector3> circlePoints = new List<Vector3>();

        //Loop to convert degrees into radients, then creates the points on circle using trig
        for (int i = 0; i < numberOfSides; i++)
        {
            float degrees = 360 / numberOfSides * i;
            float radians = degrees * Mathf.Deg2Rad;

            float x = Mathf.Cos(radians) * radius;
            float y = Mathf.Sin(radians) * radius;

            circlePoints.Add(new Vector3(x, y, 0));

        }

        // Draws a line from the current point to the next, loops it so it creates a full closed off shape
        for (int i = 0; i < circlePoints.Count; i++)
        {
            //Current point being the 'i' combined with transform position to make it around the ship
            Vector3 start = circlePoints[i] + transform.position;

            //next point being 'i' + 1
            Vector3 end = circlePoints[(i + 1) % circlePoints.Count] + transform.position;

            //Visual guide to black hole radius, once the player enters the radius, they get pulled into the black hole
            if (radius >= dist)
            {

                Debug.DrawLine(start, end, Color.red);
                playPos.position = Vector3.MoveTowards(playPos.position, transform.position, Time.deltaTime);
            }

            //Otherwise its green
            else
            {
                Debug.DrawLine(start, end, Color.green);
            }
        }
    }
}