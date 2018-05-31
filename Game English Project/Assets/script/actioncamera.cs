using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class actioncamera : MonoBehaviour {
    public GameObject Particle = null;
    public GameObject player = null;
    public Text text = null;
    public float speed = 0.5f;
    private GameObject hitedObject;
    private bool isSpeak = false; 

    
    void Start()
    {
        text.enabled = false;       
        Debug.Log("Start");
        isSpeak = true;

    }
    void Update () {

        Transform camera = null;
        camera = Camera.main.transform;
        // Create Ray to point object
        Ray ray;
		RaycastHit hit;
		GameObject hitObject;
		Debug.DrawRay (camera.position,
			camera.rotation * Vector3.forward * 100.0f);
		ray = new Ray (camera.position,
			camera.rotation * Vector3.forward);
		if (Physics.Raycast (ray, out hit)) {
			hitObject = hit.collider.gameObject;
            // Check if hit ground
            // Move on ground
            if (hitObject.tag == "Ground")
            {
                float step = speed * Time.deltaTime;
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(hit.point.x, player.transform.position.y, hit.point.z), step);
            }
            // Check if object need to show name
            // Show name Object
            // Show particle on object
            if (hitObject.tag == "Object") {
                text.text = hitObject.name;
                text.enabled = true;
                Particle.transform.position = hitObject.transform.position;
                //Debug.Log("Look Me:"+hitObject.name);
                
                // Play sound of object
                if (isSpeak == true)
                {
                    AudioSource audio = hitObject.GetComponent<AudioSource>();
                    Debug.Log("Audio play");
                    audio.Play();
                    isSpeak = false;

                }
                if (hitedObject == null)
                {
                    Debug.Log("OnNull");
                }
                // If hit object is the same as the registered one
                else if (hitedObject.GetInstanceID() != hitObject.GetInstanceID())
                {
                    Debug.Log("OnHitStay");
                    isSpeak = true;
                }
                
                hitedObject = hitObject;
                
            }   
            else
            {
                text.enabled = false; 
            }
        }
	}

}
