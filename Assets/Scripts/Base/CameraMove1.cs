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
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position, _smooth * Time.deltaTime);
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * _powerRotate * Time.deltaTime);
    }
}
