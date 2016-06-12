using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class EnemyStats : MonoBehaviour
{
    public float Strength;
    public float Health;
    public float SpellResistance;

    public void takeDamage(float amount) {
        this.Health = this.Health - (amount - this.SpellResistance);
        checkIfShouldDie();
    }

    private void checkIfShouldDie() {
        if (this.Health <= 0) {
            Destroy(this.gameObject);
        }
    }
}