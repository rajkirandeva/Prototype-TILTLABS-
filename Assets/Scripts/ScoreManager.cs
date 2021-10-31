using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int currentScore;
    private int currentCoins;
    private int bonusCoins;
    private int bonusScore;

    private int totalCoins;



    public int CurrenScore { 
        get { return currentScore; }
        set { currentScore = value; }
	}

    public int CurrentCoins
	{
		get { return currentCoins; }
		set { currentCoins = value; }
	}

    public int BonusCoins
	{
		get { return bonusCoins; }
		set { bonusCoins = value; }
	}

    public int BonusScore
	{
		get { return bonusScore; }
		set { bonusScore = value; }
	}

    public int TotalCoins
	{
		get { return totalCoins; }
		set { totalCoins = value; }
	}


	private void Awake()
	{
        instance = this;
        totalCoins = PlayerPrefs.GetInt("totalCoins");

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
        totalCoins = totalCoins + amount;
        PlayerPrefs.SetInt("totalCoins", totalCoins);
	}

}
