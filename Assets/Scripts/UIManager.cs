using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    [Serializable]
    public class GameHUD
	{
        public GameObject mainHUD;
        public TMP_Text scoreText;
        public TMP_Text coinsText;
        public TMP_Text levelText;
    }

    [Serializable]
    public class MenuHUD
	{
        public GameObject mainHUD;
        public TMP_Text totalCoinsText;
	}

    [Serializable]
    public class GameOverHUD
	{
        public GameObject mainHUD;
        public TMP_Text headerText;
        public TMP_Text bonusText;
        public TMP_Text buttonText;
	}



    public GameHUD gameHUD;
    public MenuHUD menuHUD;
    public GameOverHUD gameOverHUD;

	private void OnEnable()
	{
        GameManager.gameOverEvent += UpDateOnOver;
	}

	private void Awake()
	{
        instance = this;
	}

	private void Start()
	{
        menuHUD.totalCoinsText.text = "Total Coins\n" + ScoreManager.instance.TotalCoins;
	}

	public void OnButtonClickPlay()
	{
        gameHUD.mainHUD.SetActive(true);
        menuHUD.mainHUD.SetActive(false);
        int levelNumber = LevelManager.instance.CurrentLevel + 1;
        gameHUD.levelText.text = "Level " + levelNumber;
    }


    public void OnButtonClickHome()
	{
        if(!GameManager.instance.isFailed)
        LevelManager.instance.NextLevel();

        SceneManager.LoadScene(0);
	}

    public void UpDateOnOver()
	{
        if (!GameManager.instance.isFailed)
        {
            gameOverHUD.headerText.text = "LEVEL SUCCESS";
            gameOverHUD.buttonText.text = "NEXT";

            if (PlayerController.instance.isPerfectDive)
            {
                gameOverHUD.bonusText.gameObject.SetActive(true);
                gameOverHUD.bonusText.text = "BONUS\n+" + ScoreManager.instance.BonusCoins + " Coins \n +"+ScoreManager.instance.BonusScore + " Points";
            }
            else
            {
                gameOverHUD.bonusText.gameObject.SetActive(false);
            }
		}
		else
		{
            gameOverHUD.headerText.text = "LEVEL FAILED";
            gameOverHUD.buttonText.text = "RETRY";
            gameOverHUD.bonusText.gameObject.SetActive(false);
        }

    }


	private void OnDisable()
	{
        GameManager.gameOverEvent -= UpDateOnOver;
    }

}
