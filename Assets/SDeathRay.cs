using UnityEngine;
using System.Collections;

public class SDeathRay : MonoBehaviour {

	private int count; 
	//public static bool UFOfull; 
	public bool UFOfull; 

	// Use this for initialization
	void Start () {
		UFOfull = false; 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider other)
	{
		Debug.Log(count);
		if (!UFOfull) {
			other.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			other.attachedRigidbody.useGravity = false;
		}
    }

    void OnTriggerExit (Collider other)
    {
		Destroy(other);
		count++; 
		if (count > 5)
			UFOfull = true;        
    }



}
