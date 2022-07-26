using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FlappyBird
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        float screenTop = Screen.height;
        public int score;
        public bool isDead;

        private Touch touch;

        Rigidbody2D rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            TouchInput();
        }

        void TouchInput()
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                touch = Input.GetTouch(0);

                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        rb.velocity = Vector2.up * jumpForce;
                        if(transform.position.y == screenPos.y)
                        {
                            Debug.Log("Toccato in alto");
                        }
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
