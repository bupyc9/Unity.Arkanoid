using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float velocity;
    public float boundary;

    [SerializeField] private int lives = 3;

    public int Lives {
        get { return lives; }
        set {
            lives = value;
            Messenger<int>.Broadcast(GameEvent.CHANGE_LIVES, lives);
        }
    }

    void Update() {
        var postion = transform.position;

        var x = postion.x;
        x += Input.GetAxis("Horizontal") * velocity * Time.deltaTime;

        if(x < -boundary) {
            x = -boundary;
        }
        if(x > boundary) {
            x = boundary;
        }
        postion.x = x;

        transform.position = postion;

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
