using UnityEngine;
using System.Collections;

public class RainingChickens : MonoBehaviour {

    public GameObject chicken;  

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("space"))
        {
            Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 100, Random.Range(-10.0F, 10.0F));
            GameObject c = (GameObject)Instantiate(chicken, new Vector3(position.x, position.y, position.x), Quaternion.identity); 
        }
	}
}
