using UnityEngine;
using System.Collections; 

public class Droplet : MonoBehaviour
{
    public float immunityTime = 0.5f; 
    private bool canBeDestroyed = false;

    private void Start()
    {
        
        StartCoroutine(EnableDestruction());
    }

    IEnumerator EnableDestruction()
    {
        yield return new WaitForSeconds(immunityTime);
        canBeDestroyed = true;
    }

    public bool IsDestructible()
    {
        return canBeDestroyed;
    }
}