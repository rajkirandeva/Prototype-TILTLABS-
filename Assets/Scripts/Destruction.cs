using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{

    public List<GameObject> objects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < objects.Count; i++)
		{
            objects[i].GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)) * Time.fixedDeltaTime * 100f, ForceMode.Impulse);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
