using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    Trash trashScript;

    void Start()
    {
        trashScript = gameObject.GetComponent<Trash>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, trashScript.playerTransform.position, trashScript.moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player Bubble")
        {
            Destroy(gameObject);
        }
    }
}
