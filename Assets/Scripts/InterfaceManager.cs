using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private GameObject interfacePannel;
    [SerializeField] private string city;

    private void Start()
    {
        Debug.Log(city);
    }

    public void SetInterfacepannel()
    {
        GameManager.Instance.LoadData(city);
        interfacePannel.SetActive(true);
    }



}
