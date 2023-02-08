using System;
using UnityEngine;

public class TrapPiece : MonoBehaviour
{
    [SerializeField] private GameObject _grid;
    [SerializeField] public bool IsOnPathTile { get; private set; }
    
    public bool isDragging, isPlaced;
    private Vector2 _offset;
    private PathSlot _slot;
    private BoxCollider2D _boxCollider;
    private GameObject _pathTile;
    
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!isDragging) return;

        var mousePosition = GetMousePos();
        
        transform.position = mousePosition ;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        transform.SetParent(null);
        
        Debug.Log(_grid);
    }

    private void OnMouseUp()
    {
        //TODO: Sacar una pieza de un PATH e intentar ponerlo en otro falla y lo manda al GRID. Ajustarlo.
        if (!IsOnPathTile)
        {
            transform.SetParent(_grid.transform);
            isDragging = false;
            return;
        }
         
        transform.SetParent(_pathTile.transform);
        transform.position = _pathTile.transform.position;
        isDragging = false;

    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Path"))
        {
            IsOnPathTile = true;
            _pathTile = col.gameObject;
            Debug.Log("It is touching a PATH!");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            IsOnPathTile = false;
            Debug.Log("Not touching anymoooooore");
        }
    }
}
