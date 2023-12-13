using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] GameObject[] projectile;

    bool[] Launching = new bool[8];
    //char[] controlKeys = new char[8] { 'Q', 'W', 'E', 'A', 'D', 'Z', 'X', 'C' };
    private KeyCode[] keyCodes = new KeyCode[8] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.A, KeyCode.D, KeyCode.Z, KeyCode.X, KeyCode.C}; 

    [SerializeField] float projectileVelocity = 25;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                Launching[i] = true;
                
            }
        }

        
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 8; i++)
        {
            if (Launching[i] == true)
            {
                GameBehavior.Instance.projPitch = i;
               
                GameObject newProjectile = Instantiate(projectile[i],
                    GameObject.Find($"Launch{i + 1}").transform.position,
                    new Quaternion(0, 0, 0, 0));
                Rigidbody projRB = newProjectile.GetComponent<Rigidbody>();
                projRB.velocity = Vector3.forward * projectileVelocity;

                
            }
        }
        for (int i = 0; i < 8; i++)
        {
            Launching[i] = false;
        }

    }
}
