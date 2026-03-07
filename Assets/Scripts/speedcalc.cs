using UnityEngine;

public class speedCalc : MonoBehaviour
{
    public float speedDown = 0f;
    public float speedRight = 0f;
    public float speedLeft = 0f;
    Vector3 lastPosition = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedDown = lastPosition.y - transform.position.y;
        speedRight = transform.position.x - lastPosition.x;
        lastPosition = transform.position;
    }
}
