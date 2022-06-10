using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public GameObject TrashDetectorObj;

    void Start()
    {
        TrashDetectorObj = GameObject.FindGameObjectWithTag("Trash Detector");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
