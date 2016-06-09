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
            Destroy(this.gameObject);
        }
    }
   
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name != "Joe") {
            Destroy(this.gameObject);
            if(other.gameObject.name == "Mage") {
                //TODO: implement damage against Mage
            }
            else if(other.gameObject.name == "Paladin") {
                //ToDO: implement damage against Paladin
            }
        }
    }
}
