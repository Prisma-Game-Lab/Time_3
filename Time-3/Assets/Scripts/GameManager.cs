using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject player;

	private GameObject hud;
	private bool paused;

	private void Awake() {
		hud = GameObject.FindWithTag("HUD");
		Time.timeScale = 1.0f;
	}

	private void Start() 
	{
		AudioManager _am = FindObjectOfType<AudioManager>();

		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		switch(currentSceneIndex)
		{
			case 0:	
				_am.Play("menu principal"); 
				break;
			case 1:
				_am.Play("Ambientacao hub");
				break;
			case 2:
			case 3:
			case 4:
				StartCoroutine(_am.PlayLevelSounds());
				break;
			case 6:
				_am.StopSound("Tema Fase p2");
				break;
		}
	}

	public bool IsGamePaused() => Time.timeScale == 0;

	public void Pause() {
		FindObjectOfType<AudioManager>().Play("Menu de pausa");
		Time.timeScale = 0.0f;

		if (player != null)
			player.GetComponentInChildren<PlayerInput>().enabled = false;

		if (pauseMenu != null)
			pauseMenu.SetActive(true);

		if (hud != null)
			hud.SetActive(false);
	}

	public void Unpause() {
		FindObjectOfType<AudioManager>().Play("Menu de pausa");
		Time.timeScale = 1.0f;

		if (player != null)
			player.GetComponentInChildren<PlayerInput>().enabled = true;

		if (pauseMenu != null)
			pauseMenu.SetActive(false);

		if (hud != null)
			hud.SetActive(true);
	}

	public void TogglePause() {
		if (IsGamePaused())
			Unpause();
		else
			Pause();
	}

	public void MainMenu(int sceneID)
	{
		if (IsGamePaused()) Unpause();
		FindObjectOfType<AudioManager>().StopAllSounds();
		SceneManager.LoadScene(sceneID);
	}
	public void ExitGame() => Application.Quit();

	// Input System events
	public void onTogglePause(InputAction.CallbackContext context)
	{
		if (!context.ReadValueAsButton() || context.performed) return;
		TogglePause();
	}
}
