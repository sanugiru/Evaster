using FernandoOleaDev.FyreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_C : MonoBehaviour
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
        if (other.CompareTag("TypeA") || other.CompareTag("TypeB"))
        {
            if (!burnableObject.IsBurning()) burnableObject.FirstIgnition();
            Debug.Log("typea");
            Debug.Log("particlehit");
            return;
        }
        burnableObject.Extinguish();
    }
}
