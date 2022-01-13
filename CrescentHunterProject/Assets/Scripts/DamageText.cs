using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField]
    float Duration = 2.4f;

    TextMeshProUGUI text;
    Color initialColor;

    StringBuilder sb = new StringBuilder();

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        initialColor = text.color;
    }

    void OnEnable()
    {
        Invoke("Disapear", Duration);
        text.color = initialColor;
        //StartCoroutine(FadeOut());
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

    public void Create(float Damage, bool IsPlayer)
    {
        sb.Clear();
        gameObject.SetActive(true);
        if (IsPlayer)
            sb.Append("<color=#FFD400>");
        else
            sb.Append("<color=#FF0000>");
        sb.Append(Damage);
        sb.Append("</color>");
        text.text = sb.ToString();
    }
}
