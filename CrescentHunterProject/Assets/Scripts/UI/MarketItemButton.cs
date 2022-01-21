using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketItemButton : MonoBehaviour
{
    VM_Market market;
    Button button;
    void Start()
    {
        int value = transform.GetSiblingIndex();
        button = GetComponent<Button>();
        market = GetComponentInParent<VM_Market>();
        button.onClick.AddListener(()=>market.SelectItem(value));
    }

}
