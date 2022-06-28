using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private MinionContainer minionContainer;

    private void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = Vector3.zero + Vector3.back;
        rectTransform.localEulerAngles = Vector3.zero;
        minionContainer = GameObject.Find("Minion Container").GetComponent<MinionContainer>();
    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos)) return;

        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }

    private bool CanAppend(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true;

        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    public void SendPosition()
    {
        List<Vector3> positions = new List<Vector3>();
        for (int i = 0; i < _renderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(_renderer.GetPosition(i).x / Camera.main.scaledPixelWidth - 0.5f, 0, _renderer.GetPosition(i).y / Camera.main.scaledPixelHeight - 0.5f);
            positions.Add(pos);
        }
        minionContainer.SetShape(positions);
        Destroy(gameObject);
    }
}