using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventEffects : MonoBehaviour {

    public EffectInfo[] Effects;

    [System.Serializable]
    public class EffectInfo
    {
        public GameObject Effect;
        public float DestroyAfter = 10;
        //public bool UseLocalPosition = true;
        public WaitForSeconds wait;
    }

    void Start()
    {
        for (int i = Effects.Length - 1; i >= 0; --i)
            Effects[i].wait = new WaitForSeconds(Effects[i].DestroyAfter);
    }


    void InstantiateEffect(int EffectNumber)
    {
        if(Effects == null || Effects.Length <= EffectNumber)
        {
            Debug.LogError("Incorrect effect number or effect is null");
        }


        Effects[EffectNumber].Effect.SetActive(true);
        if (Effects[EffectNumber].DestroyAfter > 0)
            StartCoroutine(IOffEffect(EffectNumber));
    }

    void OffAllEffect()
    {
        for(int i = 0; i < Effects.Length; ++i)
        {
            Effects[i].Effect.SetActive(false);
        }
    }

    void OffEffect(int EffectNumber)
    {
        if (Effects == null || Effects.Length <= EffectNumber)
        {
            Debug.LogError("Incorrect effect number or effect is null");
        }
        StartCoroutine(IOffEffect(EffectNumber));
        //Destroy(instance, Effects[EffectNumber].DestroyAfter);
    }

    IEnumerator IOffEffect(int EffectNumber)
    {
        yield return Effects[EffectNumber].wait;
        Effects[EffectNumber].Effect.SetActive(false);
        //Effects[EffectNumber].Effect.gameObject.SetActive(false);
        //Destroy(Effects[EffectNumber].Effect.gameObject, Effects[EffectNumber].DestroyAfter);
    }
}
