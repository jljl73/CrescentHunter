using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace M4u
{
    public class VM_BlackSmith : M4uContextMonoBehaviour
    {
        [SerializeField]
        ItemMaterialSO[] itemMaterials = null;

        ItemMaterialSO itemMaterial;
        Inventory inventory;
        Equipment equipment;


        void Awake()
        {
            GameManager.Instance.BlackSmithContext = this;
            inventory = Inventory.Instance;
            equipment = GameManager.Instance.player.Equipment;
        }

        void OnEnable()
        {
            Materials.Clear();
            ClickedItem.Copy(null);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (itemMaterial != null && itemMaterial.IsMeet(inventory))
                {
                    itemMaterial.Produce(inventory, equipment);
                    MaterialUpdate();
                }
            }
        }


        M4uProperty<ItemContext> clickedItem = new M4uProperty<ItemContext>(new ItemContext());
        public ItemContext ClickedItem { get => clickedItem.Value; set => clickedItem.Value = value; }

        M4uProperty<List<ItemContext>> materials = new M4uProperty<List<ItemContext>>(new List<ItemContext>());
        public List<ItemContext> Materials { get => materials.Value; }

        public void SelectItem(int index)
        {
            itemMaterial = itemMaterials[index];
            ClickedItem.Copy(itemMaterial.Item, 1, 1);

            MaterialUpdate();
        }

        void MaterialUpdate()
        {
            Materials.Clear();

            for (int i = 0; i < itemMaterial?.Materials.Length; ++i)
            {
                ItemContext itemContext = new ItemContext();
                itemContext.Copy(itemMaterial.Materials[i].item, inventory.GetNumberItem(itemMaterial.Materials[i].item), itemMaterial.Materials[i].Num);
                Materials.Add(itemContext);
            }
        }
    }
}