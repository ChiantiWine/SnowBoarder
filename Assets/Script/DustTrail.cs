using UnityEngine;

public class DustTrail : MonoBehaviour
{
   [SerializeField] ParticleSystem dustParticle;

  void OnCollisionEnter2D(Collision2D other) 
  {
    if(other.collider.CompareTag("Ground"))
    {
        dustParticle.Play();
    }
  }

  void OnCollisionExit2D(Collision2D other) 
  {
    if(other.collider.CompareTag("Ground"))
    {
        dustParticle.Stop();
    }
  }
}
