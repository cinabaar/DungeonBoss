using UnityEngine;
using System.Collections;

public class FireballAttack : MonoBehaviour {

    float attackSpeed = 10.0f;
    private Fireball fireball;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)) {
            castFireball();
        }
	}

    private void castFireball() {
        Fireball newFireball = (Fireball)Instantiate(fireball, transform.position, transform.rotation);
        Debug.Log("SZCZELAM");
    }
}
