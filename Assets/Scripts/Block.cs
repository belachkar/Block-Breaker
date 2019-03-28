using UnityEngine;

public class Block : MonoBehaviour {
  [SerializeField] AudioClip breakSound;

  // Cached refernces
  Level level;
  GameStatus gameStatus;

  void Start() {
    level = FindObjectOfType<Level>();
    gameStatus = FindObjectOfType<GameStatus>();
    level.CountBrekableBlocks();
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    DestroyBlock();
  }

  private void DestroyBlock() {
    AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    Destroy(gameObject);
    level.BlockDestroyed();
    gameStatus.AddToScore();
  }
}
