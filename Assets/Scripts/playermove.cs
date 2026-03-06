using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;

    private SkinnedMeshRenderer smr;

    //public Transform lookTarget;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        smr = GetComponent<SkinnedMeshRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    void Update()
    {
        //transform.LookAt(lookTarget);

        //Vector3 difference = lookTarget.position - transform.position;
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);

        //transform.Rotate(0f, 180f, 0f, Space.Self);

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
