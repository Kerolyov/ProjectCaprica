using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caprica;
using TMPro;

public class ClickableStar : MonoBehaviour {

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = starSystem.name;
    }

    public StarSystem starSystem { get;  set; }  // Set by GalaxyVisuals

    public void OnClick()
    {
        Debug.Log("ClickableStar::OnClick -- " + starSystem.name);
        ViewManager.Instance.OpenSystemView(starSystem);
    }
}
