using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]
    private AudioClip breakingSound;

    [SerializeField]
    private GameObject blockParticlesVfx;

    [SerializeField]
    private int maxHits;

    [SerializeField]
    private int hitsReceived = 0;

    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    // Cached reference
    private Level _level;
    private GameSession _session;
    private SpriteRenderer _spriteRenderer;

    private void Start() {
        CountBreakableBlocks();
        _session = FindObjectOfType<GameSession>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void CountBreakableBlocks() {
        _level = FindObjectOfType<Level>();
        if (CompareTag("Breakable")) {
            _level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (CompareTag("Breakable")) {
            HandleHit();
        }
    }

    private void HandleHit() {
        hitsReceived++;
        if (hitsReceived >= maxHits) {
            DestroyBlock();
        }
        else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        _spriteRenderer.sprite = sprites[hitsReceived - 1];
    }

    private void DestroyBlock() {
        _session.AddToScore();
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
        _level.BlockDestroyed();
        TriggerSparklesVfx();
        Destroy(gameObject);
    }

    private void TriggerSparklesVfx() {
        GameObject particles = Instantiate(blockParticlesVfx, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }
}