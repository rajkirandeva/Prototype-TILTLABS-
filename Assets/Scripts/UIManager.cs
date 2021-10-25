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
    }

    [Serializable]
    public class MenuHUD
	{
        public GameObject mainHUD;
	}

    [Serializable]
    public class GameOverHUD
	{
        public GameObject mainHUD;
	}



    public GameHUD gameHUD;
    public MenuHUD menuHUD;
    public GameOverHUD gameOverHUD;


	private void Awake()
	{
        instance = this;
	}

    public void OnButtonClickPlay()
	{
        gameHUD.mainHUD.SetActive(true);
        menuHUD.mainHUD.SetActive(false);
	}


    public void OnButtonClickHome()
	{
        SceneManager.LoadScene(0);
	}

}
