using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField]
    int damage = 10;
    int Damage { get => damage; }

    [SerializeField]
    int HP = 100;
    [SerializeField]
    int MaxHP = 100;

    public void Hit(int Damage)
    {
        HP -= Damage;
        Mathf.Clamp(HP, 0, MaxHP);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Damage"))
        {
            Hit(other.GetComponentInParent<Status>().Damage);
        }
    }
}
