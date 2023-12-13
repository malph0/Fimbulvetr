using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ProjectileBehavior : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 11.0f);
        Rigidbody projRB = gameObject.GetComponent<Rigidbody>();

        // I could not, for the life of me, figure out why the parameter wouldn't change. That's why there's so many prefabs as a solution.

        //emitter = gameObject.GetComponent<StudioEventEmitter>();

        //Debug.LogFormat($"{GameBehavior.Instance.projPitch}");
        //emitter.SetParameter("Note", GameBehavior.Instance.projPitch);
        //emitter.Play();

        float regenVenus = Random.Range(0.0f, 1.0f);

        

        if (regenVenus >= 0.25f && GameBehavior.Instance.venusCount < 2)
        {
            GameObject newVenus = Instantiate(GameBehavior.Instance.venus, GameBehavior.Instance.CalculateSpawnPosition(500, 50), Quaternion.identity);
            GameBehavior.Instance.venusCount++;
        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        //if (playingSound)
        //{
        //    for (int i = 0; i < 8; i++)

        //        if (gameObject.transform.position.x == GameBehavior.Instance.locations[i].transform.position.x && gameObject.transform.position.y == GameBehavior.Instance.locations[i].transform.position.y)
        //        {
                    
        //            Debug.Log($"{i}");
                    
        //        }
        //    playingSound = false;
        //}
        
        //for (int i = 0; i < 8; i++)
        //{
        //    if (Input.GetKeyDown(arrowCodes[i]))
        //    {
        //        activeControls[i] = true;
        //    }
        //}
    }

    private void FixedUpdate()
    {
        
    }

}
