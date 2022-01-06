using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour, IInteraction
{
    bool Falling = false;

    public string IName => "³«¼®";

    public void OnInteraction()
    {
        Falling = true;
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        while (Falling)
        {
            transform.Translate(Physics.gravity * Time.deltaTime);
            yield return null;
        }
    }

}
