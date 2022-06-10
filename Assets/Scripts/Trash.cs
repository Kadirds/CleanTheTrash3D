using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 17f;

    TrashMove trashMoveScript;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        trashMoveScript = gameObject.GetComponent<TrashMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash Detector")
        {
            trashMoveScript.enabled = true;
        }
    }
}
