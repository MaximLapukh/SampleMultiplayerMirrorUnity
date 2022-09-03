using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keyboard and mouse input version
public class PlayerInput : MonoBehaviour
{
    public Camera Camera;
    public Action<Vector3> MoveDirection = delegate { };
    //return world point of click
    public Action<Vector3> JumpTo = delegate { };
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 cameraAngels = Camera.transform.parent.eulerAngles;
        cameraAngels.x = 0;
        cameraAngels.z = 0;
        moveDirection = Quaternion.Euler(cameraAngels) * moveDirection;
        MoveDirection.Invoke(moveDirection);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                JumpTo.Invoke(hit.point);
            }
        }
    }
    private void OnDestroy()
    {
        MoveDirection = delegate { };
    }
}
