using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float timeAlive = 10.0f;
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
        var mousePosition = Input.mousePosition;
        mousePosition.z = 32;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosition);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //this._fireBallBody.transform.Translate(Vector3.forward * speed);
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
