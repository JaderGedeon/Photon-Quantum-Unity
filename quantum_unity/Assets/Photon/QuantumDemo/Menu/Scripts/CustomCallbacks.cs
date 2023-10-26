using Quantum;
using UnityEngine;

public class CustomCallbacks : QuantumCallbacks 
{
    public RuntimePlayer PlayerData;

    public override void OnGameStart(QuantumGame game) 
    {
        // paused on Start means waiting for Snapshot
        if (game.Session.IsPaused) return;

        foreach (var lp in game.GetLocalPlayers()) 
        {
            Debug.Log("CustomCallbacks - sending player: " + lp);
            game.SendPlayerData(lp, PlayerData);
        }
    }

    public override void OnGameResync(QuantumGame game)
    {
        Debug.Log("Detected Resync. Verified tick: " + game.Frames.Verified.Number);
    }
}

