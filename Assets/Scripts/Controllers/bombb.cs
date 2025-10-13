using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class bombb : MonoBehaviour
{
    public Transform shipTransform;

    public float rotateSpeed = 50;

    public int rotateRadius = 2;

    float angle;

    bool runs = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(runs == true)
        {
            angle += rotateSpeed * Time.deltaTime;

            //Converts the angle degrees into radians
            float radians = angle * Mathf.Deg2Rad;

            //Uses trig functions to set each point along the ship
            float x = Mathf.Cos(radians) * rotateRadius;
            float y = Mathf.Sin(radians) * rotateRadius;

            //Sets the position so the bomb keeps moving along the ship rotation, no matter where it is
            transform.position = new Vector3(x, y, 0) + shipTransform.position;
        }
    }

    //Checks if the players tag collides, then runs the bool to make the rotation start
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            runs = true;

        }

    }

}
