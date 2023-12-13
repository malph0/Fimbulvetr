using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FireSound : MonoBehaviour
{
    //StudioEventEmitter emitter;
    //bool playing;

    private FMOD.Studio.EventInstance instance;

    public FMODUnity.EventReference fmodEvent;

    public string fmodEventPath = "event:/Firing 3D"; // Replace with your FMOD event path
    public string parameterName = "Note"; // Replace with your parameter name
    public float parameterValue = 0.0f; // Replace with the desired initial parameter value

    private void Awake()
    {
        //instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);

        //instance.start();

        //instance.setParameterByName("Note", GameBehavior.Instance.projPitch);
    }
    // Start is called before the first frame update
    void Start()
    {

        

        //emitter = gameObject.GetComponent<StudioEventEmitter>();

        

        //if (emitter != null)
        //{
        //    Debug.LogFormat($"{GameBehavior.Instance.projPitch}");
        //    playing = true;
        //}
        //else
        //{
        //    Debug.Log("No emitter!");
        //}
        
    }

    private void Update()
    {
        //if (playing)
        //{
        //    emitter.SetParameter("Note", GameBehavior.Instance.projPitch);
        //    emitter.Play();
        //    playing = false;
        //}
    }
}
