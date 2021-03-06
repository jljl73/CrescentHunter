using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField]
    bool isPlayer;
    public bool IsPlayer { get => isPlayer; }

    [SerializeField]
    float damage = 10.0f;
    public float Damage {
        get { return damage; }
        set { damage = value; } }

    [SerializeField]
    GameObject Effect = null;
    [SerializeField]
    bool AtOnce = false;
    


    void OnEnable()
    {
        if(!AtOnce)
            GetComponent<Collider>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!IsPlayer && other.CompareTag("Player"))
            GetComponent<Collider>().enabled = false;


        if(IsPlayer && other.CompareTag("Enemy"))
            SoundPlayer.Instance.Play(0);
        //if (Effect != null)
        //{
        //    Effect.SetActive(true);
        //    Invoke("OffEffect", 1.0f);
        //}
    }

    void OffEffect()
    {
        Effect?.SetActive(false);
    }

}
