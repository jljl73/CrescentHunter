using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : Status
{
    
    public override void Hit(float Damage, Vector3 Position)
    {
        base.Hit(Damage, Position);
        ObjectPool.Instance.CreateDamageText(Position, Damage, true);
        //ObjectPool.Instance.CreateHitEffect(Position);
        SoundPlayer.Instance.Play(0);
    }

    
}
