using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLoop : MonoBehaviour
{

    private FMOD.Studio.EventInstance instance;

    public FMODUnity.EventReference fmodEvent;

    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    private void Update()
    {
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    private void OnDestroy()
    {
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
