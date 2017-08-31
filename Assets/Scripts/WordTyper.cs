using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordTyper : MonoBehaviour {

	public float delay = 0.1f;
	public string[] fullText;
    private int indexOfText = 0;
	private string currentText = "";

	// Use this for initialization
	void Start (){
        indexOfText = 0;
		StartCoroutine("ShowText");
	}

    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("return"))
        {
            if (currentText == fullText[indexOfText])
            {
                NextText();
            }
            else
            {
                currentText = fullText[indexOfText];
                this.GetComponent<Text>().text = currentText;
                StopCoroutine("ShowText");
            }
        }
    }

    IEnumerator ShowText() {
		for (int i = 0; i < fullText[indexOfText].Length; i++) {
            currentText += fullText[indexOfText][i];
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}

    private void NextText()
    {
        if(indexOfText < fullText.Length - 1)
        {
            indexOfText++;
            currentText = "";
            StartCoroutine("ShowText");
        } else
        {
            LevelManager.levelManager.LoadByIndex(2);
        }
    }
}
