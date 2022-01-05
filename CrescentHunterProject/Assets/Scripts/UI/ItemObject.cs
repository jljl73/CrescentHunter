using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteraction
{
    [SerializeField]
    ItemSO itemData;

    public void OnInteraction()
    {
        GameManager.Instance.player.inventory.Add(itemData);
    }
}
