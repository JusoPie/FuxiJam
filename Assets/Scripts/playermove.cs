using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour
{
    public Transform model;

    [SerializeField] public float speed = 10f;

    [SerializeField] public float maxTilt = 20f;
    [SerializeField] public float tiltSpeed = 5f;

    float currentTilt;

    private Rigidbody rb;

    private float input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal"); // A/D

        float targetTilt = input * maxTilt;
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);

        transform.localRotation = Quaternion.Euler(0f, 0f, currentTilt);
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(input * speed, 0f, 0f), ForceMode.Force);
    }
}