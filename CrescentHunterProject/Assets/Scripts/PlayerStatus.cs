using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : Status
{
    public override void Heal(float value)
    {
        base.Heal(value);
        GameManager.Instance.HUDContext.HpRatio = Health / MaxHp;
    }

    public override void AddStamina(float Value)
    {
        base.AddStamina(Value);
        GameManager.Instance.HUDContext.SpRatio = Stamina / MaxSP;
    }

    public override void Hit(float Damage, Vector3 Position)
    {
        base.Hit(Damage, Position);
        ObjectPool.Instance.CreateDamageText(Position, Damage, false);
        GameManager.Instance.HUDContext.HpRatio = Health / MaxHp;
        
    }
    
}
