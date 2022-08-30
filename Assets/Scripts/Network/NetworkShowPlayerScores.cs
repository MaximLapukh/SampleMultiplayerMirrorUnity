using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkShowPlayerScores : NetworkBehaviour
{
    [SerializeField] UIText _textPlayersScores;
    private List<PlayerPresent> _players = new List<PlayerPresent>();
    //thinks: dont destroy on load scene
    void Update()
    {
        string text = "";
        foreach (var item in _players)
        {
            var playerInfo = item.GetPlayerInfo();
            text += $"{playerInfo.Item1}: {playerInfo.Item2}; \n";
        }
        _textPlayersScores.ViewText(text);
    }
    [ClientRpc]
    public void SetPlayers(List<PlayerPresent> players)
    {
        _players = players;
    }
}
