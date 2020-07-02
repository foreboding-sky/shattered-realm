using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float HP;
    public float maxHP;
    void Start()
    {
        HP = maxHP;
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Death();
        }
    }

    public void Heal(float heal)
    {
        HP += heal;
        if (HP > maxHP)
        {
            HP = maxHP;
        }

    }

    public virtual void Death()
    {

    }
}
