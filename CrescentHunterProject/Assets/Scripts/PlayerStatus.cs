using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : Status
{
    public override void Heal(float value)
    {
        base.Heal(value);
        GameManager.Instance.Context.HpRatio = Health / MaxHp;
    }

    public override void AddStamina(float Value)
    {
        base.AddStamina(Value);
        GameManager.Instance.Context.SpRatio = Stamina / MaxSP;
    }

    public override void Hit(float Damage)
    {
        base.Hit(Damage);
        GameManager.Instance.Context.HpRatio = Health / MaxHp;
    }
}
