using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    [SerializeField] private int hitsToKill;
    [SerializeField] private int points;

    private int numberOfHits;

    void Start() {
        numberOfHits = 0;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Ball")) {
            numberOfHits++;

            if(numberOfHits == hitsToKill) {
                Messenger<int>.Broadcast(GameEvent.CHANGE_SCORE, points);
                Destroy(gameObject);
            }
        }
    }
}
