using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayerStateController : MonoBehaviour
{
    public enum PlayerState
    {
        Small,
        Normal,
        Big
    }

    public PlayerState currentState = PlayerState.Normal;
    public int splitCount = 0; 
    public int maxSplits = 2; 

    public Vector3 smallScale = new Vector3(0.5f, 0.5f, 1f);
    public Vector3 normalScale = new Vector3(1f, 1f, 1f);
    public Vector3 bigScale = new Vector3(1.5f, 1.5f, 1f);

    private void Start()
    {
        UpdateScale();
    }

    public void OnSplit()
    {
        splitCount++;

        // First split → small
        if (splitCount == 1)
        {
            currentState = PlayerState.Small;
            UpdateScale();
        }
        // Second split → game over
        else if (splitCount >= maxSplits)
        {
            GameOver();
        }
    }

    public void OnCollectDroplet()
    {
        //if (currentState == PlayerState.Big)
        //{ return; }

        splitCount--;

        if (currentState == PlayerState.Normal)
        {
            currentState = PlayerState.Big;
        }
        else if (currentState == PlayerState.Small)
        {
            currentState = PlayerState.Normal;
        }

        UpdateScale();
    }

    private void UpdateScale()
    {
        //if (currentState == PlayerState.Big)
        //{ return; }

        switch (currentState)
        {
            case PlayerState.Small:
                transform.localScale = smallScale;
                break;
            case PlayerState.Normal:
                transform.localScale = normalScale;
                break;
            case PlayerState.Big:
                transform.localScale = bigScale;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Droplet")) 
        {
            SceneManager.LoadScene("Level");
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("Level");

    }
}