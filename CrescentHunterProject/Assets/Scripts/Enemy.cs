using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // BT
    [SerializeField]
    GameObject target;
    public GameObject Target { get => target; }
    [SerializeField]
    Vector3 destination;
    public Vector3 Destination { get => destination; }

    // Attack
    [SerializeField]
    GameObject[] Damage;
    [SerializeField]
    string[] Projectile;

    // Death
    [SerializeField]
    GameObject Panel;


    public void OnDamage(int index)
    {
        Damage[index].SetActive(true);
    }

    public void OffDamage(int index)
    {
        Damage[index].SetActive(false);
    }

    public void OnProjectile(int index)
    {
        ObjectPool.Instance.CreateEffect(Projectile[index], target.transform.position + new Vector3(0.0f, 7.0f, 0.0f));
    }

    public void Die()
    {
        GameManager.Instance.QuestClear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            target = other.gameObject;
    }
}
