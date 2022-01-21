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


    //
    DamageCollider damageCollider;

    public virtual void Initialize()
    {
        health = MaxHp;
        stamina = MaxSP;
    }

    public virtual void Heal(float value)
    {
        health = Mathf.Clamp(health + value, 0, MaxHp);
    }

    public virtual void Hit(float Damage, Vector3 Position)
    {
        health = Mathf.Clamp(health - Damage, 0, MaxHp);
    }

    public virtual void AddStamina(float Value)
    {
        stamina = Mathf.Clamp(stamina + Value, 0, MaxSP);
    }

    public virtual void SubStamina(float Value)
    {
        stamina = Mathf.Clamp(stamina - Value, 0, MaxSP);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            if (other.TryGetComponent<DamageCollider>(out damageCollider))
            {
                float damage = damageCollider.Damage;
                Hit(damage, other.bounds.center);
            }
            else
                Debug.Log("Damage Collider does not exist At " + other.name);
        }
    }
}
