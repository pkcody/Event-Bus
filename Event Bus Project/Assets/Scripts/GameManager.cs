using UnityEngine;
// Inheriting Singleton and specifying the type.
public class GameManager : Singleton<GameManager>
{
    public void InitializeGame()
    {
        Debug.Log("Initializing the game.");
    }
}
