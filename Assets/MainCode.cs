using UnityEngine;
using System.Collections;

public class MainCode : MonoBehaviour {

    GameObject ball;
    GameObject cube; 

    private float mouseX;
    private float mouseY;

    public Camera camera1;
    public Camera camera2;

	//audio
	public AudioClip popSound; 
	private AudioSource popSource; 

    //color
    //public Color colorStart = Color.red;
    //public Color colorEnd = Color.green;
    public float duration = 1.0F;

    //cubes
    private int numCubesX;
    private int numCubesY;


	void Awake() {
		popSource = GetComponent<AudioSource> (); 
	}

    // Use this for initialization
    void Start () {
        ball = Resources.Load("chicken") as GameObject;
        cube = Resources.Load("Cube") as GameObject; 

        camera1.enabled = true; 
        camera2.enabled = false;

        numCubesX = Random.Range(5, 15);
        numCubesY = Random.Range(5, 15);

        for (int x = 0 - numCubesX/2; x < numCubesX/2; x++)
        {
            for (int y = 0; y < numCubesY; y++)
            {
                GameObject c = Instantiate(cube);
                c.transform.position = new Vector3((float)x*30, (float)y*30, 60f);  
            }
        }
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
		popSource.PlayOneShot (popSound, 1F); 
		GameObject b = Instantiate(ball) as GameObject;
		Debug.Log ("NEW CHICKEN");
		b.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
		Rigidbody rb = b.GetComponent<Rigidbody>(); 
		rb.velocity = camera1.transform.forward * 150; 
		Debug.Log ("playing?" + popSource.isPlaying);
	}

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
