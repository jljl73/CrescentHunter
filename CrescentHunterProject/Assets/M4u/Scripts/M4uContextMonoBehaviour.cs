using UnityEngine;

namespace M4u
{
	public class M4uContextMonoBehaviour : MonoBehaviour, M4uContextInterface
    {
        void Awake()
        {
            GetComponent<M4uContextRoot>().ContextMonoBehaviour = this;
            GameManager.Instance.Context = this;
        }

        M4uProperty<int> hp = new M4uProperty<int>(50);
        public int Hp { get => hp.Value; set => hp.Value = value; }

        M4uProperty<int> maxHp = new M4uProperty<int>(100);
        public int MaxHp { get => maxHp.Value; set => maxHp.Value = value; }

        M4uProperty<float> hpRatio = new M4uProperty<float>(1.0f);
        public float HpRatio { get => hpRatio.Value; set => hpRatio.Value = value; }
    }
}