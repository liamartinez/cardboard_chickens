using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour {

	private Animator animator; 
	public SDeathRay dr; 
	public GameObject ray; 

	//bool isFull; 
	//bool isUFOleaving; 

	void Awake() {
		animator = GetComponent<Animator> ();
		animator.SetBool ("isReady", false); 
		animator.SetBool ("isLeaving", false); 
		dr = ray.GetComponent<SDeathRay> (); 
	}

	void start() {
		

	}

	void Update() {
		//isFull = gameObject.GetComponentsInChildren<Script>.UFOfull; 
		if (dr.UFOfull == true) StartCoroutine (flashLights()); 
	}

	public IEnumerator flashLights() {
		animator.SetBool ("isReady", true); 
		yield return new WaitForSeconds (2f); 
		transform.Find("DeathRay").GetComponent<MeshRenderer>().enabled = false; 
		animator.SetBool ("isLeaving", true);
		transform.Find("UFO").GetComponent<MeshRenderer>().enabled = false; 
	}
}


/*
using UnityEngine.Experimental.Director; 


[RequireComponent(typeof(Animator))]
public class UFO : MonoBehaviour {

	public AnimationClip first; 
	public AnimationClip sec; 

	private AnimationClipPlayable clipFirst, clipSecond; 
	private AnimationMixerPlayable m_Mixer; 

	// Use this for initialization
	void Start () {
		//clipFirst = new AnimationClipPlayable (first); 
		//clipSecond = new AnimationClipPlayable (sec); 

		m_Mixer = new AnimationMixerPlayable (); 
		m_Mixer.SetInputs (new[] {first, sec}); 
		//GetComponent<Animator>().Play(m_Mixer);
	}
	

	void Update () {

		if (Input.GetKey ("up")) {
			GetComponent<Animator>().Play(m_Mixer);
		}

		if (Input.GetKey ("down")) {
			clipFirst.state = PlayState.Paused;
			GetComponent<Animator>().Play(clipSecond);
			clipSecond.state = PlayState.Playing;
		}

	}
}

*/
