using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public override void Death()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene(0);
            Debug.Log("ded");
            HP = maxHP;
        }
    }
}
