using UnityEngine;
using UnityEngine.Rendering;

public class dotProdProf : MonoBehaviour
{
    public float redAngle = 60f;
    public float blueAngle = 30f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 redVector = VectorFromDegAngle(redAngle);
        Vector2 blueVector = VectorFromDegAngle(blueAngle);


        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.cyan);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dot = DotProduct(redVector, blueVector);
            Debug.Log($"<color=yellow><size=16>{dot}</size></color>");
        }

        float DotProduct(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        Vector2 VectorFromDegAngle(float angle)
        {
            float angleInRad = Mathf.Deg2Rad * angle;
            return new Vector2(Mathf.Cos(angleInRad), Mathf.Sin(angleInRad));
        }
    }
}
