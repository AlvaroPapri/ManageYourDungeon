using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private List<Transform> _movePoints;
        private CircleCollider2D _circleCollider;
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _circleCollider = GetComponent<CircleCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move()
        {
            gameObject.transform.DOMove(_movePoints[0].transform.position, 1f);
        
            _movePoints.RemoveAt(0);
        }

        private bool IsTreasureBox()
        {
            return _movePoints[0].parent.CompareTag("Treasure");
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Trap"))
            {
                Die();
            }
        }

        private void Die()
        {
            _spriteRenderer.DOFade(0, 1f);
            Destroy(gameObject, 1f);
        }
    }
}
