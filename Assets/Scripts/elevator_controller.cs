using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Collider buttonCollider;
    public Collider playerRightHandCollider;
    public Collider playerLeftHandCollider;
    public GameObject targetObject; // The object to teleport
    public Transform teleportDestination; // The destination to teleport to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonCollider.bounds.Intersects(playerRightHandCollider.bounds) || buttonCollider.bounds.Intersects(playerLeftHandCollider.bounds))
        {
            Debug.Log("Button pressed");
            TeleportObject();
        }
    }

    void TeleportObject()
    {
        if (targetObject != null && teleportDestination != null)
        {
            targetObject.transform.position = teleportDestination.position;
            Debug.Log("Object teleported to destination");
        }
        else
        {
            Debug.LogWarning("Target object or teleport destination not set");
        }
    }
}
