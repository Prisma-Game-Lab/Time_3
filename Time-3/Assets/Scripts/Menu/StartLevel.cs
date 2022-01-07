using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private string levelToGo;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(LoadLevelAsync());
        }
    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToGo);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
