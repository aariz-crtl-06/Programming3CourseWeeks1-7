using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime = 1f;




    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        StartCoroutine(drawing());
    }

    private IEnumerator drawing()
    {
        for (int i = 0; i < starTransforms.Count; i++)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.white, drawingTime);
            yield return new WaitForSeconds(drawingTime);
        }
    }
}
