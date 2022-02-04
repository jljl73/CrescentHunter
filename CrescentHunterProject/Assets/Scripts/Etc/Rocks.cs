using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour, IInteraction
{
    bool Falling = false;

    public string IName => "³«¼®";
    [SerializeField]
    GameObject Effect;
    [SerializeField]
    Collider damageCollider;

    public void OnInteraction()
    {
        Falling = true;
        //StartCoroutine(Fall());
        GetComponent<Rigidbody>().useGravity = true;
        Effect.SetActive(true);
    }

    IEnumerator Fall()
    {
        while (Falling)
        {
            transform.Translate(Physics.gravity * Time.deltaTime);
            yield return null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        damageCollider.enabled = false;
        SoundPlayer.Instance.Play(1);
        Destroy(gameObject, 4.0f);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
