using UnityEngine;

public class DropletDivider : MonoBehaviour
{
    public GameObject dropletPrefab;
    public float splitForce = 10f;
    public float splitOffset = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            Vector3 pos = other.transform.position;

            // Move original slightly left
            other.transform.position = pos + Vector3.left * splitOffset;

            // Spawn second droplet slightly right
            GameObject newDrop = Instantiate(
                dropletPrefab,
                pos + Vector3.right * splitOffset,
                other.transform.rotation
            );

            Rigidbody newRB = newDrop.GetComponent<Rigidbody>();

            // Disable control
            playermove control = newDrop.GetComponent<playermove>();
            if (control != null)
                control.enabled = false;

            // Push apart
            rb.AddForce(Vector3.left * 5f, ForceMode.Impulse);
            newRB.AddForce(Vector3.right * 5f, ForceMode.Impulse);
        }
    }
}