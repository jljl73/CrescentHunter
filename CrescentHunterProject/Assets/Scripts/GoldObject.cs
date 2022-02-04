using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldObject : MonoBehaviour, IInteraction
{
    [SerializeField]
    int Minvalue = 100;
    [SerializeField]
    int Maxvalue = 500;

    int value;

    public string IName { get => value.ToString() + "G"; }

    void Awake()
    {
        value = Random.Range(Minvalue, Maxvalue);
    }

    public void OnInteraction()
    {
        Inventory.Instance.AddGold(value);
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
