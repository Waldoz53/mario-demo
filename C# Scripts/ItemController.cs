using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool mushroom;
    public bool coin;

    BoxCollider2D collision;
    // Start is called before the first frame update
    void Start()
    {
        collision = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coin == true)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mushroom == true && collision.gameObject.tag == "Player")
        {
            //gameController.isBig = true?
            collision.transform.localScale = new Vector3(4, 4, 4);
            Destroy(gameObject);
        }
    }
}
