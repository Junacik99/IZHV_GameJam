using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandstormSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] storms;
    private GameObject activeStorm;
    [SerializeField]
    float minInactive = 10f;
    [SerializeField]
    float maxInactive = 30f;
    [SerializeField]
    float minActive = 30f;
    [SerializeField]
    float maxActive = 120f;
    // Start is called before the first frame update
    void Awake()
    {
        storms = GameObject.FindGameObjectsWithTag("Storm");
        foreach(var storm in storms)
            storm.SetActive(false);
        activeStorm = null;

        StartCoroutine(SpawnStorm());
    }

    
    IEnumerator SpawnStorm()
    {
        // No storm is active for inactiveTime in seconds
        activeStorm = null;
        float inactiveTime = Random.Range(minInactive, maxInactive);
        yield return new WaitForSeconds(inactiveTime);

        // Select random storm and activate it
        activeStorm = storms[Random.Range(0, storms.Length)];
        activeStorm.SetActive(true);

        // Storm is active for activeTime in seconds
        float activeTime = Random.Range(minActive, maxActive);
        yield return new WaitForSeconds(activeTime);

        // Deactivate storm
        activeStorm.SetActive(false);

        // Recursively start coroutines
        StartCoroutine(SpawnStorm());
    }
}
