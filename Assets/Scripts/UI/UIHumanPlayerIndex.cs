using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHumanPlayerIndex : MonoBehaviour
{
    [SerializeField] UniverseManager universeManager = null;

    // Update is called once per frame
    void Update()
    {
        if (universeManager is null)
        {
            Debug.LogError("Universe manager not set");
            return;
        }

        string playerTypeString  =  universeManager.galaxy.GetCurrentPlayer().isUIControlled ? "Human" : "AI";
        GetComponent<Text>().text = "Current Player is: " + playerTypeString;
    }
}
