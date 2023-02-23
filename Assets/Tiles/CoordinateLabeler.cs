using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    private TextMeshPro _label;
    private Vector2Int _coordinates = new Vector2Int();
    Waypoint waypoint;
    // Start is called before the first frame update
    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        _label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
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
        SetLabelColor();
        ToggleLabels();
        
    }

    void ToggleLabels() {
        if (Input.GetKeyDown(KeyCode.C)) {
            _label.enabled = !_label.IsActive();
        }
    }

    void SetLabelColor() {
        if (waypoint.IsPlaceable) {
            _label.color = defaultColor;
        } else {
            _label.color = blockedColor;
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
