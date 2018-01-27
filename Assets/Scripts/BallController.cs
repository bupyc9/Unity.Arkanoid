using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    [SerializeField] private PlayerController player;
    [SerializeField] private AudioClip hitSound;

    private new Rigidbody2D rigidbody;
    private new AudioSource audio;
    private bool isActive;
    private Vector2 initialForce;
    private Vector3 startPosition;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void Start() {
        isActive = false;
        initialForce = new Vector2(100.0f, 300.0f);
        startPosition = transform.position;
    }

    void Update() {
        if(!isActive && player != null) {
            var position = transform.position;
            position.x = player.transform.position.x;

            transform.position = position;
        }

        if(isActive && transform.position.y < -5.3f) {
            isActive = !isActive;
            var position = startPosition;
            if(player != null) {
                position.x = player.transform.position.x;
            }

            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0.0f;
            transform.position = position;
            player.Lives--;
        }

        if(Input.GetButtonDown("Jump")) {
            if(!isActive) {
                rigidbody.AddForce(initialForce);
                isActive = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(isActive) {
            audio.PlayOneShot(hitSound);
        }
    }
}
