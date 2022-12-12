using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _movePoints;

    public void Move()
    {
        gameObject.transform.DOMove(_movePoints[0].transform.position, 1f);
        
        _movePoints.RemoveAt(0);
    }

    private bool IsTreasureBox()
    {
        return _movePoints[0].parent.CompareTag("Treasure");
    }
}
