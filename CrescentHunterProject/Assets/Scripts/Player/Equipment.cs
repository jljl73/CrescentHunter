using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField]
    ItemEquipment[] Weapons;
    List<GameObject> Weapon = new List<GameObject>();

    List<bool> hasWeapons = new List<bool>();
    public List<bool> HasWeapons { get => hasWeapons; }

    int curWeaponIndex = 0;
    public int CurWeaponIndex { get => curWeaponIndex; }

    void Awake()
    {
        for (int i = 0; i < transform.childCount - 1; ++i)
        {
            Weapon.Add(transform.GetChild(i).gameObject);
            hasWeapons.Add(false);
        }
        hasWeapons[0] = true;
    }

    public ItemEquipment GetCurrentWeapon()
    {
        return Weapons[curWeaponIndex];
    }

    public void OnEquip(int index)
    {
        if(hasWeapons[index] == false)
        {
            GameManager.Instance.logManager.Log("장착 불가능한 무기 입니다.");
            return;
        }

        curWeaponIndex = index;
        Weapon[curWeaponIndex].SetActive(true);
    }

    public void OnUnequip()
    {
        Weapon[curWeaponIndex].SetActive(false);
    }

    public bool IsEquippable(int index)
    {
        return hasWeapons[index];
    }

    public void AcquireWeapon(int index)
    {
        hasWeapons[index] = true;
    }

    public void AcquireWeapon(ItemSO item)
    {
        int index = 0;
        for(int i = 1; i < Weapons.Length; ++i)
        {
            if (item.Equals(Weapons[i]))
            {
                index = i;
                break;
            }
        }
        hasWeapons[index] = true;
    }
}