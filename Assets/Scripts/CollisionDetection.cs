using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

	private void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "destructable_object":

				if (PlayerController.instance.canRotate && !GameManager.instance.isFailed)
				{
					other.gameObject.transform.parent.GetComponent<DestructableObject>().destruction.SetActive(true);
					other.gameObject.SetActive(false);
					ScoreManager.instance.AddScore(10);
				}
				else
				{
					GameManager.instance.isFailed = true;
					Invoke("GameOver", 4f);
				}
				break;

		}
	}


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
				Instantiate(PlayerController.instance.waterEffect, transform.position, Quaternion.identity);
				break;
			case "coin":
				Destroy(other.gameObject);
				ScoreManager.instance.AddCoins(1);
				break;
		}
	}


	public void GameOver()
	{
		GameManager.instance.GameOver();
	}
}
