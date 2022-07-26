using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FlyingFurry
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        public int score;
        public bool isDead;

        private Touch touch;
        Rigidbody2D rb;
        Animator animator;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            TouchInput();
        }

        void TouchInput()
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        rb.velocity = Vector2.up * jumpForce;
                        animator.SetTrigger("Jump");
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Death"))
            {
                isDead = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("ScorePoint"))
            {
                score++;
            }
        }
    }
}
