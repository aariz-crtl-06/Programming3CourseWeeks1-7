using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;

    public GameObject powerUp;

    public List<Transform> asteroidTransforms;

    public float numberOfTrailBombs = 3;
    public int bombTrailSpacing;
    float moved = 0;

    float maxRange = 2.5f;

    [Header("MotionProperties")]
    public float maxSpeed = 5;
    Vector3 velocity;
    float accelerationTime = 2;
    float decelerationTime = 2;

    public bool moving = false;

    // "j2" describes tasks from journal 2
    // "j3" describes tasks from journal 3


    public float radius = 2f;
    public int numberOfSides = 6;

    public float powerUpRadius = 5f;
    public int numberOfPowerUps = 6;

    void Update()
    {
        //to track space between player and enemy
        float dist = Vector3.Distance(transform.position, enemyTransform.position);

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

            //Enemy within  the detection zone, if the circle radius is bigger than the distance between player and enemy, make the shape red
            if (radius >= dist)
            {

                Debug.DrawLine(start, end, Color.red);
            }

            //Otherwise its green
            else
            {
                Debug.DrawLine(start, end, Color.green);
            }
        }
        // --------------------------------------------------------------


        //....................TASK 2 FUNCTION WORKS HERE FOR JOURNAL 4...........................
        //Journal 4 - task 2
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PowerUpSpawn();
        }

        //j2 - task 1 - part a
        //When b is pressed, run the function and pass it a vector with an offset of 0,1
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }

        //j2 - task 1 - part b
        //When t is pressed, run the function at a loop depending on the number of bomb in the trail
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < numberOfTrailBombs; i++)
            {
                //As the loop runs the function each time, the spacing increases by 1 so the bombs don't overlap
                SpawnBombTrail(bombTrailSpacing++);
            }
        }

        //j2 - task 2
        //When c is pressed, run the random corner function
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner();
        }

        //j2 - task 3
        //When w is pressed, run the warp function with the enemy transform and the moved float passed into it
        if (Input.GetKeyDown(KeyCode.W))
        {
            WarpPlayer(enemyTransform, moved);
        }

        //j2 - task 4
        //When r is held down, run the detect asteroids function that passes in the max range as well as the list of asteroid transforms
        if (Input.GetKey(KeyCode.R))
        {
           DetectAsteroids(maxRange, asteroidTransforms);
        }

        PlayerMovement();
      
       



    }



    //j2 - task 1 - part a
    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        //Spawns a bomb at the players position plus the offset that was passed in through the update function
        Vector3 spawnPosition = transform.position+inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
    //j2 - task 1 - part b
    public void SpawnBombTrail (float spacing)
    {
        //Spawns a bomb at players position - the spacing so they don't overlap. The spacing changes depend on the current number the loop is on
        Vector3 spaced = transform.position - new Vector3(0, spacing);
            Instantiate(bombPrefab, spaced, Quaternion.identity);
    }

    //j2 - task 2
    public void SpawnBombOnRandomCorner()
    {
        //inDistance will be the vector that's added to the players position
        Vector3 inDistance = new Vector3();

        //These are the 4 corners that start at the origin
        Vector3 top = new Vector3(1, 1);
        Vector3 bottom = new Vector3(1, -1);
        Vector3 left = new Vector3(-1, 1);
        Vector3 right = new Vector3(-1, -1);

        //j2 - Pick a number between 1-4 to determine which corner to use
        float number = Random.Range(0, 4);

        if (number == 0)
        {
            inDistance = top;
        }
        else if (number == 1)
        {
            inDistance = bottom;
        }
        else if (number == 2)
        {
            inDistance = left;
        }
        else if (number == 3)
        {
            inDistance = right;
        }

        //Adds players position to give the effect that the bomb is spawned at a random corner of the player
        Vector3 bombCorner = transform.position + inDistance;

        Instantiate(bombPrefab, bombCorner, Quaternion.identity);
    }

    //j2 - task 3
    public void WarpPlayer(Transform target, float ratio)
    {
        //j2 - Randomly chooses the ratio of the warp amount
        float warpAmmount = Random.Range(0, 3);

        if (warpAmmount == 0)
        {
            ratio = 0;
        }
        else if (warpAmmount == 1)
        {
            ratio = 0.5f;
        }
        else if (warpAmmount == 2)
        {
            ratio = 1;
        }

        //Uses lerp to interpolate between player and the target, using the distance of the ratio
        Vector3 warped = Vector3.Lerp(transform.position, target.position, ratio);

        //transforms position of the player by the vector
        transform.position = warped;

        Debug.Log("Ship was warped at a ratio value of: "+ratio);
    }

    //j2 - task 4
    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        //Runs a foreach loop checking all the transforms in the list of asteroids
        foreach (Transform asteroid in inAsteroids)
        {

            //If the distance between the player and the asteroid is less than or equal to the max range, dectect the asteroid using debug.drawline
            if (Vector3.Distance(transform.position, asteroid.position) <= inMaxRange)
            {
                
                Debug.DrawLine(transform.position, asteroid.position, Color.green);
            }
        }
    }
    //j3 - task 1
    public void PlayerMovement()
    {
        //Creates acceleration and deceleration rates
        float accelerationRate = maxSpeed / accelerationTime;
        float decelerationRate = maxSpeed / decelerationTime;
         moving = false;

        //Depending on key pressed for movement, velocity adds acceleration rate along side vector position and time for a gradual increase in speed 

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.up;
            moving = true;
        }

        if ( Input.GetKey(KeyCode.DownArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.down;
            moving = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.left;
            moving = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.right;
            moving = true;
        }

        //Once not moving anymore, deceleration rate is subtracted from velocity for a gradual decrease in speed
        if (moving == false)
        {
            //While velocity is greater than 0, keep decelerating
            if (velocity.magnitude > 0)
            {
                velocity -= decelerationRate * Time.deltaTime * velocity.normalized;

                //Once velocity is 0, set it to 0 so it doesn't go into negative 
                if (velocity.magnitude <=0)
                {
                    velocity = Vector3.zero;
                }
            }
        }
        //Clamp magnitude so velocity doesn't exceed max speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
    }

    //Journal 4 - task 2
    public void PowerUpSpawn()
    {
        //List to store the powerups
        List<Vector3> powerPoints = new List<Vector3>();

        //Runs a loop for each powerup
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            //Convert degrees to radians
            float degrees = 360 / numberOfPowerUps * i;
            float radians = degrees * Mathf.Deg2Rad;

            //assign the x,y values of each power up in the circle through trig functions
            float x = Mathf.Cos(radians) * powerUpRadius;
            float y = Mathf.Sin(radians) * powerUpRadius;

            //Add these points into the list
            powerPoints.Add(new Vector3(x, y, 0));

        }

        //Loop to spawn each powerup in the point in the circle on the list
        for (int i = 0; i < powerPoints.Count; i++)

            
        {
            //Spawns the powerup at the point
            Instantiate(powerUp, powerPoints[i] + transform.position, Quaternion.identity);

        }
    }
    

}