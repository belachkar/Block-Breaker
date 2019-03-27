using UnityEngine;

public class Paddle : MonoBehaviour {

  // Connfiguration parameters
  [SerializeField] float minX = 1f;
  [SerializeField] float maxX = 15f;
  [SerializeField] float screenWidthInUnits = 16f;

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
    Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

    paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
    transform.position = paddlePos;
  }
}
