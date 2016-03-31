using UnityEngine;
using System.Collections;

public class Squak_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 5) {
			//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
		}
	}
}
