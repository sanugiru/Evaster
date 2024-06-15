using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeTrigger : MonoBehaviour
{
    public Earthquake earthquakeScript; // Referensi ke skrip Earthquake

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aktifkan gempa
            if (earthquakeScript != null)
            {
                StartCoroutine(earthquakeScript.StartEarthquake());
            }
        }
    }
}
