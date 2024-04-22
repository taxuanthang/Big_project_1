using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        private Animator animator;


        public void move()
        {
            
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                this.GetComponentInChildren<CircleCollider2D>().gameObject.transform.localPosition =  new Vector3 (-0.4f,0.4f,0f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
                this.GetComponentInChildren<CircleCollider2D>().gameObject.transform.localPosition = new Vector3(0.4f, 0.4f, 0f);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                this.GetComponentInChildren<CircleCollider2D>().gameObject.transform.localPosition = new Vector3(0f, 0.8f, 0f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                this.GetComponentInChildren<CircleCollider2D>().gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            move();
        }
    }
}
