//----------------------------------------------
// MVVM 4 uGUI
// © 2015 yedo-factory
//----------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace M4u
{
    /// <summary>
    /// M4uTextBinding. Bind Text
    /// </summary>
	[AddComponentMenu("M4u/TextBinding")]
    public class M4uTextBinding : M4uBindingSingle
    {
        public string Format = "";

        TextMeshProUGUI ui;

        public override void Start()
        {
            base.Start();

            ui = GetComponent<TextMeshProUGUI>();
            OnChange();
        }

        public override void OnChange()
        {
            base.OnChange();

            ui.text = string.Format(Format, Values[0]);
        }

        public override string ToString()
        {
            return "Text.text=" + string.Format(Format, GetBindStr(Path));
        }
    }
}