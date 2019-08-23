using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA.InventoryFramework
{
    public class UI_Slot : MonoBehaviour
    {
        public void OnClick(UI_InventoryManager invManager)
        {
            Debug.Log("on click");
        }

        public void OnDropItem(UI_InventoryManager invManager)
        {
            Debug.Log("drop item");

        }

    }
}
