using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {
    //Why did you make this if we already have a fade in FirstLevel.cs
    private Image image;

	void Start (){
        image = gameObject.GetComponent<Image>();
        StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn(){
		float time = 2f;
        Color color = image.color;
		while (image.color.a > 0) {
            color.a -= Time.deltaTime / time;
            image.color = color;
			yield return null;
		}
	}

    IEnumerator FadeOut()
    {
        float time = 2f;
        Color color = image.color;
        while(image.color.a < 1)
        {
            color.a += Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }
}