﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    [SerializeField]
    float hitPoint;

    public event System.Action OnDeath;
    public event System.Action OnDamageReceived;

    float damageTaken;

    public float HitPointRemaining
    {
        get
        {
          return  hitPoint - damageTaken;
        }
    }
    public bool IsAlive
    {
        get
        {
            return HitPointRemaining > 0;
        }
    }
    public virtual void Die()
    {
        if (!IsAlive)
            return;
        if (OnDeath != null)
            OnDeath();
    }

    public virtual void TakeDamage(float amount)
    {
        damageTaken += amount;

        if (OnDamageReceived != null)
            OnDamageReceived();
        if (HitPointRemaining <= 0)
        {
            Die();
        }
    }
    public void Reset()
    {
        damageTaken = 0;
    }
}
