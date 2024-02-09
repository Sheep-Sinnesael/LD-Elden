using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<ThirdPersonController>(out var controller))
        {
            return;
        }
        
        controller._isClimbing = true;
   
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<ThirdPersonController>(out var controller))
        {
            return;
        }
        
        controller._isClimbing = false;
        
    }
}
