using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour
{
    public bool hasCoins;
    public int coins;
    public GameObject coin;

    public bool hasMushroom;
    public GameObject mushroom;

    public Sprite emptyBox;

    GameController gameController;

    Rigidbody2D rb2d;
    BoxCollider2D collision;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coins == 0)
        {
            hasCoins = false;
        }

        if (hasCoins == false && hasMushroom == false)
        {
            sprite.sprite = emptyBox;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasCoins == true && coins != 0)
            {
                Instantiate(coin, new Vector3(transform.position.x, transform.position.y + 0.6f, 0), Quaternion.identity);
                coins--;
                gameController.IncrementCoins();
            } 

            if (hasMushroom == true)
            {
                Instantiate(mushroom, new Vector3(transform.position.x, transform.position.y + 0.6f, 0), Quaternion.identity);
                hasMushroom = false;
            }

        }
    }
}
