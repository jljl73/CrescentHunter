using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Effects : MonoBehaviour
{
    [SerializeField]
    Image HitEffect;
    [SerializeField]
    Image EmptyImage;
    [SerializeField]
    GameObject ClearPanel;

    void Awake()
    {
        GameManager.Instance.UI = this;
    }

    public void ShowHitEffect()
    {
        HitEffect.color = new Color(HitEffect.color.r, HitEffect.color.g, HitEffect.color.b, 1.0f);
        StartCoroutine(IFadeIn(HitEffect, 2.0f));
    }

    public void ShowClearPanel()
    {
        ClearPanel.SetActive(true);
    }

    public void FadeOut(float Duration)
    {
        StartCoroutine(IFadeOut(EmptyImage, Duration));
    }

    public void FadeIn(float Duration)
    {
        StartCoroutine(IFadeIn(EmptyImage, Duration));
    }

    IEnumerator IFadeOut(Image image, float Duration)
    {
        Color color = image.color;
        while (image.color.a < 1.0f)
        {
            image.color = new Color(color.r, color.g, color.b, image.color.a + Time.deltaTime / Duration);
            yield return null;
        }
    }

    IEnumerator IFadeIn(Image image, float Duration)
    {
        Color color = image.color;
        while (image.color.a > 0.0f)
        {
            image.color = new Color(color.r, color.g, color.b, image.color.a - Time.deltaTime / Duration);
            yield return null;
        }
    }
}
