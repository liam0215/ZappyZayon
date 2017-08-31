using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevel : MonoBehaviour {

    private Image levelImage;
    private bool doingSetup;
	// Use this for initialization
	void Start () {
        levelImage = GameObject.Find("Fade").GetComponent<Image>();
        StartCoroutine("FadeIn");
        doingSetup = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FadeIn()
    {
        for(int i = 0; i < 100; i++)
        {
            Debug.Log("yes");
            Color color = levelImage.color;
            color.a = (100.0f - i) / 100.0f;
            levelImage.color = color;
            yield return new WaitForSeconds(.01f);
        } 
    }
}
