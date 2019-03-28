using UnityEngine;

public class Persistant : MonoBehaviour {
  private void Awake() {
    int persistantObjCount = FindObjectsOfType<Persistant>().Length;
    if (persistantObjCount > 1) {
      Destroy(gameObject);
    } else {
      DontDestroyOnLoad(gameObject);
    }
  }
}
