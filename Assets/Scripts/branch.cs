using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class branch : MonoBehaviour
{
    public GameObject Branch1;
    public GameObject Branch2;

    private PlayerStateController playerScript;

    float brokenRotation = 90f;
    float desiredRotation = 0f;

    private Rigidbody rb1;
    private Rigidbody rb2;

    bool breakBranch = false;

    void Start()
    {
        // Find player script
        playerScript = FindFirstObjectByType<PlayerStateController>();

        // Get rigidbodies from assigned branch pieces
        rb1 = Branch1.GetComponent<Rigidbody>();
        rb2 = Branch2.GetComponent<Rigidbody>();

        if (rb1 != null)
        {
            rb1.useGravity = false;
            rb1.isKinematic = true;
        }

        if (rb2 != null)
        {
            rb2.useGravity = false;
            rb2.isKinematic = true;
        }
    }

    void Update()
    {
        if (breakBranch && desiredRotation != brokenRotation)
        {
            desiredRotation = Mathf.Lerp(desiredRotation, brokenRotation, Time.deltaTime * 7f);
            BreakBranch();

            if (Mathf.Abs(brokenRotation - desiredRotation) < 0.5f)
            {
                desiredRotation = brokenRotation;
                EnablePhysics();
            }
        }
    }

    void BreakBranch()
    {
        if (Branch1 != null)
        {
            Branch1.transform.localRotation = Quaternion.Euler(-90 + desiredRotation, 0, 0);
        }

        if (Branch2 != null)
        {
            Branch2.transform.localRotation = Quaternion.Euler(-90 - desiredRotation, 0, 180);
        }
    }

    async Task EnablePhysics()
    {
        if (rb1 != null)
        {
            rb1.useGravity = true;
            rb1.isKinematic = false;
        }

        if (rb2 != null)
        {
            await Task.Delay(300);
            rb2.useGravity = true;
            rb2.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only react to player
        if (!other.CompareTag("Player"))
            return;

        // If already broken, do nothing
        if (breakBranch)
            return;

        if (playerScript.currentState == PlayerStateController.PlayerState.Big && Input.GetKey(KeyCode.S))
        {
            Debug.Log("Branch can break");
            breakBranch = true;
        }
        else
        {
            SceneManager.LoadScene("Level");
        }
    }
}