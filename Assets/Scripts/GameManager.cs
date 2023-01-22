using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;

public class GameManager : MonoBehaviour
{
    public List<GameObject> models;
    public LocationsDTO myData;
    public  TextAsset text;
    [SerializeField]

    private GameObject singleDisplay;
    [SerializeField]

    private GameObject multipleDisplay;

    [SerializeField] private PlaceInterface _placeInterface;
    [SerializeField] private GameObject interfaceIcon;
    [SerializeField] private Transform interfaceParent;
    private static GameManager _instance;
    public bool canSpawn;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("gamemanager is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        myData = JsonUtility.FromJson<LocationsDTO>(text.text);
    }

    public List<GameObject> interfaces = new();

    [SerializeField] private Camera arCamera;

    public void AddInterfaces(GameObject newInterface)
    {
        interfaces.Add(newInterface);
    }

    public void LoadData(string cityname)
    {
        LocationDTO cityData = new LocationDTO();
        for (int i = 0; i < myData.result.Length; i++)
        {
            if (myData.result[i].location == cityname)
            {
                cityData = myData.result[i];
                break;

            }
        }

        for (int i = 0; i < cityData.heritages.Length; i++)
        {

            var iconTransform = Instantiate(interfaceIcon);
            iconTransform.GetComponent<Transform>().SetParent(interfaceParent);
            iconTransform.GetComponent<SingleCubeDataAdder>().InitialiseCube(cityData.heritages[i]);
        }
    }
    public void DisplaySingle(Heritage heritageData)
    {
        
        _placeInterface.InitialisePrefab(models[0]);
        canSpawn = true;
        multipleDisplay.SetActive(false);
        singleDisplay.SetActive(true);
        singleDisplay.GetComponent<SingleDisplayManager>().InitialiseThis(heritageData);
    }

    public void CannotSpawn()
    {
        canSpawn = false;
        _placeInterface.DestroyPrefab();
    }

}
