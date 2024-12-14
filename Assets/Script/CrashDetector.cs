using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip crashSFX;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log("Ouch");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("roadScene", loadDelay);
            
        }    
    }

    void roadScene()
    {
         SceneManager.LoadScene(0);
    }

}
