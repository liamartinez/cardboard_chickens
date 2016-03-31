using UnityEngine;
using System.Collections;

public class glass_trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered glass");
        string name = other.gameObject.name;
        Debug.Log(name);

        Vector3 vel = other.GetComponent<Rigidbody>().velocity;

        // GetComponent<Rigidbody>().velocity = new Vector3(vel.x*-100, vel.y * -100, vel.z*-100);
        other.GetComponent<Rigidbody>().AddForce(transform.forward * -500);
    }
    
}
