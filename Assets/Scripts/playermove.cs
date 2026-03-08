using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class playermove : MonoBehaviour
{
    public Transform model;

    

    [SerializeField] public float speed = 10f;
    [SerializeField] public float downSpeed = 20f;

    [SerializeField] public float maxTilt = 20f;
    [SerializeField] public float tiltSpeed = 5f;

    float currentTilt;

    private Rigidbody rb;

    private float input_horizontal;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input_horizontal = Input.GetAxis("Horizontal"); 

        float targetTilt = input_horizontal * maxTilt;
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);

        transform.localRotation = Quaternion.Euler(0f, 0f, currentTilt);
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(input_horizontal * speed, 0f, 0f), ForceMode.Force);

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * downSpeed, ForceMode.Force);
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Stick"))
        //{
            //if playerstate == Big
            //{ branch drstroy or something }
        //}

        //else 
        //{
        //    SceneManager.LoadScene("Level");
        //}
    }
}