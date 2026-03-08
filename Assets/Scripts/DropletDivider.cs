using UnityEngine;
using System.Collections;

public class DropletDivider : MonoBehaviour
{
    public GameObject dropletPrefab;
    public float splitForce = 10f;
    public float splitOffset = 0.5f;
    public float cooldown = 2f;

    private bool canDivide = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canDivide) return;
        if (!other.CompareTag("Player")) return;

        
        Rigidbody rb = other.GetComponentInParent<Rigidbody>();
        if (rb == null) return;

        canDivide = false;

        Vector3 pos = rb.transform.position;

        // Move original left
        rb.transform.position = pos + Vector3.left * splitOffset;

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
        rb.AddForce(Vector3.left * splitForce, ForceMode.Impulse);

        if (newRB != null)
            newRB.AddForce(Vector3.right * splitForce, ForceMode.Impulse);

        StartCoroutine(DivideCooldown());
    }

    IEnumerator DivideCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canDivide = true;
    }
}