using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    public GameObject Target { get => target; }

    [SerializeField]
    Vector3 destination;
    public Vector3 Destination { get => destination; }

    [SerializeField]
    GameObject[] Damage;
    [SerializeField]
    GameObject[] Projectile;

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
        Projectile[index].transform.position = 
            target.transform.position +
            new Vector3(0.0f, 7.0f, 0.0f);
        //new Vector3(Random.Range(-5.0f, 5.0f), 3.0f, Random.Range(-5.0f, 5.0f));
        Projectile[index].SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            target = other.gameObject;
    }
}
