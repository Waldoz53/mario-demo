using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public float movement;

    public bool goingLeft;
    public bool goingRight;

    private Rigidbody2D rb2d;
    private PolygonCollider2D collision;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collision = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(-movement, rb2d.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            movement *= -1;
            if (sprite.flipX == false)
            {
                sprite.flipX = true;
            } else
            {
                sprite.flipX = false;
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
