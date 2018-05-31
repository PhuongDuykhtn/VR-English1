using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class gazeobject : MonoBehaviour {
	[SerializeField] int sceneLoad;
	private bool gazedAt = false;
	private float gazedTime = 2.0f;
	private float timer = 0.0f;
	private Renderer rend;
	private Color startcolor;
	//private GUIText textObject;
	//public GameObject object;
	// Use this for initialization
	void Start () {
		//object = GetComponent<GameObject> ();
		rend =	GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Now");
		if (gazedAt) {
			
			timer += Time.deltaTime;
			if (timer >= gazedTime) {
				//SceneManager.LoadScene (sceneLoad);

			}
		} else {
			timer = 0.0f;
		}


	}
	public void PointerEnter(){
		gazedAt = true;
		startcolor = rend.material.color;
		rend.material.color = Color.yellow;
		Debug.Log( gameObject.name);
		Debug.Log("Pointer +" + gameObject.name +"Enter");
	}
	public void PointerExit(){
		rend.material.color = startcolor;
		gazedAt = false;
		Debug.Log("Pointer" +gameObject.name + " Exit");
	}
}
