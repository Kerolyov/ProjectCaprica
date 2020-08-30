using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica
{
    public static class GalaxyConfig
    {
        // This gets filled out by some kind of "New Game" screen
        // and is used by the Generate function to tune the game parameters
        public static int NumPlayers = 8;
        public static int NumStars = 50;

        // Total width/height of the range of star positions in Unity world units
        public static int GalaxyWidth = 100;

        // Consider reading the defaults from a config file
    }

    public class Galaxy
    {
        public Galaxy()
        {
            starSystems = new List<StarSystem>();
            players = new List<Player>();
        }

        private List<StarSystem> starSystems;
        private List<Planet> planets;
        private List<Colony> colonies;
        private List<Player> players;

        int currentPlayerIndex = 0;
        int turnCounter = 0;

        public Player GetPlayer(int playerIndex)
        {
            Player p = players[playerIndex];
            if (p is null)
            {
                Debug.LogError("Null player with index"+playerIndex.ToString()+", & player count"+players.Count);
            }
            return p;
        }

        public Player GetCurrentPlayer()
        {
            return GetPlayer(currentPlayerIndex);
        }

        public void AdvanceCurrentPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            if (currentPlayerIndex == 0)
                turnCounter++;
        }


        public StarSystem GetStarSystem(int StarSystemId)
        {
            return starSystems[StarSystemId];
        }

        public int GetNumStarSystems()
        {
            return starSystems.Count;
        }

        public void Generate()
        {
            // First pass, just make some random stars for us.

            int galaxyWidth = GalaxyConfig.GalaxyWidth;

            for (int i = 0; i < GalaxyConfig.NumStars; i++)
            {
                StarSystem ss = new StarSystem();
                ss.position = new Vector3(
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        0
                    );
                ss.Generate( /* Do we pass exactly what time of start system we want? */ );
                // Player starting stars are special
                // Do we want to vary star types based on distance from galactic center?

                ss.name = "Star " + i.ToString();

                starSystems.Add(ss);
            }

            Debug.Log("Num Stars Generated: " + starSystems.Count);

            for (int i = 0; i < GalaxyConfig.NumPlayers; i++)
            {
                Player p = null;
                if (i == 0 || i == 4)
                    p = new Player_Human(i);
                else
                    p = new Player_AI(i);

                players.Add(p);
            }
        }

        public void Load( /* Some kind of file handle? */ )
        {

        }

        public void Save( /* Some kind of file handle? */ )
        {

        }


    }

}