using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float timeAlive = 5.0f;
    private float damage;
    public float speed = 1.0f;

    private Rigidbody2D _fireBallBody;

    // Use this for initialization
    void Start() {
        _fireBallBody = GetComponent<Rigidbody2D>();
        this.damage = this.GetComponent<HeroStats>().FireballDamage;
    }

    // Update is called once per frame
    void Update() {
        timeAlive = timeAlive - 0.05f;
        destroyBallIfTimeHasPassed();
    }

    private void destroyBallIfTimeHasPassed() {
        if (timeAlive <= 0.0f) {
            Destroy(this.gameObject);
        }
    }
   
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name != "Joe") {
            Destroy(this.gameObject);
            if(hasHitEnemy(other)) {
                other.gameObject.GetComponent<EnemyStats>().takeDamage(this.damage);
            }
        }
    }

    private bool hasHitEnemy(Collider2D other) {
        return other.gameObject.name == "Wizzard" || other.gameObject.name == "Paladin";
    }
}
