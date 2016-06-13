using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public Texture2D HpBarTexture;
    private float lengthOfHpBar;
    private float percentOfHP;
    void Start () {
        
    }

    void OnGUI() {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;

        GUI.DrawTexture(new Rect(screenPosition.x - 50, screenPosition.y - 100, lengthOfHpBar, 10), HpBarTexture);
    }

    void Update () {
        float currentHealth = this.gameObject.GetComponent<EnemyStats>().Health;
        float maxHealth = this.gameObject.GetComponent<EnemyStats>().getMaxHealth();

        percentOfHP = currentHealth / maxHealth;
        lengthOfHpBar = percentOfHP * 100;
    }
}
