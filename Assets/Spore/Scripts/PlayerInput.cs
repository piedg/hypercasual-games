using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(inputX, inputY).normalized;

        rb.velocity = new Vector2(input.x * speed, input.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Food"))
        {
            transform.localScale += new Vector3(0.01f, 0.01f);
            speed -= 0.1f;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Malus"))
        {
            transform.localScale -= new Vector3(0.01f, 0.01f);
            speed += 0.1f;
            Destroy(other.gameObject);
        }
    }
}
