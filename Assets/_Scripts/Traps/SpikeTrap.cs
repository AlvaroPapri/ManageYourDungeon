using System;
using System.Collections;
using UnityEngine;

namespace _Scripts.Traps
{
    public class SpikeTrap : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;
        [SerializeField] private GameObject _spike;

        private bool _activatedLastTurn;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            TrapManager.OnTrapActivated += TrapManagerOnTrapActivated;
        }

        private void OnDestroy()
        {
            TrapManager.OnTrapActivated -= TrapManagerOnTrapActivated;
        }

        private void TrapManagerOnTrapActivated()
        {
            if (_activatedLastTurn)
            {
                _activatedLastTurn = false;
                return;
            }
        
            StopCoroutine(ActivateSpike());
            StartCoroutine(ActivateSpike());
        }

        IEnumerator ActivateSpike()
        {
            ActivateTrap();
            yield return new WaitForSeconds(0.5f);
            DeActivateTrap();
        }

        private void ActivateTrap()
        {
            _boxCollider.enabled = true;
            _spike.SetActive(true);
        }
    
        private void DeActivateTrap()
        {
            _boxCollider.enabled = false;
            _spike.SetActive(false);
        }
    }
}
