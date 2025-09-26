using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//task 3
public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    
    void Update()
    {
        //Run the movment function

        AsteroidMovement();

        //Once the asteroid reaches the max arrival distance, it runs the function again to give a new direction
        if(transform.position.magnitude <= arrivalDistance)
        {
            AsteroidMovement();
        }
    }

    public void AsteroidMovement()
    {
        //Picks a random direction on the x and y axis, normalises it so that it is always 1 in length to not mess up magnitude
        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;

        //Uses move towards to move the asteroid in a random direction with the max distance, using speed and time for a smooth movement
        transform.position = Vector3.MoveTowards(transform.position, randomDir * maxFloatDistance, moveSpeed * Time.deltaTime);
    }
}
