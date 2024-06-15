using FernandoOleaDev.FyreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_B : MonoBehaviour
{
    private BurnableObject burnableObject;
    //[SerializeField] private BurnableObject fireSource;
    //[SerializeField] private GameObject random;
    //private int type;
    
    void Start()
    {
        burnableObject = GetComponent<BurnableObject>();
        //fireSource = GetComponent<BurnableObject>();
        //type = random.GetComponent<RandomizeOnStart>().type;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("TypeA"))
        {
            //if (!burnableObject.IsBurning() && fireSource.IsBurning()) burnableObject.FirstIgnition();
            //Debug.Log("typea");
            //Debug.Log("particlehit");
            return;
        }
        burnableObject.Extinguish();
    }
}
