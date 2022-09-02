using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepCurcorInWindow : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
