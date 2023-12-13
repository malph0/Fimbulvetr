using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    
    public float globalPush;

    public static GameBehavior Instance;

    public float lullacry;
    public int projPitch;

    public float xShift;

    int jupiterDistance = 1000;
    int venusDistance = 500;
    int moonDistance = 115;

    public GameObject venus;
    public GameObject moon;
    public GameObject jupiter;
    public GameObject wanderLight;

    public GameObject[] locations = new GameObject[8];

    private bool spaceClear;

    public float lightInterval;
    public float lightChance;

    public int venusCount;
    public int moonCount;
    public int jupiterCount;

    float jupiterRadius = 1800;
    float moonRadius = 50;
    float venusRadius = 50;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(instantiateWait(lullacry));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jupiterCount < 1)
        {
            GameObject firstJupiter = Instantiate(jupiter, CalculateSpawnPosition(jupiterDistance, jupiterRadius), Quaternion.identity);
        }
        if (moonCount < 1 && spaceClear == true)
        {
            GameObject newMoon = Instantiate(moon, new Vector3(120, 0, 115), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator instantiateWait(float time)
    {
        yield return new WaitForSeconds(time);

        spaceClear = true;

        GameObject firstVenus = Instantiate(venus, CalculateSpawnPosition(venusDistance, venusRadius), Quaternion.identity);
        GameObject firstMoon = Instantiate(moon, CalculateSpawnPosition(moonDistance, moonRadius), Quaternion.identity);
    }

    IEnumerator wanderLightSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(lightInterval);

            if (Random.Range(0, 1) < lightChance)
            {
                GameObject newWanderLight = Instantiate(wanderLight, new Vector3(0, 0, 0), Quaternion.identity);
            }
                
        }
        
    }

    public Vector3 CalculateSpawnPosition(float distance, float size)
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("camera not found");
            return Vector3.zero;
        }

        float structureDiameter = 0;

        //SphereCollider collider = structure.GetComponent<SphereCollider>();
        //if (collider != null)
        //{
        //    structureDiameter = collider.bounds.size.x;
        //}
        //else
        //{
        //    Debug.Log("no collider!");
        //}
        
        Debug.LogFormat($"{structureDiameter}");

        float spawnZ = mainCamera.transform.position.z + distance;

        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, distance));
        spawnPosition.z = spawnZ;

        float xAdjust =  distance * xShift;
        spawnPosition.x += xAdjust;

        return spawnPosition;
    }
}
