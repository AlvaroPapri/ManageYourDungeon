using System;
using UnityEngine;

public class TrapPiece : MonoBehaviour
{
    [SerializeField] private GameObject _grid;
    
    private bool _dragging, _placed;

    private Vector2 _offset;

    private PathSlot _slot;
    private void Update()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();
        
        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown()
    {
        _dragging = true;
        transform.SetParent(null);
        
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, _slot.transform.position) < 3)
        {
            transform.position = _slot.transform.position;
            _placed = true;
        }
        else
        {
            transform.SetParent(_grid.transform);
            _dragging = false;
        }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
