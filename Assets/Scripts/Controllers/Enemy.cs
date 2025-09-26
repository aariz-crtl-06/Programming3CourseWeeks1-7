using UnityEngine;
using System.Collections;
using Unity.VisualScripting.ReorderableList;

//task 2
public class Enemy : MonoBehaviour
{
    //Getting access to both player object and player script
    public GameObject player;
    Player ship;

    //Vector to track players last position
    Vector3 playerLastPos;

    private void Start()
    {
        //Assigning player script to ship variable
        ship = player.GetComponent<Player>();
        //Starting position of player is given to enemy
        playerLastPos = player.transform.position;

    }

    private void Update()
    {
        //Runs movement function in update
        EnemyMovement();

    }

    public void EnemyMovement()
    {
        //If the player has moved and is not moving, update enemies position to the players last position. This gives the player space to move

        if (player.transform.position != playerLastPos && ship.moving == false) 
        { 
        playerLastPos = player.transform.position;
    }

        //Use move towards to move the enemy to the players last position, using speed and time for a smooth movement
        transform.position = Vector3.MoveTowards(transform.position, playerLastPos, ship.maxSpeed * Time.deltaTime);
    }

}
