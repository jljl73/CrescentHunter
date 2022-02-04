using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using M4u;

public class VM_Market : M4uContextMonoBehaviour
{
    [SerializeField]
    ItemSO[] itemSOs;

    Inventory inventory;
    M4uProperty<List<ItemContext>> items = new M4uProperty<List<ItemContext>>(new List<ItemContext>());
    List<ItemContext> Items { get => items.Value; set => items.Value = value; }

    


    [SerializeField]
    int currentIndex = 0;

    void Start()
    {
        inventory = Inventory.Instance;
        for(int i = 0; i < itemSOs.Length; ++i)
        {
            Items.Add(new ItemContext(itemSOs[i], 1));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Buy();
    }

    public void Buy()
    {
        if (currentIndex < 0) return;

        if (inventory.SubGold(itemSOs[currentIndex].Price))
        {
            inventory.Acquire(itemSOs[currentIndex]);
            GameManager.Instance.SFX.Play(1);
        }
    }
    public void SelectItem(int index)
    {
        currentIndex = index;
    }

    void Sell(int index)
    {
        
    }
}