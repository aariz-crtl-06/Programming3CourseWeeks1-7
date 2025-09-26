using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime = 1f;


    private void Start()
    {
        DrawConstellation();
    }


    void Update()
    {
    }

    public void DrawConstellation()
    {
        StartCoroutine(drawing());
    }

    private IEnumerator drawing()
    {

        while (true) { 
        for (int i = 0; i < starTransforms.Count-1; i++)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.white, drawingTime);
            yield return new WaitForSeconds(drawingTime);
        }
    }
    }
}
