using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnterEvent : MonoBehaviour
{
    public event Action<Collision> EnterEvent = delegate { };

    private void OnCollisionEnter(Collision collision)
    {
        EnterEvent.Invoke(collision);
    }
    private void OnDestroy()
    {
        EnterEvent = delegate { };
    }
}
