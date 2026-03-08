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

        PlayerStateController stateController = rb.GetComponent<PlayerStateController>();
        if (stateController != null)
            stateController.OnSplit();

        //left or right 
        float directionX = Mathf.Sign(pos.x - transform.position.x);

        Vector3 mainDir = new Vector3(directionX, 0, 0);
        Vector3 oppositeDir = new Vector3(-directionX, 0, 0);

        rb.transform.position = pos + mainDir * splitOffset;

        GameObject newDrop = Instantiate(
            dropletPrefab,
            pos + oppositeDir * splitOffset,
            other.transform.rotation
        );

        Rigidbody newRB = newDrop.GetComponent<Rigidbody>();

        
        playermove control = newDrop.GetComponent<playermove>();
        if (control != null)
            control.enabled = false;

        
        rb.AddForce(mainDir * splitForce, ForceMode.Impulse);

        if (newRB != null)
            newRB.AddForce(oppositeDir * splitForce, ForceMode.Impulse);

        StartCoroutine(DivideCooldown());
    }

    IEnumerator DivideCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canDivide = true;
    }
}