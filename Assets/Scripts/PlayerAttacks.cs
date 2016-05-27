using UnityEngine;
using System.Collections;

public class PlayerAttacks : MonoBehaviour {

    public GameObject fireballAttackPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            castFireball();
        }
    }

    private void castFireball() {
        GameObject newFireball = (GameObject)Instantiate(fireballAttackPrefab, transform.position, transform.rotation);
        Debug.Log("SZCZELAM");
    }
}
