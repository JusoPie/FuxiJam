using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 zoomedOutOffset;
    public float zoom = 0;
    private Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {
        Vector3 currentOffset = Vector3.Lerp(offset, zoomedOutOffset, zoom); // For zooming out the camera when you get a speed boost or something
        Vector3 desiredPosition = target.position + currentOffset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
    }
}
