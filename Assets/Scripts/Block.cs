using UnityEngine;

public class Block : MonoBehaviour {

  // Config parameters
  [SerializeField] AudioClip breakSound;
  [SerializeField] GameObject blockSparklesVFX;
  [SerializeField] Sprite[] hitSprites;

  // Cached refernces
  Level level;

  // State variables
  [SerializeField] int timesHits; // TODO only serialized for debug prupose

  void Start() {
    level = FindObjectOfType<Level>();
    CountBreakableBlocks();
    print("hitSprites length: " + hitSprites.Length);
  }

  private void CountBreakableBlocks() {
    if (tag == "Breakable") {
      level.CountBlocks();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (tag == "Breakable") {
      HaundleHit();
    }
  }

  private void HaundleHit() {
    int maxHits = hitSprites.Length + 1;
    timesHits++;

    if (timesHits >= maxHits) {
      DestroyBlock();
    } else {
      ShwoNextHitSprite();
    }
  }

  private void ShwoNextHitSprite() {
    int spriteIndex = hitSprites.Length - 1;
    if (timesHits <= hitSprites.Length) {
      spriteIndex = timesHits - 1;
    }
    if (hitSprites[spriteIndex] != null) {
      GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    } else {
      Debug.LogError("Block sprite missing from the sprites array of: " + gameObject.name);
    }
  }

  private void DestroyBlock() {
    FindObjectOfType<GameStatus>().AddToScore();
    PlayBlockDestroySFX();
    TriggerSparklesVFX();
    Destroy(gameObject);
    level.BlockDestroyed();
  }

  private void PlayBlockDestroySFX() {
    AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
  }

  private void TriggerSparklesVFX() {
    GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    Destroy(sparkles, .5f);
  }
}
