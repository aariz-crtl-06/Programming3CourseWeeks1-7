using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class normalized : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(normalizedValue(new Vector3(3, 4)));
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    Vector2 normalizedValue(Vector2 input)
    {
        Vector3 normalized;

        float magnitude = input.magnitude;

        normalized = new Vector2(input.x / magnitude, input.y / magnitude);
        return normalized;
    }
}
