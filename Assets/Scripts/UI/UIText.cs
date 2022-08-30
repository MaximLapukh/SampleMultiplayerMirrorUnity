using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    [SerializeField] Text _text;
    public void ViewText(string text)
    {
        _text.text = text;
    }
}
