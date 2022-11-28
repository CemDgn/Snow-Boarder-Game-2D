using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float speedBoost = 25f;
    [SerializeField] float baseSpeed = 13.5f;
    [SerializeField] float torqueMounth = 1f;

    Rigidbody2D rigidbody2D;

    bool canMove = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    
    void Update()
    {
        if (canMove == true)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    private void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = speedBoost;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.AddTorque(torqueMounth);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.AddTorque(-torqueMounth);
        }
    }

    public void disableControl()
    {
        canMove = false;
    }
}
