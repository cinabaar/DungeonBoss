using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float timeAlive = 5.0f;
    public float damage = 100.0f;
    public float speed = 1.0f;

    private Rigidbody2D _fireBallBody;

    // Use this for initialization
    void Start() {
        _fireBallBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        timeAlive = timeAlive - 0.05f;
        destroyBallIfTimeHasPassed();
    }

    private void destroyBallIfTimeHasPassed() {
        if (timeAlive <= 0.0f) {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collisionInfo) {
        if(hasHitWall(collisionInfo)) {
            Destroy(gameObject);
        }
    }

    private bool hasHitWall(Collision2D collisionInfo) {
        return collisionInfo.gameObject.name == "WallBottom" 
            || collisionInfo.gameObject.name == "WallTop" 
            || collisionInfo.gameObject.name == "WallRight" 
            || collisionInfo.gameObject.name == "WallLeft";
    }
}
