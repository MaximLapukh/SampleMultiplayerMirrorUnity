using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove1 : MonoBehaviour
{
    [Header("Global links")]
    public Transform Player;
    [Header("Configuration")]
    [SerializeField] float _smooth = 2;
    [SerializeField] float _powerRotate = 10;
    [SerializeField] float _angleHorizontal = 80;

    private Transform _camera;
    private float _xRot;
    void Start()
    {
        _camera = GetComponentInChildren<Camera>().transform.parent;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void Update()
    {
        transform.position = Player.position;
        Vector3 rot = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        rot *= _powerRotate * Time.deltaTime;
        _xRot -= rot.y;
        _xRot = Mathf.Clamp(_xRot, -50, 0);
        _camera.localRotation = Quaternion.Euler(_xRot,0,0);
        transform.Rotate(Vector3.up * rot.x);
    }
}
