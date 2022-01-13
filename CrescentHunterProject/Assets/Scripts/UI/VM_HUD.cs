using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace M4u
{
    public class VM_HUD : M4uContextMonoBehaviour
    {
        void Awake()
        {
            GameManager.Instance.HUDContext = this;
        }

        M4uProperty<float> hp = new M4uProperty<float>(50);
        public float Hp { get => hp.Value; set => hp.Value = value; }

        M4uProperty<float> maxHp = new M4uProperty<float>(100);
        public float MaxHp { get => maxHp.Value; set => maxHp.Value = value; }

        // ü�¹�
        M4uProperty<float> hpRatio = new M4uProperty<float>(1.0f);
        public float HpRatio { get => hpRatio.Value; set => hpRatio.Value = value; }

        M4uProperty<float> spRatio = new M4uProperty<float>(1.0f);
        public float SpRatio { get => spRatio.Value; set => spRatio.Value = value; }

        // ������ ����
        M4uProperty<Sprite> itemSlotCSprite = new M4uProperty<Sprite>();
        public Sprite ItemSlotCSprite { get => itemSlotCSprite.Value; set => itemSlotCSprite.Value = value; }

        M4uProperty<ItemContext> itemSlotC = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ItemSlotC { get => itemSlotC.Value; set { itemSlotC.Value.Copy(value); } }

        M4uProperty<ItemContext> itemSlotL = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ItemSlotL { get => itemSlotL.Value; set { itemSlotL.Value.Copy(value); } }

        M4uProperty<ItemContext> itemSlotR = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ItemSlotR { get => itemSlotR.Value; set { itemSlotR.Value.Copy(value); } }

        // ��ó ��ȣ�ۿ� ����
        M4uProperty<string> itemName = new M4uProperty<string>("");
        public string ItemName { get => itemName.Value; set => itemName.Value = value; }

        // ȹ���� ������
        M4uProperty<List<string>> itemLogs = new M4uProperty<List<string>>(new List<string>());
        public List<string> ItemLogs { get => itemLogs.Value; set => itemLogs.Value = value; }
    }
}