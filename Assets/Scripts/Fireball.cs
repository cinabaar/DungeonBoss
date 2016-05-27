using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float timeAlive = 5.0f;
    public float damage = 100.0f;
    public float speed = 1.0f;

    private Rigidbody2D _fireBallBody;
    private Vector2 direction;

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
        Destroy(gameObject);
    }

    public void setDirection(Vector2 direction) {
        this.direction = direction;
    }
}
