using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]
    private AudioClip breakingSound;

    // Cached reference
    private Level _level;
    private GameSession _session;

    private void Start() {
        _level = FindObjectOfType<Level>();
        _level.CountBreakableBlocks();
        _session = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        DestroyBlock();
    }

    private void DestroyBlock() {
        _session.AddToScore();
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
        _level.BlockDestroyed();
        Destroy(gameObject);
    }
}