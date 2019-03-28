using UnityEngine;

public class Paddle : MonoBehaviour {

  // Connfiguration parameters
  [SerializeField] float minX = 1f;
  [SerializeField] float maxX = 15f;
  [SerializeField] float screenWidthInUnits = 16f;

  // Cached references
  GameStatus myGameStatus;
  Ball myBall;

  private void Start() {
    myGameStatus = FindObjectOfType<GameStatus>();
    myBall = FindObjectOfType<Ball>();
  }

  // Update is called once per frame
  void Update() {
    Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
    paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
    transform.position = paddlePos;
  }

  private float GetXPos() {
    if (myGameStatus.IsAutoPlayEnabled()) {
      return myBall.transform.position.x;
    } else {
      return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
  }
}
