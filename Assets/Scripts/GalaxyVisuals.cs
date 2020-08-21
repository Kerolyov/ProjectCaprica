using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Caprica;

public class GalaxyVisuals : MonoBehaviour {

    [SerializeField] private ClickableStar[] starPrefabs = null;    // Index of array is a star type. The prefabs are 
                                                                    // responsible for having appearance variety.

    public void InitiateVisuals( Galaxy galaxy )
    {
//        this.galaxy = galaxy;

        for (int i = 0; i < galaxy.GetNumStarSystems(); i++)
        {
            StarSystem starSystem = galaxy.GetStarSystem(i);

            ClickableStar clickableStar = Instantiate(
                starPrefabs[starSystem.GetStarTypeIndex()],
                starSystem.position,       // Are we gonna want to mult by a scalar?
                Quaternion.identity,
                this.transform
                );

            clickableStar.starSystem = starSystem;
            clickableStar.name = starSystem.name;

        }
    }
}
