using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public float numberOfTrailBombs = 3;
    public int bombTrailSpacing;
    float moved = 0;

    float maxRange = 2.5f;

    [Header("MotionProperties")]
    public float maxSpeed = 5;
    Vector3 velocity;
    float accelerationTime = 2;

    // Update is called once per frame
    void Update()
    {

        //task 1 - part a
        //When b is pressed, run the function and pass it a vector with an offset of 0,1
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }

        //task 1 - part b
        //When t is pressed, run the function at a loop depending on the number of bomb in the trail
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < numberOfTrailBombs; i++)
            {
                //As the loop runs the function each time, the spacing increases by 1 so the bombs don't overlap
                SpawnBombTrail(bombTrailSpacing++);
            }
        }

        //task 2
        //When c is pressed, run the random corner function
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner();
        }

        //task 3
        //When w is pressed, run the warp function with the enemy transform and the moved float passed into it
        if (Input.GetKeyDown(KeyCode.W))
        {
            WarpPlayer(enemyTransform, moved);
        }

        //task 4
        //When r is held down, run the detect asteroids function that passes in the max range as well as the list of asteroid transforms
        if (Input.GetKey(KeyCode.R))
        {
           DetectAsteroids(maxRange, asteroidTransforms);
        }

        PlayerMovement();
         
    }



    //task 1 - part a
    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        //Spawns a bomb at the players position plus the offset that was passed in through the update function
        Vector3 spawnPosition = transform.position+inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
    //task 1 - part b
    public void SpawnBombTrail (float spacing)
    {
        //Spawns a bomb at players position - the spacing so they don't overlap. The spacing changes depend on the current number the loop is on
        Vector3 spaced = transform.position - new Vector3(0, spacing);
            Instantiate(bombPrefab, spaced, Quaternion.identity);
    }

    //task 2
    public void SpawnBombOnRandomCorner()
    {
        //inDistance will be the vector that's added to the players position
        Vector3 inDistance = new Vector3();

        //These are the 4 corners that start at the origin
        Vector3 top = new Vector3(1, 1);
        Vector3 bottom = new Vector3(1, -1);
        Vector3 left = new Vector3(-1, 1);
        Vector3 right = new Vector3(-1, -1);

        //Pick a number between 1-4 to determine which corner to use
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

    //task 3
    public void WarpPlayer(Transform target, float ratio)
    {
       //Randomly chooses the ratio of the warp amount
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

    //task 4
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

    public void PlayerMovement()
    {
        float accelerationRate = maxSpeed / accelerationTime;

        //velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.up;
        }

        if ( Input.GetKey(KeyCode.DownArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += accelerationRate * Time.deltaTime * Vector3.right;
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity*Time.deltaTime;
    }

}