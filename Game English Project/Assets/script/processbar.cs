using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class processbar : MonoBehaviour {
	public int sceneLoad;
	private bool gazedAt = false;
	private float gazedTime = 2.0f;
	private float timer = 0.0f;
	public Slider slider = null;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
        Debug.Log("Start ProcessBar");
    }
	
	// Update is called once per frame
	void Update () {
		
		if (gazedAt) {
			timer += Time.deltaTime;
			if (slider.value >= 1.0f) {
				SceneManager.LoadScene (sceneLoad);
				return;
			}
		} else {
			timer = 0.0f;
		}
		slider.value = timer / gazedTime;

	}
	public void PointerEnter(){
		gazedAt = true;
		Debug.Log ("Hello");
	}
	public void PointerExit(){
		gazedAt = false;
	}
}
