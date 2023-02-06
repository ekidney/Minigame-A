[System.Serializable]
public struct PlayerData
{
    public int playerPosition;
    public bool isMasterClient;
    public int score;
    public int gameExperience;

    public PlayerData (int playerPosition, bool isMasterClient, int score, int gameExperience)
    {
        this.playerPosition = playerPosition;
        this.isMasterClient = isMasterClient;
        this.score = score;
        this.gameExperience = gameExperience;
    }
}
