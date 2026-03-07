using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour
{
    public Transform model;

    [SerializeField] public float speed = 10f;

    public float maxTilt = 20f;
    public float tiltSpeed = 5f;

    float currentTilt;

    private Rigidbody rb;


    //public Transform lookTarget;

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
        float input = Input.GetAxis("Horizontal"); // A/D

        float targetTilt = -input * maxTilt;

        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);

        transform.localRotation = Quaternion.Euler(0f, 0f, currentTilt);
    }


}
