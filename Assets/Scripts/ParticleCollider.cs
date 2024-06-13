using FernandoOleaDev.FyreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour
{
    private BurnableObject burnableObject;

    private void Start()
    {
        burnableObject = GetComponent<BurnableObject>();
    }
    private void OnParticleCollision(GameObject other)
    {
        //if (other.CompareTag("OnFire"))
        //{
        //Debug.Log("Particle Hit!");
        burnableObject.Extinguish();
        //}

        //seconds = other.GetComponent<BurnableObject>();

    }
}
