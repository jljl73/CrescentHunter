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
    List<List<GameObject>> projectiles = new List<List<GameObject>>();

    [SerializeField]
    GameObject[] poolables;
    public Dictionary<string, Stack<GameObject>> pool = new Dictionary<string, Stack<GameObject>>();

    void Start()
    {
        if (_instance == null)
            _instance = this;

        if (DamageText == null)
            throw new System.Exception("Damage Text ¹ÌÇÒ´ç");

        for (int i = 0; i < 10; ++i)
            damagetexts.Push(Instantiate(DamageText, canvas.transform));

        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < poolables.Length; ++i)
        {
            string Key = poolables[i].GetComponent<Poolable>().Key;
            Transform parent = poolables[i].GetComponent<Poolable>().IsCanvas ? canvas.transform : transform;

            pool[Key] = new Stack<GameObject>();
            GameObject poolable = poolables[i];

            for (int c = 0; c < 5;++c)
                pool[Key].Push(Instantiate(poolable, parent));
        }
    }

    public void CreateDamageText(Vector3 position, float Damage, bool IsPlayer)
    {
        if(damagetexts.Count == 0)
            damagetexts.Push(Instantiate(DamageText));

        GameObject newObj = damagetexts.Pop();
        newObj.transform.position = mainCamera.WorldToScreenPoint(position);
        newObj.GetComponent<DamageText>().Create(Damage, IsPlayer);
    }
        
    public void DestoryDamageText(GameObject gameObject)
    {
        damagetexts.Push(gameObject);
    }

    public void CreateEffect(string Key, Vector3 position)
    {
        GameObject newObj = pool[Key].Pop();
        newObj.SetActive(true);
        newObj.transform.position = position;
    }
}
