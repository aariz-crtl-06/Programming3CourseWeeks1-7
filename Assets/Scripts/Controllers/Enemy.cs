using UnityEngine;
using System.Collections;
using Unity.VisualScripting.ReorderableList;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    Player ship;

    Vector3 playerLastPos;

    private void Start()
    {
        ship = player.GetComponent<Player>();
        playerLastPos = player.transform.position;

    }

    private void Update()
    {
        EnemyMovement();

    }

    public void EnemyMovement()
    {


        if (player.transform.position != playerLastPos && ship.moving == false) 
        { 
        playerLastPos = player.transform.position;
    }


        transform.position = Vector3.MoveTowards(transform.position, playerLastPos, ship.maxSpeed * Time.deltaTime);
    }

}
