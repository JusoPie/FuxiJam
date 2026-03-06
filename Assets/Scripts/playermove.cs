using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector2.up * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }
    }
}
