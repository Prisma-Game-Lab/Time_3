using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject pauseMenu;
	[SerializeField] GameObject player;

	private bool paused;

	public bool IsGamePaused() => Time.timeScale == 0;

	public void Pause() {
		Time.timeScale = 0.0f;

		if (player != null)
			player.GetComponent<PlayerInput>().enabled = false;
			//player.SetActive(false);

		if (pauseMenu != null)
			pauseMenu.SetActive(true);
	}

	public void Unpause() {
		Time.timeScale = 1.0f;

		if (player != null)
			player.GetComponent<PlayerInput>().enabled = true;
			//player.SetActive(true);

		if (pauseMenu != null)
			pauseMenu.SetActive(false);
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
