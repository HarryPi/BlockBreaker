using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private int score = 0;

    [SerializeField]
    private int pointsPerBlock = 80;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1) {
            GameObject activeObject;
            (activeObject = gameObject).SetActive(false);
            Destroy(activeObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        text.text = score.ToString();
    }

    public void AddToScore() {
        score += pointsPerBlock;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }
}