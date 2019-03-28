using UnityEngine;

public class ResetGame : MonoBehaviour {
  public void ResetScore() {
    GameStatus.currentScore = 0;
  }
}
