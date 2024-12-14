using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    // [SerializeField] float jumpForce = 50f;
    bool canMove = true;
    Rigidbody2D rd2d;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        // 수정하기기
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
        RotatePlayer();
        RespondToBoost();
        // Jump();
        }
    }

    public void DisableControls()
    {
       canMove = false;
    }

    void RespondToBoost()
    {
        // 화상표 위 -> 스피드 증가
        // 안눌렀을 때는 기본 스피드
        float boostSpeedInput = Input.GetKey(KeyCode.UpArrow) ? 1 : 0;
        if(boostSpeedInput != 0)
        {
            surfaceEffector2D.speed = boostSpeed;
           // Debug.Log("Boost");
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

   void RotatePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            rd2d.AddTorque(torqueAmount * horizontalInput);
        }
    }

    // void Jump()
    //  {
    //      // Y축 속도가 거의 0일 때만 점프하도록 조건 설정
    //      if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         rd2d.AddRelativeForceX(jumpForce);     // 점프 힘 추가
    //     }
    // }
    
}
