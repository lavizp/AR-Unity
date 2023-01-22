using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceInterface : MonoBehaviour
{
    [SerializeField] private GameObject interfacePrefab;
    [SerializeField] private GameObject clickToInput;
    private GameObject _spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 _touchPos;
    private static List<ARRaycastHit> _hits = new();

    // Start is called before the first frame update
    private void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetPosition(out Vector2 _touchPos)
    {
        if (Input.touchCount > 0)
        {
            _touchPos = Input.GetTouch(0).position;
            return true;
        }

        _touchPos = default;
        return false;
    }


    public void InitialisePrefab(GameObject model)
    {
        interfacePrefab = model;
    }
    // Update is called once per frame
    void Update()
    {
        if (!TryGetPosition(out Vector2 _touchPos))
        {

            return;
        }
        if(!GameManager.Instance.canSpawn) return;
        if (_arRaycastManager.Raycast(_touchPos, _hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = _hits[0].pose;
            if (_spawnedObject == null)
            {
                _spawnedObject = Instantiate(interfacePrefab, hitPose.position, hitPose.rotation);
                clickToInput.SetActive(false);
                Debug.Log("Spawned");

            }
        }
    }

    public void DestroyPrefab()
    {
        Destroy(_spawnedObject);
        _spawnedObject = null;
    }
}
