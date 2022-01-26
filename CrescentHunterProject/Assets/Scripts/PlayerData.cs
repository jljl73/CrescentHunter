using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("º¸À¯ °ñµå")]
    [SerializeField]
    int Gold = 0;
    [Header("ÀåÂø ¹«±â")]
    [SerializeField]
    int SwordIndex = 0;

    Inventory inventory;
    [SerializeField]
    Player player;

    void Start()
    {
        player = GameManager.Instance.player;
        inventory = Inventory.Instance;
        inventory.AddGold(Gold);
        player.OnEquip(SwordIndex);
    }
}