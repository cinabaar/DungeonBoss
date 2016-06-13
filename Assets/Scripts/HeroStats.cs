using UnityEngine;
using System.Collections;

public class HeroStats : MonoBehaviour {
    public float Health = 1000.0f;
    public float FireballDamage = 50.0f;

    private float MaxHealth;

    private GUIStyle guiStyle = new GUIStyle();
    void Start () {
        this.MaxHealth = this.Health;
    }
	
    void OnGUI() {
        if (Health <= 0.0f) {
            guiStyle.fontSize = 60;
            guiStyle.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width, Screen.height), "YOU DIED!", guiStyle);
        }
    }

	void Update () {
        if (Health >= 0.0f) {
            this.gameObject.GetComponent<HealthBar>().updateHealthBar(this.Health, this.MaxHealth);
        }
        if (Health <= 0.0f) {
            Destroy(this.gameObject); //DEATH
        }
	}
}
