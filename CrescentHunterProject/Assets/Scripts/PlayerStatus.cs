using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status
{
    public override void Hit(int Damage)
    {
        base.Hit(Damage);
        GameManager.Instance.Context.HpRatio = (float)Health / (float)MaxHP;
    }
}
