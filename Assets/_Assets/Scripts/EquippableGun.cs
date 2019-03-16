using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;
//using Valve.VR.InteractionSystem;

[RequireComponent(typeof(ProjectileFire))]
public class EquippableGun : MonoBehaviour
{
    ProjectileFire projectileFire;

    //public SteamVR_Action_Single actionThrottle = SteamVR_Input.GetAction<SteamVR_Action_Single>("buggy", "Throttle");
   // private Interactable interactable;
    float trigger = 0;

    // Start is called before the first frame update
    void Start()
    {
        projectileFire = GetComponent<ProjectileFire>();
        //interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (interactable != null && interactable.attachedToHand)        // Genereates error. Not set to an instance of an object. TODO
        //{
           // SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

            //trigger = actionThrottle.GetAxis(hand);
            if (trigger > 0.5f)
            {
                projectileFire.isFireing = true;
            }
            else
            {
                projectileFire.isFireing = false;
            }
       // }
    }
}
