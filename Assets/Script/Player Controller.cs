using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float jumpForce = 50f;
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
        
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
           Debug.Log("Jump");
        }
    }
    void Jump()
    {
        // Y축 속도가 거의 0일 때만 점프하도록 조건 설정
        if (Mathf.Abs(rd2d.linearVelocityY) < 0.01f)
        {
            rd2d.AddForce(new UnityEngine.Vector2(0, jumpForce), ForceMode2D.Impulse); // 점프 힘 추가
        }
    }
    
}
