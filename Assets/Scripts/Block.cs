using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]
    private AudioClip breakingSound;

    private void OnCollisionEnter2D(Collision2D other) {
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}