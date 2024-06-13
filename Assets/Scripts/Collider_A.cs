using FernandoOleaDev.FyreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_A : MonoBehaviour
{
    private BurnableObject burnableObject;
    // Start is called before the first frame update
    void Start()
    {
        burnableObject = GetComponent<BurnableObject>();
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        //if (other.CompareTag("TypeA")) 
        //{
        //    Debug.Log("typeA");
        //    Debug.Log("particlehit");
            burnableObject.Extinguish(); 
        //}
           
    }
}
