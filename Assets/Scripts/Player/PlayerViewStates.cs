using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerViewStates : MonoBehaviour
{
    [Header("Materials States")]
    [SerializeField] Material _matDefault;
    [SerializeField] Material _matJump;
    [SerializeField] Material _matHurt;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SetStateByIndex(int index)
    {
        if (index == 1)
            _meshRenderer.material = _matHurt;
        else if (index == 2)
            _meshRenderer.material = _matJump;
        else
            _meshRenderer.material = _matDefault;
    }
}
