using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemM", menuName = "ScriptableObjects/ItemMaterial")]
public class ItemMaterialSO : ScriptableObject
{
    [SerializeField]
    ItemSO item;
    public ItemSO Item { get => item; }
    
    [System.Serializable]
    public struct ItemData
    {
        public ItemSO item;
        public int Num;
    }

    [Header("필요한 재료")]
    [SerializeField]
    ItemData[] items;
    public ItemData[] Materials { get => items; }

    public bool IsMeet(Inventory inventory)
    {
        for(int i =0; i < Materials.Length; ++i)
        {
            int num = inventory.GetNumberItem(Materials[i].item);
            if (num < Materials[i].Num)
                return false;
        }
        return true;
    }

    public void Produce(Inventory inventory, Equipment equipment)
    {
        if (IsMeet(inventory) == false) return;
        for (int i = 0; i < Materials.Length; ++i)
        {
            inventory.Remove(Materials[i].item, Materials[i].Num);
        }
        //inventory.Acquire(Item);
        equipment.AcquireWeapon(Item);
    }

}
