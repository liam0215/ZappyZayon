using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordTyper : MonoBehaviour {

	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";

	// Use this for initialization
	void Start (){
		StartCoroutine("ShowText");
	}

    private void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("return"))
        {
            currentText = fullText;
            this.GetComponent<Text>().text = currentText;
            StopCoroutine("ShowText");
        }
    }

    IEnumerator ShowText() {
		for (int i = 0; i < fullText.Length; i++) {
			currentText = fullText.Substring (0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}
}
