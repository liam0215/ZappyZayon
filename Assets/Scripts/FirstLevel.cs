using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevel : MonoBehaviour {

    private Image levelImage;
    public Sprite[] floorTiles;
    public int columns = 200;
    public int rows = 200;

    private Transform boardHolder;
    private List<Vector3> gameGrid = new List<Vector3>();
 
	// Use this for initialization
	void Start () {
        levelImage = GameObject.Find("Fade").GetComponent<Image>();
        StartCoroutine("FadeIn");
       // InitializeList();
       // LevelSetup();
    }
        
    void InitializeList()
    {
        gameGrid.Clear();
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                gameGrid.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void LevelSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                GameObject instance = new GameObject("Tile");
                instance.AddComponent<SpriteRenderer>();
                int random = Random.Range(0, floorTiles.Length);
                instance.GetComponent<SpriteRenderer>().sprite = floorTiles[random];
                instance = Instantiate(instance, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    IEnumerator FadeIn()
    {
        for(int i = 0; i < 100; i++)
        {
            Color color = levelImage.color;
            color.a = (100.0f - i) / 100.0f;
            levelImage.color = color;
            yield return new WaitForSeconds(.01f);
        }
    }

    IEnumerator FadeOut()
    {
        for(int i = 0; i < 100; i++)
        {
            Color color = levelImage.color;
            color.a = i / 100.0f;
            levelImage.color = color;
            yield return new WaitForSeconds(.005f);
        }
    }
}
