using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : Status
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Initialize()
    {
        base.Initialize();
        GameManager.Instance.HUDContext.HpRatio = Health / MaxHp;
        GameManager.Instance.HUDContext.SpRatio = Stamina / MaxSP;
    }

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
        GameManager.Instance.UI.ShowHitEffect();

        if (Health == 0)
            animator.SetTrigger("Die");
        else if (Damage > 30)
            animator.SetTrigger("Knockdown");
        else
            animator.SetTrigger("Knockback");
    }

}
