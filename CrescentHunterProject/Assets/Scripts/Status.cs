using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M4u;
using BehaviorDesigner.Runtime;

public class Status : MonoBehaviour
{
    [SerializeField]
    float damage = 10;
    float Damage { get => damage; }

    [SerializeField]
    float health = 100;
    public float Health { get => health; }

    [SerializeField]
    float maxHp = 100;
    public float MaxHp { get => maxHp; }

    [SerializeField]
    float stamina = 100;
    public float Stamina { get => stamina; }

    [SerializeField]
    protected float MaxSP = 100;

      

    public virtual void Heal(float value)
    {
        health = Mathf.Clamp(health + value, 0, MaxHp);
    }

    public virtual void Hit(float Damage)
    {
        health = Mathf.Clamp(health - Damage, 0, MaxHp);
    }

    public virtual void AddStamina(float Value)
    {
        stamina = Mathf.Clamp(stamina + Value, 0, MaxSP);
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
