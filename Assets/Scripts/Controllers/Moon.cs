using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    public float rotateSpeed = 50;

    public int rotateRadius =2;

    float angle;

    void Start()
    {
        
    }

    void Update()
    {
        //Journal 4 - task 3

        //Makes the moon contstantly rotate as time passes
        angle += rotateSpeed * Time.deltaTime;

        //Converts the angle degrees into radians
        float radians = angle * Mathf.Deg2Rad;

       //Uses trig functions to set each point along the planet
        float x = Mathf.Cos(radians) * rotateRadius;
        float y = Mathf.Sin(radians) * rotateRadius;

       //Sets the position so the moon keeps moving along the planet, no matter where it is
        transform.position = new Vector3(x, y, 0) + planetTransform.position;
    }
}
