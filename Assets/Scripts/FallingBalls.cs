using UnityEngine;
using System.Collections;

public class FallingBalls : MonoBehaviour {

    public GameObject ball; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Vector3 position = new Vector3(Random.Range(-10.0F, -5.0F), Random.Range(130, 100), Random.Range(-10.0F, 10.0F));
            GameObject b = (GameObject)Instantiate(ball, new Vector3(position.x, position.y, position.z), Quaternion.identity); 
        }
	
	}
}
