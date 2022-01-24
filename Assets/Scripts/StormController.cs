using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormController : MonoBehaviour
{
    [SerializeField]
    private BatteryController batteryController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            batteryController.inStorm = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            batteryController.inStorm = false;
    }
}
