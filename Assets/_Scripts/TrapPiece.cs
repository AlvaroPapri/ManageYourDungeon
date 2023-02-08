using System;
using UnityEngine;

public class TrapPiece : MonoBehaviour
{
    [SerializeField] private GameObject _grid;
    
    public bool isDragging, isPlaced;

    private Vector2 _offset;

    private PathSlot _slot;
    
    private void Update()
    {
        if (!isDragging) return;

        var mousePosition = GetMousePos();
        
        // transform.position = mousePosition - _offset;
        transform.position = mousePosition ;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        Debug.Log(transform.position);
        transform.parent = null;
        Debug.Log(transform.position);

        // _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        // if (Vector2.Distance(transform.position, _slot.transform.position) < 3)
        // {
        //     transform.position = _slot.transform.position;
        //     isPlaced = true;
        // }
        // else
        // {
            transform.parent = _grid.transform;
            isDragging = false;
        // }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
