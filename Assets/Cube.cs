using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

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


    void start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;

        /*
        colors[0] = new Color(191.0f / 255.0f, 96.0f/255.0f, 140.0f/255.0f);
        colors[1] = new Color(51.0f / 255.0f, 166.0f / 255.0f, 112.0f / 255.0f);
        colors[2] = new Color(160.0f / 255.0f, 166.0f / 255.0f, 112.0f / 255.0f);
        colors[3] = new Color(242.0f / 255.0f, 202.0f / 255.0f, 82.0f / 255.0f);
        colors[4] = new Color(242.0f / 255.0f, 114.0f / 255.0f, 68.0f / 255.0f);
        */

       

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Cube Contact was made!");
        colourChangeCollision = true;
        currentDelay = Time.time + colourChangeDelay;
    }
    void checkColourChange()
    {
        Color matColor; 
        if (colourChangeCollision)
        {
           
            //Color randColor = 
            gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
            // matColor = randColor; 

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
