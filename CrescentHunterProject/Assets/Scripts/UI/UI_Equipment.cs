using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Equipment : MonoBehaviour
{
    [SerializeField]
    ItemSO[] itemLists;
    [SerializeField]
    TextMeshProUGUI ItemNameText;

    Player player;
    int index = 0;
    void Start()
    {
        player = GameManager.Instance.player;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            OnEquip(index);
    }

    void OnEquip(int index)
    {
        player.OnEquip(index);
    }

    public void OnSelectEquipment(int index)
    {
        this.index = index;
        ItemNameText.text = itemLists[index].ItemName;
    }

}
