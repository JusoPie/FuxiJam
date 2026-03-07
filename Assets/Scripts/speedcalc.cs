using UnityEngine;

public class speedCalc : MonoBehaviour
{
    public float speedDown = 0f;
    public float speedSideways = 0f;

    public string speedSidewaysName = "SpeedSideways";
    public string speedDownName = "SpeedDown";

    [SerializeField] private float animSpeedModifier = 4f;

    Vector3 lastPosition = Vector3.zero;
    Quaternion targetRotation;

    [Header("Settings")]
    public Animator animator;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        speedDown = lastPosition.y - transform.position.y;
        speedSideways = transform.position.x - lastPosition.x;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(speedSidewaysName, speedSideways * animSpeedModifier);
        animator.SetFloat(speedDownName, speedDown * animSpeedModifier);
    }
}
