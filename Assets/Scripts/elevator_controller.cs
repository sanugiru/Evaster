using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_controller : MonoBehaviour
{
    public Collider buttonCollider;
    public Collider playerRightHandCollider;
    public Collider playerLeftHandCollider;
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
        }
    }
}
