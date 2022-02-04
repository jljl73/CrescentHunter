using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteraction
{
    [SerializeField]
    ItemSO itemData;
    public ItemSO ItemData { get => itemData; set => itemData = value; }

    public string IName => itemData.ItemName;

    public void OnInteraction()
    {
        GameManager.Instance.player.inventory.Acquire(itemData);
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
