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

        [SerializeField]  public bool IsDead => _currentHealth < 1 ;

        public event Action OnHealthChange;
        public event Action OnDeath;

        

        private void Awake()
        {
            _currentHealth = maxHealth;

        }
        public void TakeHit(IAttacker attacker)
        {
            if(IsDead) return;
            _currentHealth -= attacker.Damage;
            OnHealthChange?.Invoke();
        }

       
    }



}

