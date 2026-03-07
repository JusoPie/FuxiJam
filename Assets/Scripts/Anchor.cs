using UnityEngine;

public class Anchor : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;

    [SerializeField] private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = playerTrans.position + offset;

        if (Input.GetKey(KeyCode.A))
        {
            
        }

        if (Input.GetKey(KeyCode.S))
        {
           
        }

        if (Input.GetKey(KeyCode.D))
        {
            
        }
    }
}
