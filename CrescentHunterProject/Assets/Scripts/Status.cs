using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class Status : MonoBehaviour
{
    [SerializeField]
    int damage = 10;
    int Damage { get => damage; }

    [SerializeField]
    int health = 100;
    public int Health { get => health; }

    [SerializeField]
    int MaxHP = 100;

    public void Hit(int Damage)
    {
        health -= Damage;
        Mathf.Clamp(health, 0, MaxHP);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Damage"))
        {
            Hit(other.GetComponentInParent<Status>().Damage);
            ObjectPool.Instance.CreateDamageText(other.bounds.center, other.GetComponentInParent<Status>().Damage);
        }
    }
}
