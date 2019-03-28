﻿using UnityEngine;

public class Ball : MonoBehaviour {

  // Config parameters
  [SerializeField] Paddle paddle1;
  [SerializeField] float xPush = 3f;
  [SerializeField] float yPush = 15f;
  [SerializeField] AudioClip[] ballSounds;
  [SerializeField] float randomFactor = 0.5f;

  // State
  Vector2 paddleToBallVector;
  bool hasStarted = false;

  // Cached component references
  AudioSource myAudioSource;
  Rigidbody2D myRigidbody2D;

  // Start is called before the first frame update
  void Start() {
    paddleToBallVector = transform.position - paddle1.transform.position;
    myAudioSource = GetComponent<AudioSource>();
    myRigidbody2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update() {
    if (!hasStarted) {
      LockBallToPaddle();
      LaunchOnMouseClick();
    }
  }

  private void LockBallToPaddle() {
    Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
    transform.position = paddlePos + paddleToBallVector;
  }

  private void LaunchOnMouseClick() {
    if (Input.GetMouseButtonDown(0)) {
      hasStarted = true;
      myRigidbody2D.velocity = new Vector2(xPush, yPush);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    float randomPushX = Random.Range(0f, randomFactor);
    float randomPushY = Random.Range(0f, randomFactor);
    Vector2 velocityTweak = new Vector2(randomPushX, randomPushY);

    if (hasStarted) {
      if (ballSounds.Length > 0) {
        AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
        myAudioSource.PlayOneShot(clip);
        myRigidbody2D.velocity += velocityTweak;
      }
    }
  }
}
