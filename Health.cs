using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health :Destructable {

    public override void Die()
    {
        base.Die();

        print("we died");
    }
    public override void TakeDamage(float amount)
    {
        print("Remaining" + HitPointRemaining);
        base.TakeDamage(amount);
    }
}
