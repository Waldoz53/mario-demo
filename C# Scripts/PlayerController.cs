using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movement;
    public float jump;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private BoxCollider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collision = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (rb2d.velocity.x == 0)
        {
            animator.SetFloat("Speed", 0);
        }

        if (rb2d.velocity.y == 0)
        {
            animator.SetBool("Jump", false);
        }

        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(movement, rb2d.velocity.y);
            sprite.flipX = false;
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-movement, rb2d.velocity.y);
            sprite.flipX = true;
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
            animator.SetBool("Jump", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

    }
}
