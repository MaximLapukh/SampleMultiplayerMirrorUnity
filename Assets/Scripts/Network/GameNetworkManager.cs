using Mirror;
using System.Collections.Generic;

public class GameNetworkManager : NetworkManager
{
	private NetworkShowPlayerScores _showScore;
    private NetworkWinConditions _winConditions;
    public static new GameNetworkManager singleton { get; private set; }

    private void Awake()
    {
        FindLinks();
    }
    public override void OnClientSceneChanged()
    {
        base.OnClientSceneChanged();
        FindLinks();
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
    //thinks: ReUpdate when some player had disconnect
    private void UpdateLinkPlayers()
    {
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
