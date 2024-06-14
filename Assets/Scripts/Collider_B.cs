using FernandoOleaDev.FyreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_B : MonoBehaviour
{
    private BurnableObject burnableObject;
    [SerializeField] private GameObject random;
    private int type;
    // Start is called before the first frame update
    void Start()
    {
        burnableObject = GetComponent<BurnableObject>();
        type = random.GetComponent<RandomizeOnStart>().type;
        
        Debug.Log(type);
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        if (type != 1) return;
        if (other.CompareTag("TypeA"))
        {
            if (!burnableObject.IsBurning()) burnableObject.FirstIgnition();
            //Debug.Log("typea");
            //Debug.Log("particlehit");
            return;
        }
        burnableObject.Extinguish();
    }
}
