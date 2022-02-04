using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Equipment : MonoBehaviour
{
    [SerializeField]
    ItemSO[] itemLists;
    [SerializeField]
    TextMeshProUGUI ItemNameText;
    [SerializeField]
    Image[] itemImages;

    Player player;
    int index = 0;
    void Awake()
    {
        player = GameManager.Instance.player;
    }
    //A6FF81
    void OnEnable()
    {
        for (int i = 0; i < itemLists.Length; ++i)
        {
            if (player.Equipment.IsEquippable(i))
                itemImages[i].color = new Color(166, 255, 129);
            else
                itemImages[i].color = new Color(255, 0, 0);
        }
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
