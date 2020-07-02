using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;
    bool isInteracting = false;
    bool hasInteracted = false;

    Transform player;
    public virtual void Interact()
    {
        Debug.Log("interacting with" + transform.name);
    }
    void Update()
    {
        if (isInteracting && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
            else
            {
                Debug.Log("NOT INTERACTING");
                NotInteracting();
            }
        }
    }
    public void OnInteraction(Transform playerTransform)
    {
        player = playerTransform;
        isInteracting = true;
    }
    public void NotInteracting()
    {
        player = null;
        isInteracting = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

