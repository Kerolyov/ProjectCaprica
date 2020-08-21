using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Caprica;
using TMPro;

public class SystemView : MonoBehaviour {

    private void OnEnable()
    {
        Debug.Log("SystemView::OnEnable -- " + starSystem.name);

        // Update various UI elements for this system
        viewTitle.text = starSystem.name;

        // Setup the system render view so we can see planets
        SpawnRenderables();
    }

    private void OnDisable()
    {
        // Become Darth Vader, kill all the younglings
        foreach (Transform child in starSystem3DContainer.transform)
        {
            Debug.Log("Destroying System View Object" + child.gameObject.ToString());
            Destroy(child.gameObject);
            Debug.Log(child.gameObject.ToString()+" destroyed");
        }
    }

    [SerializeField] private TextMeshProUGUI viewTitle = null;

    public StarSystem starSystem;

    public GameObject starSystem3DContainer;

    public GameObject starPrefab;   // This is temporary, will have to be read in from some
                                    // kind of library that links star type to the many 
                                    // images that represent that star type

    public GameObject planetPrefab; // Ditto.

    // Update is called once per frame
    void Update () {
    }

    void SpawnRenderables()
    {
        // Spawn our star
        GameObject go;

        go = Instantiate(starPrefab, starSystem3DContainer.transform);
        go.transform.localPosition = Vector3.zero;

        // Spawn all the planets
        float orbitDistance = 0;
        for (int i = 0; i < starSystem.GetMaxPlanets(); i++)
        {
            orbitDistance += Config.GetFloat("STAR_ORBIT_DISTANCE");
            Planet p = starSystem.GetPlanetAtIndex(i);
            if(p == null)
            {
                continue;
            }

            // If we get here, we have a valid planet

            go = Instantiate(planetPrefab, starSystem3DContainer.transform);
            go.transform.localPosition = 
                Quaternion.Euler( 0, 0, Random.Range(0, 359)) * 
                new Vector3(orbitDistance, 0, 0);

        }

    }
}
