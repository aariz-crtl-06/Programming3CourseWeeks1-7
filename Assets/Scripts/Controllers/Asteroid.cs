using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        AsteroidMovement();

        if(transform.position.magnitude <= arrivalDistance)
        {
            AsteroidMovement();
        }
    }

    public void AsteroidMovement()
    {
        Vector3 randomDir= new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;


        transform.position = Vector3.MoveTowards(transform.position, randomDir * maxFloatDistance, moveSpeed * Time.deltaTime);
    }
}
