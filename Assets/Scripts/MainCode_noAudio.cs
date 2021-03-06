﻿using UnityEngine;

public class MainCode_noAudio : MonoBehaviour {

    GameObject ball;
    GameObject cube; 
    GameObject pie; 
    
    private float timeToLive = 2.0f;
    
    //public AudioClip[] drums; 

    private float mouseX;
    private float mouseY;

    public Camera camera1;
    public Camera camera2;

	//audio
	public AudioClip popSound; 
    public AudioClip cluckSound; 
	private AudioSource popSource; 

    //color
    //public Color colorStart = Color.red;
    //public Color colorEnd = Color.green;
    public float duration = 1.0F;

	void Awake() {
		popSource = GetComponent<AudioSource> (); 
	}

    // Use this for initialization
    void Start () {
        
        ball = Resources.Load("chicken") as GameObject;
        cube = Resources.Load("Cube") as GameObject; 
        pie = Resources.Load("pie") as GameObject; 
        
        /*
        drums = new AudioClip[] {
            (AudioClip) Resources.Load("Drums/99751__menegass__bongo1"),
            (AudioClip) Resources.Load("Drums/99752__menegass__bongo2"),
            (AudioClip) Resources.Load("Drums/99753__menegass__bongo3"),
            (AudioClip) Resources.Load ("Drums/99754__menegass__bongo4"),
            (AudioClip) Resources.Load("Drums/219156__jagadamba__bongo02")            
        };
        */

        camera1.enabled = true; 
        camera2.enabled = false;

        //makeCubesGrid(5,15,5,15,30);
        makePies(4, 1, 200, 300);
    }
	
	// Update is called once per frame
	void Update () {

		if (Cardboard.SDK.VRModeEnabled && Cardboard.SDK.Triggered) {
			newChicken (); 
		}

        if (Input.GetKeyDown("space"))
        {
			newChicken (); 
			//popSource.PlayOneShot (popSound, 1F); 
        } 

        if (Input.GetKeyUp(KeyCode.Return))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled; 
        }
        
        
	
	}

	void newChicken() {
        //play sounds
        float vol = Random.Range (0.2F, 0.8F);
		popSource.PlayOneShot (popSound, 1F); 
        if (Random.Range(0F,10F) > 9) {
        popSource.PlayOneShot (cluckSound, 0.5F); 
        }
        //make new chicken
		GameObject b = Instantiate(ball) as GameObject;
		b.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
		Rigidbody rb = b.GetComponent<Rigidbody>(); 
		rb.velocity = camera1.transform.forward * 350; 
        //destroy 
        Destroy(b.gameObject, timeToLive);
	}

    void makePies (int numPiesX, int numPiesY, int scaleMin, int scaleMax) {
        for (int x = 0 - numPiesX/2 + 1; x < numPiesX/2; x++)
        {
            for (int y = 0; y < numPiesY; y++)
            {
                GameObject p = Instantiate(pie);
                int scale = Random.Range(scaleMin, scaleMax);
                p.transform.position = new Vector3((float)x*scale/3, (float)y * scale/2 + 50, 30); 
                p.transform.localScale =  new Vector3((float) scale, (float) scale, (float) scale);
                p.transform.localEulerAngles = new Vector3 (0.0f, 270.0f, 90.0f);       
                AudioSource drum = p.GetComponent<AudioSource>(); 
                //drum.clip = drums[Random.Range(0, drums.Length)];
            }
        }
    }

    void makeCubesGrid(int xMin, int xMax, int yMin, int yMax, int dist) {
        int numCubesX = Random.Range(xMin, xMax);
        int numCubesY = Random.Range(yMin, yMax);

        for (int x = 0 - numCubesX/2; x < numCubesX/2; x++)
        {
            for (int y = 0; y < numCubesY; y++)
            {
                GameObject c = Instantiate(cube);
                c.transform.position = new Vector3((float)x*dist, (float)y*dist, 60f);  
            }
        }
    }
    //this is for controlling the camera with the mouse pre-Cardboard    
	/*
    void LateUpdate()
    {
        HandleMouseRotation(); 
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
    }

    public void HandleMouseRotation()
    {
        var easeFactor = 10f; 
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.mousePosition.x != mouseX)
            {
                var camRotationY = (Input.mousePosition.x - mouseX) * easeFactor * Time.deltaTime;
                this.transform.Rotate(0, camRotationY, 0); 
            }
            if (Input.mousePosition.y != mouseY)
            {
                //GameObject MainCamera = this.gameObject.transform.FindChild("Main Camera").gameObject; 
                
                var camRotationX = (mouseY - Input.mousePosition.y) * easeFactor * Time.deltaTime;
                //Debug.Log(camRotationX);
                var desiredRotationX = Camera.main.transform.eulerAngles.x + camRotationX;

                Camera.main.transform.Rotate(camRotationX, 0, 0);

                if (desiredRotationX >=VerticalRotationMin && desiredRotationX <= VerticalRotationMax)
                {
                 
                    //Camera.main.transform.Rotate(camRotationX, 0, 0);
                }
            }
        }
    }
*/

}
