using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField]
    private float minX = 1f;

    [SerializeField]
    private float maxX = 15f;

    [SerializeField]
    private float screenWidthUnits = 16f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePosition =
            new Vector2(transform.position.x, transform.position.y) {
                x = Mathf.Clamp(mousePositionInUnits, minX, maxX)
            };
        transform.position = paddlePosition;
    }
}