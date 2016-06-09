using UnityEngine;
using System.Collections;

public class PlayerAttacks : MonoBehaviour {

    public GameObject fireballAttackPrefab;
    public GameObject coneOfColdPrefab;

    private Rigidbody2D _rigidBody;
    private Plane clickPlane;
    
    void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        clickPlane = new Plane(-Vector3.forward, Vector3.zero);
        if (Input.GetMouseButtonDown(0)) {
            castFireball();
        } else if(Input.GetMouseButton(1)) {
            castConeOfCold();
        }
    }

    private void castFireball() {
		var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        var direction = (target - transform.position).normalized;
		GameObject newFireball = (GameObject)Instantiate(fireballAttackPrefab, this.transform.position, Quaternion.identity);
		newFireball.GetComponent<Rigidbody2D>().AddForce(direction * 7, ForceMode2D.Impulse);
    }

    private void castConeOfCold() {
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        var direction = (target - transform.position).normalized;
        GameObject newConeOfCold = (GameObject)Instantiate(coneOfColdPrefab, this.transform.position, Quaternion.identity);
    }
}
