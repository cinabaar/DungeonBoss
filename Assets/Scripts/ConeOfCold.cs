using UnityEngine;
using System.Collections;

public class ConeOfCold : MonoBehaviour {

    public float damage = 1.0f;

    private Rigidbody2D coneOfColdBody;

    void Start () {
        coneOfColdBody = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
	
	}

    private void OnTriggerEnter2d(Collider collider) {
        //TODO: implement damage
    }
}
