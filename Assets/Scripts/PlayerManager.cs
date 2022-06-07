using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Transform player;
    private Vector3 startMousePos, StartPlayerPos;
    private bool moveThePlayer;
    [Range(0.1f,1f)]public float maxSpeed;
    [Range(0.1f, 1f)] public float CamSpeed;
    private float velocity,camVelocity;
    private Camera mainCam;

    void Start()
    {
        player = transform;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveThePlayer = true;

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray,out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                StartPlayerPos = player.position;
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            moveThePlayer = false;
        }

        if (moveThePlayer)
        {
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startMousePos;
                Vector3 DesiredPlayerPos = MouseNewPos + startMousePos;

                DesiredPlayerPos.x = Mathf.Clamp(DesiredPlayerPos.x, -5.65f, 2.75f);

                player.position = new Vector3(Mathf.SmoothDamp(player.position.x,DesiredPlayerPos.x,ref velocity,maxSpeed)
                    , player.position.y, player.position.z);
            }
        }

        
    }

    private void LateUpdate()
    {
        var CameraNewPos = mainCam.transform.position;

        mainCam.transform.position = new Vector3(Mathf.SmoothDamp(CameraNewPos.x, player.position.x, ref camVelocity, CamSpeed), CameraNewPos.y, CameraNewPos.z);
    }
}
