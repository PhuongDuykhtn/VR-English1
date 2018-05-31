using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gazeobjectname : MonoBehaviour {
	
    public Text text = null;
    void Start()
    {
        text.enabled = false;
    }
    void Update () {
        Transform camera = null;
        camera = Camera.main.transform;
		Ray ray;
		RaycastHit hit;
		GameObject hitObject;
		Debug.DrawRay (camera.position,
			camera.rotation * Vector3.forward * 100.0f);
		ray = new Ray (camera.position,
			camera.rotation * Vector3.forward);
		if (Physics.Raycast (ray, out hit)) {
			hitObject = hit.collider.gameObject;
			if (hitObject.tag == "Object") {
				
                
                text.text = hitObject.name;
                text.enabled = true;
                Debug.Log("Look Me:"+hitObject.name);
                //	transform.position = hit.point;
                //Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                //Debug.Log("Transform (x,y,z): " + transform.position.ToString("F2"));
            }
            else
            {
                text.enabled = false;

            }
		}
	}
}
