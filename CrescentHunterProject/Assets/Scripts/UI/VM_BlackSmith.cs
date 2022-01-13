using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace M4u
{
    public class VM_BlackSmith : M4uContextMonoBehaviour
    {
        void Awake()
        {
            GameManager.Instance.BlackSmithContext = this;
        }

        M4uProperty<ItemContext> clickedItem = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ClickedItem { get => clickedItem.Value; set => clickedItem.Value = value; }

        [SerializeField]
        ToggleGroup toggleGroup;

        M4uProperty<List<ItemContext>> materials = new M4uProperty<List<ItemContext>>(new List<ItemContext>());
        public List<ItemContext> Materials { get => materials.Value; }



        ItemMaterialSO itemMaterial;
        public void SelectItem()
        {
            bool ExistActive = false;
            foreach (Toggle t in toggleGroup.ActiveToggles())
            {
                ExistActive = true;
                itemMaterial = t.GetComponent<ToggleItem>().ItemSO;
                ClickedItem.Copy(itemMaterial.Item, 1);
                t.Select();
            }

            if (ExistActive == false)
            { ClickedItem.Copy(null); return; }

            Materials.Clear();
            for(int i = 0; i < itemMaterial?.Materials.Length; ++i)
            {
                ItemContext itemContext = new ItemContext();
                itemContext.Copy(itemMaterial.Materials[i].item, 1);
                Materials.Add(itemContext);
            }
        }
    }
}