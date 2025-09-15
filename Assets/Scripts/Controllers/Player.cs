using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0,1));
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {

        Vector3 spawnPosition = transform.position+inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }
}
