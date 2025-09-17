using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public float numberOfTrailBombs = 3;
    public int bombTrailSpacing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < numberOfTrailBombs; i++)
            {
                SpawnBombTrail(bombTrailSpacing++);
            }
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {

        Vector3 spawnPosition = transform.position+inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnBombTrail (float spacing)
    {
            Vector3 spaced = transform.position - new Vector3(0, spacing);
            Instantiate(bombPrefab, spaced, Quaternion.identity);
    }
}
