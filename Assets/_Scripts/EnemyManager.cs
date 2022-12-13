using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    
    [SerializeField] private List<EnemyMovement> _enemies;

    private void Awake()
    {
        Instance = this;
    }

    public void Move()
    {
        StopCoroutine(MoveEnemies());
        StartCoroutine(MoveEnemies());
    }

    IEnumerator MoveEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Move();
            yield return new WaitForSeconds(1f);
        }
        
        
        // GameManager.Instance.UpdateGameState(GameState.PrepareRound);
        GameManager.Instance.UpdateGameState(GameState.BoxCheck);
    }
}
