using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SA.InventoryFramework
{
    public abstract class SlotType : ScriptableObject
    {
        public abstract void OnClick(UI_Slot slot, UI_InventoryManager invManager); //slot: 실제 사용하는 슬롯
        public abstract void OnDropItem(UI_Slot slot, Items.Item item, UI_InventoryManager invManager);

    }

}
