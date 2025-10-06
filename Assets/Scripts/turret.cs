using UnityEngine;
using UnityEngine.UIElements;

public class turret : MonoBehaviour
{
    public float angularSpeed = 180f;

    public Transform target;
    void Start()
    {
        
    }

    void Update()
    {

       

        Vector3 directionToTarget = (target.position - transform.position).normalized;

        float upAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;
        float directionAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(upAngle, directionAngle);

        Debug.Log(deltaAngle);

       

        float dot = Vector3.Dot(transform.up, directionToTarget);
        float sign = Mathf.Sign(deltaAngle);

        if (Mathf.Abs(dot) < 0.999f)
        {
            transform.Rotate(0, 0, angularSpeed * Time.deltaTime * sign);
        }

        if (dot < 0)
        {
            Debug.Log("Behind");
        }

        else if (dot > 0)
        {
            Debug.Log("In front");
        }


        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);
        Debug.DrawLine(transform.position, transform.position + directionToTarget, Color.magenta);

    }
}
