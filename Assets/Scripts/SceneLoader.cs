using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

  public void LoadNextScene() {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    SceneManager.LoadScene(currentSceneIndex + 1);
  }

  public void LoadStartScene() {
    FindObjectOfType<ResetGame>().ResetScore();
    SceneManager.LoadScene("Start Menu");
  }

  public void QuitGame() {
    Application.Quit();
  }
}
