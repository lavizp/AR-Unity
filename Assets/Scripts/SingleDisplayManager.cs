using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleDisplayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    private string mapsLink;

    public void InitialiseThis(Heritage thisHeritage)
    {
        title.text = thisHeritage.name;
        description.text = thisHeritage.description;
        mapsLink = thisHeritage.mapsLink;
    }

    public void LoadMaps()
    {
        Application.OpenURL(mapsLink);
    }
}
