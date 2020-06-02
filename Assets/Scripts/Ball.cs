using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {
    [SerializeField]
    private Paddle paddle;

    [SerializeField]
    private List<AudioClip> ballSounds;

    private Vector2 _paddleToBallVector;
    private Rigidbody2D _body;
    private AudioSource _audio;
    private bool _launched;
    private float _randomFactor = 0.2f;

    // Start is called before the first frame update
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        _paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!_launched) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            _launched = true;
            _body.velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = _paddleToBallVector + paddlePosition;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, _randomFactor), Random.Range(0f, _randomFactor));
        AudioClip clip = ballSounds[Random.Range(0, ballSounds.Count - 1)];
        _audio.PlayOneShot(clip);
        _body.velocity += velocityTweak;
    }
}