using UnityEngine;

public class Cube : MonoBehaviour {

    //audio
	public AudioClip toneClip; 
	private AudioSource toneSource; 

    public float colourChangeDelay = 0.09f;
    float currentDelay = 0f;
    bool colourChangeCollision = false;
    Color[] colors = {
     new Color(191.0f/ 255.0f, 96.0f/ 255.0f, 140.0f/ 255.0f),
     new Color(51/ 255.0f,166/ 255.0f,112/ 255.0f),
     new Color(160/ 255.0f,166/ 255.0f,5/ 255.0f),
     new Color(242/ 255.0f,202/ 255.0f,82/ 255.0f),
     new Color(242/ 255.0f,114/ 255.0f,68/ 255.0f)
    };

    void Awake() {
		toneSource = GetComponent<AudioSource> (); 
	}

    void start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnCollisionEnter(Collision collision)
    {
        toneSource.PlayOneShot (toneClip, Random.Range(0.02f, 0.8f)); 
        Debug.Log("Cube Contact was made!");
        colourChangeCollision = true;
        currentDelay = Time.time + colourChangeDelay;
    }
    void checkColourChange()
    {
        if (colourChangeCollision)
        {
            gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)]; 
            if (Time.time > currentDelay)
            {
                gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)]; 
                colourChangeCollision = false;
            }
        }
    }

    void Update()
    {
        checkColourChange();
    }



}
