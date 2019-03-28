using UnityEngine;

public class Level : MonoBehaviour {
  // Config paarameters
  [SerializeField] int brekableBlocks; // Serialized for debugging purposes

  // Cached reference
  SceneLoader sceneLoader;

  void Start() {
    sceneLoader = FindObjectOfType<SceneLoader>();
  }

  public void CountBrekableBlocks() {
    brekableBlocks++;
  }

  public void BlockDestroyed() {
    brekableBlocks--;
    if (brekableBlocks <= 0) {
      sceneLoader.LoadNextScene();
    }
  }
}
