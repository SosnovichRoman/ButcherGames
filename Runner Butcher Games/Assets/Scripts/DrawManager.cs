using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;
    [SerializeField] private GameObject canvas;

    public const float RESOLUTION = 0.5f;

    private Line _currentLine;
    void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) _currentLine?.SendPosition();
    }
    private void OnMouseOver()
    {
        Vector3 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity, canvas.transform);

        if (Input.GetMouseButton(0)) _currentLine?.SetPosition(mousePos);
    }
}