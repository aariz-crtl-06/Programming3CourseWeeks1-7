using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//task 4
public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime = 1f;

    
    private void Start()
    {
        //Runs at beginning of code
        DrawConstellation();
    }


    void Update()
    {
    }

    //Runs the function to start a coroutine
    public void DrawConstellation()
    {
        StartCoroutine(drawing());
    }

    //Runs a coroutine so that seconds still work within a loop
    private IEnumerator drawing()
    {
        //while true so that it always loops once completed
        while (true) { 
            //starTransforms.count-1 because of error that exceeds index limit
        for (int i = 0; i < starTransforms.Count-1; i++)
        {
                //Draws a line from the first star to the next, which is white and waits for time
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.white, drawingTime);
            yield return new WaitForSeconds(drawingTime);
        }
    }
    }
}
