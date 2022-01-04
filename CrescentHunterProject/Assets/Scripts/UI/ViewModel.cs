using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace M4u
{
    public class ViewModel : MonoBehaviour
    {
        M4uProperty<int> hp;

        public int Hp { get => hp.Value; set => hp.Value = value; }

    }
}
