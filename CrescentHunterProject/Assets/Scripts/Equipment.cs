using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField]
    ItemEquipment[] Weapons;
    List<GameObject> Weapon = new List<GameObject>();

    int curWeaponIndex = 0;

    void Awake()
    {
        for (int i = 0; i < transform.childCount-1; ++i)
            Weapon.Add(transform.GetChild(i).gameObject);
    }

    public ItemEquipment GetCurrentWeapon()
    {
        return Weapons[curWeaponIndex];
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
