using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
  // Configuration parameters
  [Range(.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int scorePerBlockDestroyed = 83;
  [SerializeField] TextMeshProUGUI scoreText;

  // State variables
  static int currentScore = 0;

  void Awake() {
    int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
    if (gameStatusCount > 1) {
      Destroy(gameObject);
    } else {
      DontDestroyOnLoad(gameObject);
    }
  }

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
}
