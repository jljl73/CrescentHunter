using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    List<GameObject> Weapon = new List<GameObject>();
    int curWeaponIndex = 0;

    void Start()
    {
        for (int i = 0; i < transform.childCount-1; ++i)
            Weapon.Add(transform.GetChild(i).gameObject);
    }

    public void OnEquip(int index)
    {
        curWeaponIndex = index;
        Weapon[curWeaponIndex].SetActive(true);
    }

    public void OnUnequip()
    {
        Weapon[curWeaponIndex].SetActive(false);
    }
}
