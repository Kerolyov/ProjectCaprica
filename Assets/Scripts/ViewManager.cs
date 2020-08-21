using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caprica;

public class ViewManager : MonoBehaviour {

    private void OnEnable()
    {
        Instance = this;
    }

    public static ViewManager Instance { get; set; }

    public GalaxyVisuals galaxyVisuals;
    public SystemView systemView; 

    public void OpenSystemView(StarSystem starSystem)
    {
        systemView.starSystem = starSystem;
        ShowView(systemView);
    }

    // Update is called once per frame
    void Update ()
    {
		
        if( Input.GetKeyUp(KeyCode.Escape) )
        {
            // back out of views one step at a time
            // if in the master view (Galaxy), then instead open the game menu
        }

	}

    public void ShowView(MonoBehaviour viewComponent)
    {
        viewComponent.gameObject.SetActive(true);
    }

    public void HideView(MonoBehaviour viewComponent)
    {
        viewComponent.gameObject.SetActive(false);
    }
}
