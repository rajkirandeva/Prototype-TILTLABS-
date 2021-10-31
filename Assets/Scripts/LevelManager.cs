using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    private int currentLevel;


    public int CurrentLevel
	{
		get { return currentLevel; }
        set { currentLevel = value; }
	}

	private void Awake()
	{
        instance = this;
	}


	// Start is called before the first frame update
	void Start()
    {
        currentLevel = PlayerPrefs.GetInt("savedlevel");
        GetLevel(currentLevel);
    }

    public void GetLevel(int count)
	{
		switch (count)
		{
			case 0:
				//INITIAL LEVEL
				break;
			case 1:
				GameManager.instance.SetUpWoodenBox(0);
				break;
			case 2:
				GameManager.instance.SetUpWoodenBox(1);
				break;
			case 3:
				GameManager.instance.SetUpCylinder(0);
				break;
			case 4:
				GameManager.instance.SetUpWoodenBox(2);
				break;  

		}
	}

    public void NextLevel()
	{
        currentLevel = currentLevel + 1;
        PlayerPrefs.SetInt("savedlevel", currentLevel);
	}
}
