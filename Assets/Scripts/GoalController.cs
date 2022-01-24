using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField]
    private GameObject miningSlider;
    [SerializeField]
    private GameObject scanHintText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            scanHintText.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            scanHintText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                miningSlider.SetActive(true);
                scanHintText.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
}
