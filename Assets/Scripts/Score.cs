using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

  // Cached references
  GameStatus gameStatus;
  TextMeshProUGUI scoreText;

  void Start() {
    gameStatus = FindObjectOfType<GameStatus>();
    // scoreText.text = gameStatus.GetCurrentScore().ToString();
    // print("Score script => scoreText.text: " + scoreText.text);
  }
}
