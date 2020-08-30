using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caprica;

public class UniverseManager : MonoBehaviour {

    // This script is responsible for holding the main Galaxy data object,
    // triggering file save/loads or triggering the generation of a new galaxy.

    // Maybe also gets callbacks from end turn button?

	// Use this for initialization
	void Start ()
    {
        Generate();
    }


    public Galaxy galaxy { get; protected set; }


    public void EndTurn()
    {
        Player currPlayer = galaxy.GetCurrentPlayer();
        if (currPlayer.isUIControlled)
        {
            galaxy.AdvanceCurrentPlayer();
        }
    }


    // Update is called once per frame
    void Update ()
    {
        if (galaxy is null)
        {
            Debug.LogError("Galaxy is null");
            return;
        }
        Player currPlayer = galaxy.GetCurrentPlayer();
        if (currPlayer is null)
        {
            Debug.LogError("No current player");
            return;
        }

        bool turnInProgress = currPlayer.DoTurn();

        if (turnInProgress)
        {
            // Current player still working on turn
        }
        else
        {
            // Current player DONE
            galaxy.AdvanceCurrentPlayer();

            // If hotseat game then do 
            // if new current player is human then update PlayerHuman
        }
	}

    public void Generate()
    {
        Debug.Log("UniverseManager::Generate -- Generating a new Galaxy");

        galaxy = new Galaxy();
        galaxy.Generate();

        // Tell our visual system to spawn the graphics
        ViewManager.Instance.galaxyVisuals.InitiateVisuals(galaxy);
    }
}
