using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public Transform mainMenu, optionsMenu;
    public static LevelManager levelManager;

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}


	public void QuitGame()
	{
		Application.Quit();
	}


	public void OptionsMenu(bool clicked)
	{
		optionsMenu.gameObject.SetActive(clicked);
		mainMenu.gameObject.SetActive(!clicked);
	}
}
