using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
    [SerializeField] private Text captionScore;
    [SerializeField] private AudioClip lifeSound;
    [SerializeField] private AudioClip pointSound;
    [SerializeField] private RectTransform livesBar;
    [SerializeField] private ToggleSprite muteButton;

    private new AudioSource audio;
    private Transform[] hearts = new Transform[3];

    [SerializeField] private int lives = 3;
    [SerializeField] private int score = 0;

    private void Awake() {
        audio = GetComponent<AudioSource>();
        for(int i = 0; i < hearts.Length; i++) {
            hearts[i] = livesBar.transform.GetChild(i);
        }
    }

    private void Start() {
        UpdateLives(lives);
        UpdateScore(score);

        Messenger<int>.AddListener(GameEvent.CHANGE_LIVES, OnChangeLives);
        Messenger<int>.AddListener(GameEvent.CHANGE_SCORE, OnChangeScore);
    }

    private void OnDestroy() {
        Messenger<int>.RemoveListener(GameEvent.CHANGE_LIVES, OnChangeLives);
        Messenger<int>.RemoveListener(GameEvent.CHANGE_SCORE, OnChangeScore);
    }

    private void OnChangeScore(int score) {
        audio.PlayOneShot(pointSound);
        UpdateScore(score);
    }

    private void UpdateScore(int score) {
        this.score += score;
        captionScore.text = $"Score: {this.score}";
    }

    private void OnChangeLives(int lives) {
        audio.PlayOneShot(lifeSound);
        UpdateLives(lives);
    }

    private void UpdateLives(int lives) {
        for(int i = 0; i < hearts.Length; i++) {
            if(i < lives) {
                hearts[i].gameObject.SetActive(true);
            } else {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnSoundToggle() {
        muteButton.IsOn = !muteButton.IsOn;
        AudioListener.pause = !muteButton.IsOn;
    }
}
