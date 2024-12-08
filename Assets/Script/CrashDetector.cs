using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 1f;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log("Ouch");
            crashEffect.Play();
            Invoke("roadScene", loadDelay);
            
        }    
    }

    void roadScene()
    {
         SceneManager.LoadScene(0);
    }

}
