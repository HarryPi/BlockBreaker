using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    private Paddle paddle;

    private Vector2 _paddleToBallVector;

    // Start is called before the first frame update
    void Start() {
        _paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = _paddleToBallVector + paddlePosition;
    }
}