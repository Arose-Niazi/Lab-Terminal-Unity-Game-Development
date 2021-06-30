using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        
        gameObject.SetActive(false);
        Invoke(nameof(ReActive), 5f);
    }
    
    private void ReActive()
    {
        gameObject.SetActive(true);
    }
}
