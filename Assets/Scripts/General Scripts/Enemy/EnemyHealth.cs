using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Death()
    {
        if(HP <=0)
        {
            Destroy(gameObject);
        }

    }
}
