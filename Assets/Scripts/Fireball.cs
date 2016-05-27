using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float timeAlive = 20.0f;
    public float damage = 100.0f;
    public float speed = 1.0f;

    private Rigidbody2D _fireBallBody;

    // Use this for initialization
    void Start () {
        _fireBallBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        timeAlive = timeAlive - 0.01f;
        destroyBallIfTimeHasPassed();
    }

    private void destroyBallIfTimeHasPassed()
    {
        if (timeAlive <= 0.0f)
        {
            Destroy(this);
        }
        this.transform.Translate(Vector3.forward * speed);
    }
}
