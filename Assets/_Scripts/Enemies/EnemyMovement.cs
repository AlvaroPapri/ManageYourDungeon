using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _movePoints;

    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.DOMove(_movePoints[0].transform.position, 1f);

        if (IsTreasureBox())
        {
            yield break;
        }
        
        _movePoints.RemoveAt(0);

        StartCoroutine(Move());
    }

    private bool IsTreasureBox()
    {
        return _movePoints[0].parent.CompareTag("Treasure");
    }
}
