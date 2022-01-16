using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    public void DealDamage(int damage)
    {
        enemy.Epublic_health -= damage;
    }
}
