using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rd2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput != 0)
        {
            rd2d.AddTorque(torqueAmount * horizontalInput);
        }
    }
}
