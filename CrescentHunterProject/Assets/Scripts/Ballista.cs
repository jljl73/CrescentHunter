using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour, IInteraction
{
    public GameObject bolt;

    Animator animator;

    int idxLoad;
    int idxShoot;

    public string IName => "발리스타";

    void Start()
    {
        animator = GetComponent<Animator>();
        idxLoad = Animator.StringToHash("Load");
        idxShoot = Animator.StringToHash("Shoot");
    }

    public void OnInteraction()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ballista_idle"))
            animator.SetTrigger(idxLoad);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Ballista_Loaded"))
            animator.SetTrigger(idxShoot);
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        bolt.GetComponent<Rigidbody>().AddForce(Vector3.forward * 50.0f, ForceMode.Impulse);
        bolt.GetComponent<Collider>().enabled = true;
    }
}
