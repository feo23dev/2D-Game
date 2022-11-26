using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Combat;

namespace UProje.Combats
{

    public class Health : MonoBehaviour , IHealth
    {

        [SerializeField] int maxHealth = 3;
        int _currentHealth;
        public int CurrentHealth => _currentHealth;
        public event Action OnHealthChange;

        

        private void Awake()
        {
            _currentHealth = maxHealth;

        }
        public void TakeHit(IAttacker attacker)
        {
            _currentHealth -= attacker.Damage;
            OnHealthChange?.Invoke();
        }
    }



}

