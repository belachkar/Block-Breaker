using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour {
  // Configuration parameters
  [Range(.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int scorePerBlockDestroyed = 83;
  [SerializeField] TextMeshProUGUI scoreText;

  // State variables
  public static int currentScore = 0;



  void Start() {
    UpdateScore();
  }

  void Update() {
    Time.timeScale = gameSpeed;
  }

  public void AddToScore() {
    currentScore += scorePerBlockDestroyed;
    UpdateScore();
  }

  public void UpdateScore() {
    print("currentScore: " + currentScore);
    scoreText.text = currentScore.ToString();
  }

  public void ResetGame() {
    Destroy(gameObject);
  }
}
