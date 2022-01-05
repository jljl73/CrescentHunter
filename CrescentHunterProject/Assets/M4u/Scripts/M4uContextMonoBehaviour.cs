using UnityEngine;
using System.Collections.Generic;

namespace M4u
{
	public class M4uContextMonoBehaviour : MonoBehaviour, M4uContextInterface
    {
        void Awake()
        {
            GetComponent<M4uContextRoot>().ContextMonoBehaviour = this;
            GameManager.Instance.Context = this;
        }

        M4uProperty<float> hp = new M4uProperty<float>(50);
        public float Hp { get => hp.Value; set => hp.Value = value; }

        M4uProperty<float> maxHp = new M4uProperty<float>(100);
        public float MaxHp { get => maxHp.Value; set => maxHp.Value = value; }

        // 체력바
        M4uProperty<float> hpRatio = new M4uProperty<float>(1.0f);
        public float HpRatio { get => hpRatio.Value; set => hpRatio.Value = value; }

        M4uProperty<float> spRatio = new M4uProperty<float>(1.0f);
        public float SpRatio { get => spRatio.Value; set => spRatio.Value = value; }

        // 아이템 슬롯
        M4uProperty<Sprite> itemSlotCSprite = new M4uProperty<Sprite>();
        public Sprite ItemSlotCSprite { get => itemSlotCSprite.Value; set => itemSlotCSprite.Value = value; }

        M4uProperty<ItemContext> itemSlotC = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ItemSlotC { get => itemSlotC.Value; set => itemSlotC.Value.Copy(value); }

        M4uProperty<ItemContext> itemSlotL = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ItemSlotL { get => itemSlotL.Value; set => itemSlotL.Value.Copy(value); }

        M4uProperty<ItemContext> itemSlotR = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ItemSlotR { get => itemSlotR.Value; set => itemSlotR.Value.Copy(value); }


    }
}