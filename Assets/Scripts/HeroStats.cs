using UnityEngine;
using System.Collections;

public class HeroStats : MonoBehaviour {
    public float Health = 1000.0f;
    public float FireballDamage = 10.0f;

    private float MaxHealth;
    void Start () {
        this.MaxHealth = this.Health;
    }
	
	void Update () {
        if (Health >= 0.0f) {
            this.gameObject.GetComponent<HealthBar>().updateHealthBar(this.Health, this.MaxHealth);
        }
	}
}
