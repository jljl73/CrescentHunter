using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemConsumable")]
public class ItemConsumable : ItemSO
{
    [SerializeField]
    float AddHealth;
    [SerializeField]
    float AddMaxHealth;
    [SerializeField]
    float AddStamina;
    [SerializeField]
    float AddMaxStamina;

    public override void Use(Status status)
    {
        status.Heal(AddHealth);
        status.AddStamina(AddStamina);
    }

}
