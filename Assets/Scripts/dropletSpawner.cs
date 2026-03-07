using Unity.Mathematics;
using UnityEngine;

public class dropletSpawner : MonoBehaviour
{

    [Header("Settings")]
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public float minPos;
    public float maxPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = spawnPos.x + UnityEngine.Random.Range(minPos, maxPos);


        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.Euler(-90, 0, 0));

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
    }

}
