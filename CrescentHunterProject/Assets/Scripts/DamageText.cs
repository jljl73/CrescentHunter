using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField]
    float Duration = 2.4f;

    TextMeshProUGUI text;
    Color initialColor;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        initialColor = text.color;
    }

    void OnEnable()
    {
        Invoke("Disapear", Duration);
        text.color = initialColor;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime / Duration);
            yield return null;
        }
    }

    void Disapear()
    {
        gameObject.SetActive(false);
        ObjectPool.Instance.DestoryDamageText(gameObject);
    }

    public void Create(float Damage)
    {
        gameObject.SetActive(true);
        text.text = Damage.ToString();
    }
}
