using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemM", menuName = "ScriptableObjects/ItemMaterial")]
public class ItemMaterialSO : ScriptableObject
{
    [SerializeField]
    ItemSO Equipment;
    public ItemSO Item { get => Equipment; }
    
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
}
