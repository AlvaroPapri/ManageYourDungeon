using System;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    [SerializeField] private GameObject _spike;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void ActivateTrap()
    {
        _boxCollider.enabled = true;
        _spike.SetActive(true);
    }
    
    public void DeActivateTrap()
    {
        _boxCollider.enabled = false;
        _spike.SetActive(false);
    }
}
