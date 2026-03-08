using UnityEngine;


public class DropletCollector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Droplet"))
        {
            Droplet droplet = collision.gameObject.GetComponent<Droplet>();
            if (droplet != null && droplet.IsDestructible())
                Destroy(collision.gameObject);

            PlayerStateController stateController = GetComponent<PlayerStateController>();
            if (stateController != null)
                stateController.OnCollectDroplet();
        }
    }

}