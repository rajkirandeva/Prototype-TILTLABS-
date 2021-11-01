using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag)
		{
            case "Water":
                float angle = Quaternion.Angle(PlayerController.instance.hip.transform.rotation, other.gameObject.transform.rotation);

                print(angle);
                

                if(angle >= 80 && angle <= 145)
				{
                    ScoreManager.instance.AddScore(40);
                    ScoreManager.instance.AddCoins(15);
                    if (!PlayerController.instance.canRotate)
					{
                        PlayerController.instance.isPerfectDive = true;
                        print("Perfect Dive");
                        ScoreManager.instance.AddScore(ScoreManager.instance.BonusScore);
						ScoreManager.instance.AddCoins(ScoreManager.instance.BonusCoins);


                        if (angle >= 100 && angle <= 125)
                        {
                            ScoreManager.instance.BonusCoins = Random.Range(20, 30);
                            ScoreManager.instance.BonusScore = Random.Range(70, 100);
                            ScoreManager.instance.AddScore(ScoreManager.instance.BonusScore);
                            ScoreManager.instance.AddCoins(ScoreManager.instance.BonusCoins);
                        }
						else
						{
                            ScoreManager.instance.BonusCoins = Random.Range(10, 20);
                            ScoreManager.instance.BonusScore = Random.Range(50, 70);
                            ScoreManager.instance.AddScore(ScoreManager.instance.BonusScore);
                            ScoreManager.instance.AddCoins(ScoreManager.instance.BonusCoins);
                        }
					}
					else
					{
                        PlayerController.instance.isPerfectDive = false;
                        //GameManager.instance.isFailed = true;
                    }

				}
				else
				{
                    GameManager.instance.isFailed = true;
                    Debug.Log("GameFailed");
				}

                Invoke("GameOver", 2f);
                

                break;
		}
	}




    public void GameOver()
	{
        GameManager.instance.GameOver();
    }



}
