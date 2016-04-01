using UnityEngine;
using System.Collections;

public class pie : MonoBehaviour {

    public float horizontalSpeed; 
    public float verticalSpeed; 
    public float amplitude; 
    public Vector3 tempPos; 
    private bool isHit = false; 

	// Use this for initialization
	void Start () {
	    tempPos = transform.position; 
        amplitude = Random.Range (0.1f, 0.6f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isHit) {
	    tempPos.x += horizontalSpeed; 
        tempPos.y += Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude; 
        transform.position = tempPos; 
        }
	}
    
    void OnCollisionEnter(Collision collision) {
        GetComponent<AudioSource>().Play(); 
        if (collision.gameObject.name == "pie") 
        isHit = true; 
    }
}
