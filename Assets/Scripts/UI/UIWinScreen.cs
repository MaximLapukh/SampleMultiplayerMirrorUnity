using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinScreen : MonoBehaviour
{
    [SerializeField] GameObject _screen;
    [SerializeField] Text _playerText;
    public void ViewWin(string playerName)
    {
        _screen.SetActive(true);
        _playerText.text = $"{playerName}";
    }
}
