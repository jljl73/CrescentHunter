using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemEquipment")]
public class ItemEquipment : ItemSO
{
    [SerializeField]
    float damage = 10.0f;
    public float Damage { get => damage; }



}
