using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Caprica
{
    public class StarSystemGraphic
    {
        // int?  string?  sprite? texture?  model
        // do we maintain animation data?
    }

    public class StarSystem
    {
        public StarSystem()
        {
            planets = new Planet[GetMaxPlanets()];

        }

        public Vector3 position;

        private Planet[] planets;


        const int MIN_STAR_TYPE = -2;    // Not pleased with this
        const int MAX_STAR_TYPE =  2;
        public int starType { get; private set; }  // 0 = Yellow, positive = older, less rich, negative = younger, less hab

        public StarSystemGraphic StarSystemGraphic;

        public string name;

        public Planet GetPlanet(int PlanetIndex)
        {
            return planets[PlanetIndex];
        }

        public void Generate( int starType = 0 /* Galactic age/richness info? Or maybe we get told what kind of star to generate?  Especially for player starting planets? */ )
        {
            this.starType = starType;

            GeneratePlanets();
        }

        public int GetNumPlanets()
        {
            int c = 0;
            for (int i = 0; i < GetMaxPlanets(); i++)
            {
                if(planets[i] != null)
                {
                    c++;
                }
            }

            return c;
        }

        public int GetMaxPlanets()
        {
            return Config.GetInt("STAR_MAX_PLANETS");
        }

        public Planet GetPlanetAtIndex( int i )
        {
            return planets[i];
        }

        public void Load( /* Some kind of file handle? */ )
        {

        }

        public void Save( /* Some kind of file handle? */ )
        {

        }

        public int GetStarTypeIndex()
        {
            // Weird hacky function to convert from -2...+2 range to a 0...4 range

            return starType - MIN_STAR_TYPE;
        }

        private void GeneratePlanets()
        {
            // Generate 0 to Max planets, weighting planet class based on
            // StarType + distance from the Sun

            // The StarType might also influence the likelihood of number
            // of planets

            float planetChance = 0.50f;

            for (int i = 0; i < GetMaxPlanets(); i++)
            {
                if(UnityEngine.Random.Range(0f, 1f) <= planetChance)
                {
                    // Make a planet!
                    planets[i] = GeneratePlanet(i + 1); // 'i' is the array index, therefore, add 1 to get position.
                }
            }
        }

        Planet GeneratePlanet(int planetPosition)
        {
            Planet planet = new Planet();

            // TODO: Make awesome
            planet.name = name + " " + planetPosition.ToString();

            // To select a random planet size, first organize the planet sizes into an array.
            Array planetSizeArray = Enum.GetValues(typeof(PlanetSize));

            // Next, generate a random array index.
            int planetSizeIndex = UnityEngine.Random.Range(0, planetSizeArray.Length);

            // Finally, set the planet size using the random index into the array.
            planet.planetSize = (PlanetSize) planetSizeArray.GetValue(planetSizeIndex);

            return planet;
        }

        PlanetType GeneratePlanetType(int pos)
        {
            // Tweak this based on star type and galaxy settings
            float goldilocksRange = 0.5f;

            float distance = (float)pos / (float)GetMaxPlanets();
            float distanceSquared = distance*distance;

            float gasGiantWeight = Mathf.Lerp(0f, 1f, distanceSquared);
            float goldilocksWeight = Mathf.Lerp(1f, 0f, 2f * Mathf.Abs(goldilocksRange - distance ) );
            float asteroidWeight = 1.0f;

            // Cool suns should have goldilocks closer to the sun
            // Hot suns should have it further

            float allWeights = gasGiantWeight + goldilocksWeight + asteroidWeight;

            float r = UnityEngine.Random.Range(0, allWeights);

            if( r < gasGiantWeight )
            {
                //TODO
                return PlanetType.GasGiant;
            }
            r -= gasGiantWeight;

            if ( r < goldilocksWeight)
            {
                // TODO
                return PlanetType.Continental;
            }
            r -= goldilocksWeight;

            // If we get here, it's because we rolled in the asteroid weight
            return PlanetType.Asteroid;
        }
    }
}