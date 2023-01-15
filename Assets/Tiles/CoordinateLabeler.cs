using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro _label;
    private Vector2Int _coordinates = new Vector2Int();
    // Start is called before the first frame update
    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        UpdateObjectName();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            //display current coordinates
            DisplayCoordinates();
            UpdateObjectName();
        }
        
    }

    void DisplayCoordinates()
    {
        var position = transform.parent.position;
        _coordinates.x = Mathf.RoundToInt(position.x / UnityEditor.EditorSnapSettings.move.x);
        _coordinates.y = Mathf.RoundToInt(position.z / UnityEditor.EditorSnapSettings.move.z);
        _label.SetText($"{_coordinates.x},{_coordinates.y}");
    }

    void UpdateObjectName()
    {
        transform.parent.transform.name = _coordinates.ToString();

    }
}
