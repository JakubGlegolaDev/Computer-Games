using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;
	public string menuSceneName = "MainMenu";

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
		} else
		{
			Time.timeScale = 1f;
		}
	}

	public void Restart ()
	{
		Toggle();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		WaveSpawner.EnemiesAlive = 0;
	}

	public void Menu () 
	{
		Toggle();
		SceneManager.LoadScene(menuSceneName);
	}

}
