using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica
{
    public abstract class Player
    {
        public Player(int _playerIndex, bool _isUIControlled)
        {
            this.playerIndex = _playerIndex;
            this.isUIControlled = _isUIControlled;
            this.colonies = new List<Colony>();
        }

        public readonly int playerIndex;

        public readonly bool isUIControlled;

        int race = 0;
        int money = 0;

        bool[] unlockedTechnologies;

        List<Colony> colonies;

        public abstract bool DoTurn();
    }

    public class Player_Human : Player
    {
        public Player_Human(int _playerIndex) : base(_playerIndex, true)
        {
            
        }


        public override bool DoTurn()
        {
            // Always busy as indicate end turn via button which notifies UniverseManager directly
            return true;
        }
    }

    public class Player_AI : Player
    {
        public Player_AI(int _playerIndex) : base(_playerIndex, false)
        {

        }

        const float TURNTIME = 0.5f;
        float timeSinceTurnStart = 0f;

        public override bool DoTurn()
        {
            // Do the various AI calcs, do not freeze up UI

            // Either use co-routines or threads and return from DoTurn() frequently/quickly

            // If still running co-routines/threads return true

            // PLACEHOLDER CODE
            // Delays the AI turn so can see it count through each player
            timeSinceTurnStart += Time.deltaTime;
            
            if (timeSinceTurnStart > TURNTIME)
            {
                timeSinceTurnStart = 0f;
                return false;
            }
            else
                return true;
        }
    }
}
