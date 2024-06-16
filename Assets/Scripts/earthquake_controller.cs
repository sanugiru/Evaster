using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthquake_controller : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] float rotationSpeed = 1.0f;  // Speed of the oscillation
    [SerializeField] float rotationAngle = 1.0f;  // Maximum rotation angle in degrees

    private Vector3 initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (targetObject != null)
        {
            initialRotation = targetObject.transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            float angle = Mathf.Sin(Time.time * rotationSpeed) * rotationAngle;
            targetObject.transform.eulerAngles = new Vector3(initialRotation.x + angle, initialRotation.y, initialRotation.z);
        }
    }
}
