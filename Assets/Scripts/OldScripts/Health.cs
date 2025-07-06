using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Health : MonoBehaviour
{
    //public FMODUnity.StudioEventEmitter tavernEmitter;
    private bool health = false;

    FMOD.Studio.EventInstance HealthSnap;

    public EventReference healthSnapshot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!health) // Or 'if (health)' depending on initial state and desired toggle logic
            {
                HealthSnap = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot);
                HealthSnap.start();
                health = true; // Set to true after starting
            }
            else 
            {
                HealthSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                HealthSnap.release();
                health = false; // Set to false after stopping
            }
        }
    }
}