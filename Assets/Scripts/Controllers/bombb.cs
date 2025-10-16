using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class bombb : MonoBehaviour
{
    public Transform shipTransform;

    public float rotateSpeed = 50;

    public int rotateRadius = 2;

    float angle;

    bool runs = false;

    float rotationOffset;

    void Start()
    {
        //Gets the offset of the bomb to the ship, then collects the angle difference
           Vector3 offset = transform.position - shipTransform.position;
           rotationOffset = Mathf.Atan2(offset.y, offset.x);
    }

    // Update is called once per frame
    void Update()
    {
        //Activates magnet
      if(runs == true && Input.GetKey(KeyCode.M))
        {
            angle += rotateSpeed * Time.deltaTime;

            //Converts the angle degrees into radians and adds the offset so that the bomb gets attached at the same angle
            float radians = (angle * Mathf.Deg2Rad) + rotationOffset;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            runs = false;
        }
    }

}
