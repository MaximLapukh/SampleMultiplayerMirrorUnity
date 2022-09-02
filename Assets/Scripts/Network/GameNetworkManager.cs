using Mirror;
using System.Collections.Generic;

public class GameNetworkManager : NetworkManager
{
	private NetworkShowPlayerScores _showScore;
    private NetworkWinConditions _winConditions;
    public static new GameNetworkManager singleton { get; private set; }

    public override void OnClientSceneChanged()
    {
        base.OnClientSceneChanged();
        UpdateLinkPlayers();
    }

    private void FindLinks()
    {
        _showScore = FindObjectOfType<NetworkShowPlayerScores>();
        _winConditions = FindObjectOfType<NetworkWinConditions>();
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        UpdateLinkPlayers();
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        UpdateLinkPlayers();
    }
    
    private void UpdateLinkPlayers()
    {
        FindLinks();//fix: Invoke costly operations that can be invoke in only one
        var players = RefindAllPlayers();
        _showScore.SetPlayers(players);
        _winConditions.SetPlayers(players);
    }
    //thinks: look bad 
    public List<PlayerPresent> RefindAllPlayers()
    {
        List<PlayerPresent> players = new List<PlayerPresent>();
        
        foreach (var item in FindObjectsOfType<PlayerPresent>())
        {
            players.Add(item);
        }
        return players;
    }
}
