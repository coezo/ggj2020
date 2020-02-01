﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public char controller;             //Floating point variable to store the player's movement speed.

    private Animator animator;
    private AudioSource source;
    private bool playingWalkingSound;

    private float inputX, inputY;
    private Vector3 movement = new Vector3(0, 0, 0);
    private Vector3 facingDirection = new Vector3(0, 1, 0);

    private bool finalFase = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal" + controller);
        inputY = Input.GetAxisRaw("Vertical" + controller);

        movement = Vector3.zero;

        if (inputX != 0 || inputY != 0)
        {
            animator.SetBool("Walking", true);
            //if (!playingWalkingSound)
            //{
            //    playingWalkingSound = true;
            //    source.Play();
            //}
            if (inputX > 0)
            {
                animator.SetFloat("LastMoveX", inputX);
                animator.SetFloat("LastMoveY", 0f);
                animator.SetFloat("SpeedX", inputX);
                animator.SetFloat("SpeedY", 0);
                facingDirection = new Vector3(inputX, 0, 0);
                movement.x = inputX;
            }
            else if (inputX < 0)
            {
                animator.SetFloat("LastMoveX", inputX);
                animator.SetFloat("LastMoveY", 0f);
                animator.SetFloat("SpeedX", inputX);
                animator.SetFloat("SpeedY", 0);
                facingDirection = new Vector3(inputX, 0, 0);
                movement.x = inputX;
            }
            else if (inputY > 0)
            {
                animator.SetFloat("LastMoveX", 0f);
                animator.SetFloat("LastMoveY", inputY);
                animator.SetFloat("SpeedX", 0);
                animator.SetFloat("SpeedY", inputY);
                facingDirection = new Vector3(0, inputY, 0);
                movement.y = inputY;
            }
            else if (inputY < 0)
            {
                animator.SetFloat("LastMoveX", 0f);
                animator.SetFloat("LastMoveY", inputY);
                animator.SetFloat("SpeedX", 0);
                animator.SetFloat("SpeedY", inputY);
                facingDirection = new Vector3(0, inputY, 0);
                movement.y = inputY;
            }
            else
            {
                animator.SetFloat("SpeedX", 0);
                animator.SetFloat("SpeedY", 0);
            }
        }
        else
        {
            animator.SetBool("Walking", false);
            //source.Stop();
            playingWalkingSound = false;
        }

    }

    public bool IsMoving()
    {
        return inputX != 0 || inputY != 0;
    }
}
