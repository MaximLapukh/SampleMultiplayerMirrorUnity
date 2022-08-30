using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkWinConditions : NetworkBehaviour
{
    [SerializeField] int _needToWinScore = 3;
    [SerializeField] float _timeRestart = 5;
    [SerializeField] UIWinScreen _winScreen;
    private List<PlayerPresent> _players = new List<PlayerPresent>();

    private bool _win;
 
    void Update()
    {
        if (!isServer) return;
        if (_win) return;

        foreach (var item in _players)
        {
            var playerInfo = item.GetPlayerInfo();
            if(playerInfo.Item2 >= _needToWinScore)
            {
                ViewWin(playerInfo.Item1);
                StartCoroutine(RestartScene());
                _win = true;
            }
        }
    }
    [ClientRpc]
    public void ViewWin(string playerName)
    {
        _winScreen.ViewWin(playerName);
    }
    public IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(_timeRestart);
        NetworkManager.singleton.ServerChangeScene(SceneManager.GetActiveScene().name);
        _win = false;
    }
    [ClientRpc]
    public void SetPlayers(List<PlayerPresent> players)
    {
        _players = players;
    }
}
