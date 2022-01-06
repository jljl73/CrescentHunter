using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteraction
{
    [SerializeField]
    GameObject Rocks;

    Animator animator;

    public string IName => "·¹¹ö";

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnInteraction()
    {
        animator.SetBool("LeverDown", true);
        Invoke("OnLever", 1.0f);
    }

    void OnLever()
    {
        Rocks.GetComponent<IInteraction>().OnInteraction();
    }
}
