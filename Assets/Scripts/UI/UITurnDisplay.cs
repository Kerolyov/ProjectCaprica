using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITurnDisplay : MonoBehaviour
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
        GetComponent<Text>().text = "Turn: " +
            universeManager.galaxy.turnCounter.ToString();
    }
}
