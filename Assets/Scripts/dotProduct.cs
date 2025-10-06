using UnityEngine;

public class dotProduct : MonoBehaviour
{

    //degrees
    public float redAngle = 30;
    public float blueAngle = 60;

    float product;
    void Start()
    {
        
    }

    void Update()
    {
        //we need to make these radians

        float redRadian = Mathf.Deg2Rad * redAngle;
        float blueRadian = Mathf.Deg2Rad * blueAngle;

        float x = Mathf.Cos(redRadian);
        float y = Mathf.Sin(redRadian);

        float x2 = Mathf.Cos(blueRadian);
        float y2 = Mathf.Sin(blueRadian);

        Vector2 vec1 = new Vector2(x, y);
        Vector2 vec2 = new Vector2(x2, y2);

        Debug.DrawLine(Vector2.zero, vec1, Color.red);
        Debug.DrawLine(Vector2.zero, vec2, Color.green);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            product = x * x2 + y * y2;
            Debug.Log(product);
        }

    }
}
