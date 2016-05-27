using UnityEngine;
using System.Collections;

public class PlayerAttacks : MonoBehaviour {

    public GameObject fireballAttackPrefab;
    private Rigidbody2D _rigidBody;

    // Use this for initialization
    void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            castFireball();
        }
    }

    private void castFireball() {
        GameObject newFireball = (GameObject)Instantiate(fireballAttackPrefab, this.transform.position, this.transform.rotation);
        newFireball.GetComponent<Fireball>().setDirection(_rigidBody.transform.forward);
    }
}
