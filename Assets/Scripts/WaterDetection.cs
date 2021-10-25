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

                //Vector3 toTarget = (other.gameObject.transform.position - PlayerController.instance.hip.transform.position).normalized;

                //if (Vector3.Dot(toTarget, gameObject.transform.forward) > 0)
                //{
                //    Debug.Log("from front");
                //    return;
                //}
                //else
                //{
                //    Debug.Log("from back");
                //}


                float angle = Quaternion.Angle(PlayerController.instance.hip.transform.rotation, other.gameObject.transform.rotation);

                print(angle);

                if(angle >= 80 && angle <= 130)
				{
                    print("Perfect Dive");
                    ScoreManager.instance.AddScore(100);
				}


                Invoke("GameOver", 3);

                break;
		}
	}


    public void GameOver()
	{
        GameManager.instance.GameOver();
	}
}
