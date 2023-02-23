using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {get {return isPlaceable;}}
    
    private void OnMouseDown() 
    {
        if (isPlaceable) {
            Debug.Log(transform.name);
            PlaceTower(transform.position);
        }
    }

    private void PlaceTower(Vector3 position) {
        bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
        isPlaceable = !isPlaced;
    }
}
