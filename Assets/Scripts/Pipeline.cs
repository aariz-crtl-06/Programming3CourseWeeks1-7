using UnityEngine;

public class Pipeline : MonoBehaviour
{
    //This is to track the mouse position and convert it from screen space to world space
    public Vector2 screenPos;
    public Vector2 worldPos;

    //Track the mouse previous location
    public Vector2 prevLocation;

    //magnitude number
    public float num;
    //timer
    public float t;
    void Start()
    {
        
    }

    void Update()
    {
        

        //This stores the mouse position
        screenPos = Input.mousePosition;

        //Using the camera, the screen position of the mouse can be tracked in world space
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        //Once the mouse clicked, the previous location is stored
        if (Input.GetMouseButtonDown(0))
        {
            prevLocation = worldPos;
            t = 0;
        }
        //While held down, timer begins
        if (Input.GetMouseButton(0) )
        {
            t += Time.deltaTime;
        }
        //While still being held, timer resets every 0.1 seconds and draws a line from the last position of the mouse to where it is now
        if(Input.GetMouseButton(0) && t >=0.1f)
        {
            Debug.DrawLine(prevLocation, worldPos, Color.red);
            prevLocation = worldPos;
            t -= 0.1f;

        }

        //Once the mouse is released, the timer resets and the magnitude from the previous postion to now is calculated
        if (Input.GetMouseButtonUp(0))
        {
            t = 0;
            num = Mathf.Sqrt(Mathf.Pow((worldPos.x - prevLocation.x), 2) + Mathf.Pow((worldPos.y - prevLocation.y), 2));

            Debug.Log("Magnitude: " + num);
        }

    }
}
