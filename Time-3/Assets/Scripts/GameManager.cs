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
	}

	public bool IsGamePaused() => Time.timeScale == 0;

	public void Pause() {
		Time.timeScale = 0.0f;

		if (player != null)
			player.GetComponentInChildren<PlayerInput>().enabled = false;

		if (pauseMenu != null)
			pauseMenu.SetActive(true);

		if (hud != null)
			hud.SetActive(false);
	}

	public void Unpause() {
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
