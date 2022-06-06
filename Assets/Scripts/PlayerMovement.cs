using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera m_MainCam;


    [SerializeField] private float m_Speed = 10f;
    [SerializeField] private float swipeSpeed = 10f;

    private Transform localTrans;
    private Vector3 lastMousePos;
    private Vector3 MousePos;
    private Vector3 newPosForTrans;

    

    private void Start()
    {
        localTrans = GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * m_Speed * Time.deltaTime;
        if (Input.GetMouseButton(0)) //Holding the mouse or touch
        {
            MousePos = m_MainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));

            float xDiff = MousePos.x - lastMousePos.x;

            newPosForTrans.x = localTrans.position.x + xDiff * Time.deltaTime * swipeSpeed;
            newPosForTrans.y = localTrans.position.y;
            newPosForTrans.z = localTrans.position.z;

            localTrans.position = newPosForTrans + localTrans.forward * m_Speed * Time.deltaTime;

            lastMousePos = MousePos;
        }
    }

}
