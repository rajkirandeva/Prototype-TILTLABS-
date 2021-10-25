using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public int targetFps;


    public List<GameObject> woodenBoxSets = new List<GameObject>();
    public Transform woodenboxTrans;


	private void Awake()
	{
        instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        Application.targetFrameRate = targetFps;

        SetUpWoodenBox();


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SetUpWoodenBox()
	{
        SpawnObject(woodenBoxSets[Random.Range(0,woodenBoxSets.Count)], woodenboxTrans);
	}


    public void SpawnObject(GameObject mObject, Transform mTrans)
	{
        Instantiate(mObject, mTrans.position, Quaternion.identity);
	}



    public void GameOver()
	{
        UIManager.instance.gameOverHUD.mainHUD.SetActive(true);
        PlayerController.instance.gameObject.SetActive(false);
	}
}
