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

    // Update is called once per frame
    void Update()
    {

        //task 1 - part a
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }

        //task 1 - part b
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < numberOfTrailBombs; i++)
            {
                SpawnBombTrail(bombTrailSpacing++);
            }
        }

        //task 2
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner();
        }

        //task 3
        if (Input.GetKeyDown(KeyCode.W))
        {
            WarpPlayer(enemyTransform, moved);
        }

        //task 4
        if (Input.GetKey(KeyCode.R))
        {
           DetectAsteroids(maxRange, asteroidTransforms);
        }
    }



    //task 1 - part a
    public void SpawnBombAtOffset(Vector3 inOffset)
    {

        Vector3 spawnPosition = transform.position+inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
    //task 1 - part b
    public void SpawnBombTrail (float spacing)
    {
            Vector3 spaced = transform.position - new Vector3(0, spacing);
            Instantiate(bombPrefab, spaced, Quaternion.identity);
    }

    //task 2
    public void SpawnBombOnRandomCorner()
    {
        Vector3 inDistance = new Vector3();

        Vector3 top = new Vector3(1, 1);
        Vector3 bottom = new Vector3(1, -1);
        Vector3 left = new Vector3(-1, 1);
        Vector3 right = new Vector3(-1, -1);

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

        Vector3 bombCorner = transform.position + inDistance;

        Instantiate(bombPrefab, bombCorner, Quaternion.identity);
    }

    //task 3
    public void WarpPlayer(Transform target, float ratio)
    {
        

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

        Vector3 warped = Vector3.Lerp(transform.position, target.position, ratio);

        transform.position = warped;

        Debug.Log("Ship was warped at a ratio value of: "+ratio);
    }

    //task 4
    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        
        foreach (Transform asteroid in inAsteroids)
        {
           

            if (Vector3.Distance(transform.position, asteroid.position) <= inMaxRange)
            {
                
                Debug.DrawLine(transform.position, asteroid.position, Color.green);
            }
        }
    }

}