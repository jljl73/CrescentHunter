using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    static ObjectPool _instance = null;

    public static ObjectPool Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newObj = Instantiate(new GameObject());
                _instance = newObj.AddComponent<ObjectPool>();
            }
            return _instance;
        }
    }

    [SerializeField]
    GameObject DamageText;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Canvas canvas;

    Stack<GameObject> damagetexts = new Stack<GameObject>();

    void Start()
    {
        if (_instance == null)
            _instance = this;

        if (DamageText == null)
            throw new System.Exception("Damage Text ¹ÌÇÒ´ç");

        for (int i = 0; i < 10; ++i)
            damagetexts.Push(Instantiate(DamageText, canvas.transform));
    }

    public void CreateDamageText(Vector3 position, int Damage)
    {
        if(damagetexts.Count == 0)
            damagetexts.Push(Instantiate(DamageText));

        GameObject newObj = damagetexts.Pop();
        newObj.transform.position = mainCamera.WorldToScreenPoint(position);
        newObj.GetComponent<DamageText>().Create(Damage);
    }

    public void CreateRandomMissile(Vector3 position)
    {

    }

    public void DestoryDamageText(GameObject gameObject)
    {
        damagetexts.Push(gameObject);
    }
}
