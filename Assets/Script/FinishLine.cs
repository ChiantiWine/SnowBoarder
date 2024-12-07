using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay = 1f;
    bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!hasTriggered && other.CompareTag("Player"))
        Debug.Log("Win");
       Invoke("roadScene", finishDelay);
        hasTriggered = true;
    }

    void roadScene()
    {
         SceneManager.LoadScene(0);
    }
}
