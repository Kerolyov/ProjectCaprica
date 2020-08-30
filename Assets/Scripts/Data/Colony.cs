using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica
{
    public class Colony
    {
        public readonly int colonyIndex;

        public Planet planet;

        int population { get { return popFarmers + popWorkers + popScientists; } }
        int popFarmers = 0;
        int popWorkers = 0;
        int popScientists = 0;

        int flatProduction = 0; // Normally zero, unless you get automated factories
        int productionPerWorker = 0; // PlanetRichness/2 + 1

        //List<Building> BuiltBuildings;
        List<int> builtBuildingIndexes;
        List<int> buildingBuiltTurn;

        public int TotalProductionPerTurn()
        {
            return flatProduction + productionPerWorker * popWorkers;
        }

        public void DoEndOfTurn()
        {
            // for each built building, call their end of turn update and
            // pass the value of the turn number it was built on
        }

        public int MaxPopulation()
        {
            int p = Config.GetInt("PLANET_MAX_POPULATION_" + planet.planetSize.ToString());

            // Is our species Subterreranian, or have some other bonus to pop cap?
            //    Could be from a tech too, for example MoO2's "City"
            //    Could be from a building, like Biospheres
            //    Could be from a planet's special trait

            return p;
        }

        void GetListofValidBuildings()
        {
            // Return array of all buildings that can be built on this planet.

            // METHOD 1
            // For each building in our master building list,
            // look up if the player has unlocked the corresponding technologies

            // METHOD 2
            // Whenever a technology is unlocked that enables a building,
            // then that building is added to the list of legal building for
            // that player

            // In either case filter out filter out buildings already built here
        }

        public void DoTurnProduction()
        {

        }
    }
}
