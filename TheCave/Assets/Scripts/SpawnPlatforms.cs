using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField]
    Platforms platformsPrefabs;

    [SerializeField]
    Transform platformTransform;

    [SerializeField]
    float chronometer;

    [SerializeField]
    Platforms currentPrefabs;

    GameObject elementA;

    GameObject elementB;


    private void Update()
    {
        CheckSpawn();

        print(currentPrefabs);

    }

    void CheckSpawn()
    {
        if (currentPrefabs != null && currentPrefabs.test)
        {   
            //Spawn();
            //StartCoroutine(platformsPrefabs.myCourritine());

            currentPrefabs = null;
            
            platformsPrefabs.test = false;

            Debug.Log(platformsPrefabs.test);
        }
    }

    /*
    void Spawn()
    {

        //Platforms platformsCopy = Instantiate(platformsPrefabs, platformTransform.position, Quaternion.identity);

        //platformsCopy.SetPlatform(elementA, elementB);

        currentPrefabs = Instantiate(platformsPrefabs, platformTransform.position, Quaternion.identity);

        currentPrefabs.SetPlatformScript(currentPrefabs);

        currentPrefabs.SetPlatform(elementA, elementB);

        Debug.Log("Spawn");

    }
    */

    public void GetPLatform(GameObject a, GameObject b)
    {
        elementA = a; 
        
        elementB = b;
    }

}
