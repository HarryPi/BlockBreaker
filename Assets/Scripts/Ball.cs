using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    private Paddle paddle;

    private Vector2 _paddleToBallVector;
    private Rigidbody2D _body;
    private bool _laucnhed;
    
    // Start is called before the first frame update
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!_laucnhed) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            _laucnhed = true;
            _body.velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = _paddleToBallVector + paddlePosition;
    }
}