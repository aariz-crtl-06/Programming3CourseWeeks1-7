using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    public float rotateSpeed = 50;

    public int rotateRadius =2;

    float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += rotateSpeed * Time.deltaTime;

        
        float radians = angle * Mathf.Deg2Rad;

       
        float x = Mathf.Cos(radians) * rotateRadius;
        float y = Mathf.Sin(radians) * rotateRadius;

       
        transform.position = new Vector3(x, y, 0) + planetTransform.position;
    }
}
