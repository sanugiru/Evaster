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
        /*
         type a fire can be put out using every type of extinguisher, no need for if-statement
         */
        burnableObject.Extinguish();  
    }
}
