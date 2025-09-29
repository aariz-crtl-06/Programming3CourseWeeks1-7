using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class circle : MonoBehaviour
{
    public float radius = 1f;
    public Vector3 circleCenter = Vector3.zero;

    public List<float> angles = new List<float>();
    public int numOfAngles = 10;

    float elapsedTime;

    public float drawDuration = 1;

    int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < numOfAngles; i++)
        {
            angles.Add(Random.value * 360f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || elapsedTime > drawDuration)
        {
            currentIndex = (currentIndex + 1) % numOfAngles;

        }

            float angleInRadians = angles[currentIndex] * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleInRadians);
            float y = Mathf.Sin(angleInRadians);

            Vector3 endPoint = new Vector3(x, y, 0) * radius;

            Debug.DrawLine(circleCenter, circleCenter + endPoint, Color.green);

        }
    
}
