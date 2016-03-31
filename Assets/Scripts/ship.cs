using UnityEngine;
using System.Collections;

public class ship : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	        //transform.Rotate(Vector3.down, 100f * Time.deltaTime);
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);

	}
}
