using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int currentScore;
    public int currentCoins;


	private void Awake()
	{
        instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
	{
        currentScore += amount;
        UIManager.instance.gameHUD.scoreText.text = "SCORE : " + currentScore; 
	}

    public void AddCoins(int amount)
	{
        currentCoins += amount;
        UIManager.instance.gameHUD.coinsText.text = "COINS : " + currentCoins; 
	}

}
