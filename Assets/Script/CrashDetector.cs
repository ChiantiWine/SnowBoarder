using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!hasCrashed && other.CompareTag("Ground"))
        {
            Debug.Log("Ouch");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            FindAnyObjectByType<PlayerController>().DisableControls();
            Invoke("roadScene", loadDelay); 
            hasCrashed = true;          
        }    
    }

    void roadScene()
    {
         SceneManager.LoadScene(0);
    }

}
