using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public float earthquakeDuration = 5.0f; // Durasi gempa
    public float earthquakeMagnitude = 10.0f; // Kekuatan gempa
    public float shakeInterval = 0.1f; // Interval antara setiap guncangan
    public CameraShake cameraShake; // Referensi ke skrip CameraShake

    private bool isQuaking = false;

    void Start()
    {
        if (cameraShake == null)
        {
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
    }

    public IEnumerator StartEarthquake()
    {
        isQuaking = true;
        float endTime = Time.time + earthquakeDuration;

        if (cameraShake != null)
        {
            cameraShake.StartShake(earthquakeDuration, earthquakeMagnitude * 0.01f);
        }

        while (Time.time < endTime)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("AffectedByQuake");
            foreach (GameObject obj in objects)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 quakeForce = Random.insideUnitSphere * earthquakeMagnitude;
                    quakeForce.y = 0; 
                    rb.AddForce(quakeForce, ForceMode.Impulse);
                }
            }
            yield return new WaitForSeconds(shakeInterval);
        }

        isQuaking = false;
    }
}