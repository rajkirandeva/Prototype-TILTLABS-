using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public delegate void DeligateGameOver();
    public static event DeligateGameOver gameOverEvent;

    public bool isFailed = false;
    public enum GameState
	{
        menu,
        gameplay,
        gameover
	}

    public GameState gameState;
    public int targetFps;


    public List<GameObject> woodenBoxSets = new List<GameObject>();
    public List<GameObject> cylinderSets = new List<GameObject>();
    public Transform woodenboxTrans;

	private void OnEnable()
	{
        gameOverEvent += OnOver;
	}

	private void Awake()
	{
        instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        Application.targetFrameRate = targetFps;




    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SetUpWoodenBox(int count)
	{
        SpawnObject(woodenBoxSets[count], woodenboxTrans.position);
	}

    public void SetUpCylinder(int count)
    {
        SpawnObject(cylinderSets[count], new Vector3(0,woodenboxTrans.transform.position.y,0));
    }


    public void SpawnObject(GameObject mObject, Vector3 mTrans)
	{
        Instantiate(mObject, mTrans, Quaternion.identity);
	}



    private void OnOver()
	{
        UIManager.instance.gameOverHUD.mainHUD.SetActive(true);
        PlayerController.instance.gameObject.SetActive(false);
        UIManager.instance.gameHUD.mainHUD.SetActive(false);
	}

    public void GameOver()
	{
          gameOverEvent();
	}

	private void OnDisable()
	{
        gameOverEvent -= OnOver;
	}



}
