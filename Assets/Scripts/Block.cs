using UnityEngine;

public class Block : MonoBehaviour {
  [SerializeField] AudioClip breakSound;

  // Cached refernces
  Level level;

  void Start() {
    level = FindObjectOfType<Level>();
    level.CountBrekableBlocks();
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    DestroyBlock();
  }

  private void DestroyBlock() {
    AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    level.BlockDestroyed();
    Destroy(gameObject);
  }
}
