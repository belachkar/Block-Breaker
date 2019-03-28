using UnityEngine;

public class GameStatus : MonoBehaviour {
  // Configuration parameters
  [Range(.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int scorePerBlockDestroyed = 83;

  // State variables
  [SerializeField] int currentScore = 0;

  // Update is called once per frame
  void Update() {
    Time.timeScale = gameSpeed;
  }

  public void AddToScore() {
    currentScore += scorePerBlockDestroyed; 
  }
}
