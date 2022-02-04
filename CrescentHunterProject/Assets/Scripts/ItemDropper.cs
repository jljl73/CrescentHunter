using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [System.Serializable]
    public struct ItemProb
    {
        public ItemSO item;
        public float Prob;
    }
    [SerializeField]
    GameObject GoldPrefab;
    [SerializeField]
    GameObject ItemPrefab;
    [SerializeField]
    ItemProb[] items;

    public void DropItems()
    {
        for(int i = items.Length- 1; i >=0;--i)
        {
            float Prob = Random.Range(0.0f, 100.0f);
            if (Prob < items[i].Prob)
                Drop(items[i].item);
        }
        DropGold();
    }

    void Drop(ItemSO item)
    {
        GameObject newItem = Instantiate(ItemPrefab, transform.position + RandomVector(), transform.rotation);
        newItem.GetComponent<ItemObject>().ItemData = item;
    }

    void DropGold()
    {
        GameObject newItem = Instantiate(GoldPrefab, transform.position + RandomVector(), transform.rotation);
    }

    Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-4.0f, 4.0f));
    }
}
