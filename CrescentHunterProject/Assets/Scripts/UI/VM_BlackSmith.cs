using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace M4u
{
    public class VM_BlackSmith : M4uContextMonoBehaviour
    {
        Inventory inventory;
        void Awake()
        {
            GameManager.Instance.BlackSmithContext = this;
        }

        void Start()
        {
            inventory = Inventory.Instance;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (itemMaterial != null && itemMaterial.IsMeet(inventory))
                {
                    itemMaterial.Produce(inventory);
                }
            }
        }


        M4uProperty<ItemContext> clickedItem = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ClickedItem { get => clickedItem.Value; set => clickedItem.Value = value; }

        [SerializeField]
        ToggleGroup toggleGroup;

        M4uProperty<List<ItemContext>> materials = new M4uProperty<List<ItemContext>>(new List<ItemContext>());
        public List<ItemContext> Materials { get => materials.Value; }

        ItemMaterialSO itemMaterial = null;
        public void SelectItem()
        {
            bool ExistActive = false;
            foreach (Toggle t in toggleGroup.ActiveToggles())
            {
                ExistActive = true;
                itemMaterial = t.GetComponent<ToggleItem>().ItemSO;
                ClickedItem.Copy(itemMaterial.Item, 1, 1);
                t.Select();
            }

            Materials.Clear();
            if (ExistActive == false)
            { ClickedItem.Copy(null); return; }

            for(int i = 0; i < itemMaterial?.Materials.Length; ++i)
            {
                ItemContext itemContext = new ItemContext();
                itemContext.Copy(itemMaterial.Materials[i].item, inventory.GetNumberItem(itemMaterial.Materials[i].item), itemMaterial.Materials[i].Num);
                Materials.Add(itemContext);
            }
        }
    }
}