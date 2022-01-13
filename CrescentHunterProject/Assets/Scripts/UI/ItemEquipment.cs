using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemEquipment")]
public class ItemEquipment : ItemSO
{
    [SerializeField]
    float Damage = 10.0f;


}
