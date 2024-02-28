using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float speed = 1.0f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x >= 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
