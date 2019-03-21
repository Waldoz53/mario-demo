using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int coins = 0;
    //private int lives = 3;
    //public bool isBig = false;

    public Text coinText;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coins;
    }

    public void IncrementCoins()
    {
        coins++;
    }
}
