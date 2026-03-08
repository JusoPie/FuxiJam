using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateController : MonoBehaviour
{
    public GameObject branch;

    public enum PlayerState { Small, Normal, Big }
    public PlayerState currentState = PlayerState.Normal;

    public int splitCount = 0;
    public int maxSplits = 2;

    public Vector3 smallScale = new Vector3(0.5f, 0.5f, 1f);
    public Vector3 normalScale = new Vector3(1f, 1f, 1f);
    public Vector3 bigScale = new Vector3(1.5f, 1.5f, 1f);

    // Damping values (bigger = faster)
    public float smallDamping = 6f;
    public float normalDamping = 4f;
    public float bigDamping = 2f;

    private Rigidbody rb;

    private bool canCollect = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScale();
    }

    public void OnSplit()
    {
        Debug.Log("OnSplit called. Current splitCount: " + splitCount);

        splitCount++;

        if (splitCount >= maxSplits)
        {
            GameOver();
            return;
        }

        UpdateScale();
        StartCoroutine(CollectCooldown());
    }

    private IEnumerator CollectCooldown()
    {
        canCollect = false;
        yield return new WaitForSeconds(1f);
        canCollect = true;
    }

    public void OnCollectDroplet()
    {
        if (!canCollect) return;

        splitCount--;

        if (splitCount < -1)
            splitCount = -1;

        UpdateScale();
    }

    private void UpdateScale()
    {
        switch (splitCount)
        {
            case -1:
                currentState = PlayerState.Big;
                transform.localScale = bigScale;
                rb.linearDamping = bigDamping;
                break;

            case 0:
                currentState = PlayerState.Normal;
                transform.localScale = normalScale;
                rb.linearDamping = normalDamping;
                break;

            case 1:
                currentState = PlayerState.Small;
                transform.localScale = smallScale;
                rb.linearDamping = smallDamping;
                break;
        }

        Debug.Log("State: " + currentState + " | Damping: " + rb.linearDamping);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canCollect) return;

        if (other.CompareTag("Droplet"))
        {
            OnCollectDroplet();
            Destroy(other.gameObject);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("Level");
    }
}