using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using Unity.VisualScripting;
using UltimateXR.Avatar;
using UltimateXR.Devices;
using UltimateXR.Core;
using System;
using UltimateXR.Haptics;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    private UxrGrabbableObject _grabbableObject;
    private bool isBeingGrabbed;
    private bool isPressed;
    private void Start()
    {
        _grabbableObject = GetComponent<UxrGrabbableObject>();
        isBeingGrabbed = UxrGrabManager.Instance.IsBeingGrabbed(_grabbableObject);

        //_particleSystem.Play();
        print("particle started");
    }

    private void Update()
    {
        isBeingGrabbed = UxrGrabManager.Instance.IsBeingGrabbed(_grabbableObject);
        if (isBeingGrabbed)
        {
            //Extinguish();
            if ((UxrGrabManager.Instance.GetGrabbingHand(_grabbableObject, 0, out UxrGrabber grabber) &&
                (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(grabber.Side, UxrInputButtons.Trigger))))
            {
                isPressed = true;
                _particleSystem.Play();

                // print("button pressed");
                // _particleSystem.Emit(100);
                // UxrAvatar.LocalAvatar.ControllerInput.SendGrabbableHapticFeedback(_grabbableObject, UxrHapticClipType.RumbleFreqNormal);
            }
            //UxrAvatar.LocalAvatar.ControllerInput.SendGrabbableHapticFeedback(_grabbableObject, UxrHapticClipType.RumbleFreqNormal);

            if (isPressed)
            {
                UxrAvatar.LocalAvatar.ControllerInput.SendGrabbableHapticFeedback(_grabbableObject, UxrHapticClipType.RumbleFreqNormal);
            }

            if (UxrAvatar.LocalAvatarInput.GetButtonsPressUp(grabber.Side, UxrInputButtons.Trigger))
            {
                _particleSystem.Stop();
                isPressed = false;
            }
        }

        //_particleSystem.Pause();

    }

    //private void Extinguish()
    //{
    //    if ((UxrGrabManager.Instance.GetGrabbingHand(_grabbableObject, 0, out UxrGrabber grabber) &&
    //            (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(grabber.Side, UxrInputButtons.Trigger))))
    //    {
    //        print("button pressed");
    //        _particleSystem.Emit(50);
    //        UxrAvatar.LocalAvatar.ControllerInput.SendGrabbableHapticFeedback(_grabbableObject, UxrHapticClipType.RumbleFreqNormal);
    //    }
    //}
}
