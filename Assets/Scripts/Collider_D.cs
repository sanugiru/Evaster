using FernandoOleaDev.FyreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_D : MonoBehaviour
{
    private BurnableObject burnableObject;
    [SerializeField] private GameObject random;
    private int type;
    // Start is called before the first frame update
    void Start()
    {
        burnableObject = GetComponent<BurnableObject>();
        type = random.GetComponent<RandomizeOnStart>().type;

    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        if (type != 3) return;
        if (other.CompareTag("TypeD"))
        {
            burnableObject.Extinguish();

        }
        else
        {
            if (!burnableObject.IsBurning()) burnableObject.FirstIgnition();
            //Debug.Log("not type d");
            //Debug.Log("particlehit");
            return;
        }
    }

}
