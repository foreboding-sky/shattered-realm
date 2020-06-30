using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        base.Interact();
        PickUp();

    }
    void PickUp()
    {
        Debug.Log("pick up");
        Destroy(gameObject);
    }

}
