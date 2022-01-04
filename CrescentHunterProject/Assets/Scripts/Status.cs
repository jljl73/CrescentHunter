using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M4u;
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
    protected int MaxHP = 100;


    M4uProperty<bool> isActive = new M4uProperty<bool>(false);
    public bool IsActive { get => isActive.Value; set => isActive.Value = value; }


    public virtual void Hit(int Damage)
    {
        IsActive = !IsActive;
        Debug.Log(IsActive);

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
