using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject[] Damage;

    
    public void OnDamage(int index)
    {
        Damage[index].SetActive(true);
    }

    public void OffDamage(int index)
    {
        Damage[index].SetActive(false);
    }
    
}
