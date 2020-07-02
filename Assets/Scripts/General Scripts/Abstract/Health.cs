using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    
    public float maxHP;
    public float HP;
    private float HPPct;
    public event Action<float> OnHealthChanged = delegate { };
    void OnEnable()
    {
        HP = maxHP;
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;
        HPPct = HP / maxHP;
        OnHealthChanged(HPPct);
        if (HP <= 0)
        {
            HP = 0;
            Death();
        }
    }

    public void Heal(float heal)
    {
        HP += heal;
        HPPct = HP / maxHP;
        OnHealthChanged(HPPct);
        if (HP > maxHP)
        {
            HP = maxHP;
        }

    }

    public virtual void Death()
    {

    }
}
