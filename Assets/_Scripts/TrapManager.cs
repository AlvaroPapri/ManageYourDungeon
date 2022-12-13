using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public static TrapManager Instance;
    
    public static event Action OnSpikeTrapActivated;

    private bool _isSpikeTurn;

    [SerializeField] private List<SpikeTrap> _spikeTraps;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        if (state == GameState.BoxCheck)
        {
            StopCoroutine(ActivateSpikeTraps());
            StartCoroutine(ActivateSpikeTraps());
        }
    }

    IEnumerator ActivateSpikeTraps()
    {
        foreach (var spikeTrap in _spikeTraps)
        {
            if (!_isSpikeTurn)
            {
                spikeTrap.ActivateTrap();
                yield return new WaitForSeconds(1f);
                _isSpikeTurn = true;
            }
            else
            {
                Debug.Log("ME DESACTIVO");
                spikeTrap.DeActivateTrap();
                yield return new WaitForSeconds(1f);
                _isSpikeTurn = false;
            }


            GameManager.Instance.UpdateGameState(GameState.EnemyTurn);
        }
    }
}
