using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class texttospeech : MonoBehaviour {

    public AudioSource _audio;
    //public InputField inputText;
	// Use this for initialization
	void Start () {
        _audio = gameObject.GetComponent<AudioSource>();
        StartCoroutine(DownloadTheAudio());

    }
	// Update is called once per frame
	void Update () {
    }
    IEnumerator DownloadTheAudio()
    {
        //Regex rgx = new Regex("\\s+");
        //string result = rgx.Replace(inputText.text, "+");
        string url = "https://www.bing.com/tspeak?&format=audio%2Fmp3&language=vi&IG=D2CBB80AA6824D9A91B0A5D1074FC4A1&IID=translator.5034.2&text=zxczxczxc%zxczxczxc";
        WWW www = new WWW(url);
        yield return www;
        _audio.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        _audio.Play();
        Debug.Log("NOi roi");
    }
    //public void ButtonClick()
    //{
    //    StartCoroutine(DownloadTheAudio()); 
    //}

}
