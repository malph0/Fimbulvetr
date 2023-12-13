using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class StructureBehavior : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float pushSpeed;
    bool push = true;
    StudioEventEmitter emitter;

    float pitch;

    MeshRenderer mesh;
    public float maxAlphaClip = 0.36f;
    public float minAlphaClip;
    public float alphaShiftSpeed;

    Vector3 torque;

    [SerializeField] float leftBound;

    // Start is called before the first frame update
    void Start()
    {
        leftBound = this.transform.position.x * -1f;
        Debug.LogFormat($"{gameObject.name}, {leftBound}");

        _rb = this.GetComponent<Rigidbody>();
        emitter = GetComponent<StudioEventEmitter>();
        pitch = Random.Range(0, 4);

        torque = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(0.2f, 0.4f), Random.Range(-0.1f, 0.1f));

        if (emitter != null)
        {
            emitter.SetParameter("JupiterPitch", pitch);
        }

        //spinOn = true;

        mesh = GetComponent<MeshRenderer>();

        //leftBound = Camera.main.ViewportToWorldPoint(new Vector3(-1f, 0, gameObject.transform.position.z)).x;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < leftBound)
        {
            Debug.Log("Destroying");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //if (spinOn == true)
        //{
        //    _rb.AddTorque(new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)) * 1000, ForceMode.Impulse);
        //    spinOn = false;
        //}

        while (push == true)
        {
            _rb.AddForce(Vector3.left
                * pushSpeed * _rb.mass * GameBehavior.Instance.globalPush
                , ForceMode.Impulse);
            _rb.AddTorque(torque * 0.4f, ForceMode.VelocityChange);
            push = false;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(alphaShift(minAlphaClip, maxAlphaClip, alphaShiftSpeed));
    }

    IEnumerator alphaShift(float alpha, float maxAlpha, float shiftSpeed)
    {
        while (alpha < maxAlpha)
        {
            alpha += shiftSpeed;
            mesh.material.SetFloat("_Cutoff", alpha);
            yield return null;
        }
        while (alpha > 0)
        {
            alpha -= shiftSpeed;
            mesh.material.SetFloat("_Cutoff", alpha);
            yield return null;
        }
    }
}
