using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleDisplayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;

    public void InitialiseThis(Heritage thisHeritage)
    {
        title.text = thisHeritage.name;
        description.text = thisHeritage.description;

    }
}
