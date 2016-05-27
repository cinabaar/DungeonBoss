using UnityEngine;
using System.Collections;

public class PlayerAttacks : MonoBehaviour {

    public GameObject fireballAttackPrefab;
    private Rigidbody2D _rigidBody;
    private Plane clickPlane;
    // Use this for initialization
    void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
        clickPlane = new Plane(-Vector3.forward, Vector3.zero);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            castFireball();
        }
    }

    private void castFireball() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        if (clickPlane.Raycast(ray, out dist)) {
            Vector3 direction = (ray.GetPoint(dist) - _rigidBody.transform.position).normalized;
            GameObject newFireball = (GameObject)Instantiate(fireballAttackPrefab, this.transform.position, Quaternion.identity);
            newFireball.GetComponent<Rigidbody2D>().AddForce(direction * 20, ForceMode2D.Impulse);
        }
    }
}
