using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA.InventoryFramework
{
    public class UI_Slot : MonoBehaviour
    {
        [SerializeField]
        SlotType slotType;
        [SerializeField]
        Image Icon; //슬롯에 들어갈 이미지

        [HideInInspector]
        public Items.Item ItemInstance; //슬롯에 있는 아이템 인스턴스

        private void Awake()
        {
            Icon.enabled = false;
        }

        public void LoadItem(Items.Item targetItem)
        {
            ItemInstance = targetItem;
            if (ItemInstance != null)
            {

            }
            else { }
        }

        public void OnClick(UI_InventoryManager invManager)
        {
            Debug.Log("on click");
            slotType.OnClick(this, invManager);
        }

        public void OnDropItem(UI_InventoryManager invManager)
        {
            Debug.Log("drop item");

        }

    }
}
