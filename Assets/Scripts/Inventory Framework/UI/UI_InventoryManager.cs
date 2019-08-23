using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace SA.InventoryFramework
{
    public class UI_InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private int slotAmount = 10; //슬롯 개수
        [SerializeField]
        GameObject slotPrefab; //실제 UI슬롯
        [SerializeField]
        Transform slotGrid; //슬롯 놓을 자리들
        [SerializeField]
        Transform mouseFollower;
        [SerializeField]
        Image mouseIcon;

        List<UI_Slot> inventorySlots = new List<UI_Slot>();//UI슬롯 리스트
        private UI_Slot currentSlot;
        bool mouseIsDown;
        bool mouseIsUp;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            for (int i = 0; i < slotAmount; i++)
            {
                GameObject go = Instantiate(slotPrefab) as GameObject;
                go.transform.SetParent(slotGrid);
                go.SetActive(true);
                inventorySlots.Add(go.GetComponent<UI_Slot>());
            }

            mouseIcon.enabled = false;
        }
        private void Update()
        {
            FindCurrentSlot();
            MouseInput();
            DetectAction();
        }

        void FindCurrentSlot()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current) //EventSystem.current : 현재의 이벤트시스템 반환
            {
                position = Input.mousePosition
            };
            //pointerData.position=Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            for (int i = 0; i < results.Count; i++)
            {
                currentSlot = results[i].gameObject.GetComponentInParent<UI_Slot>();//?
            }

            if (results.Count == 0)
            {
                currentSlot = null;
            }

        }
        void MouseInput()
        {
            mouseIsDown = Input.GetMouseButtonDown(0);
            mouseIsUp = Input.GetMouseButtonUp(0);

            mouseFollower.position = Input.mousePosition;
        }
        void DetectAction()
        {
            if (mouseIsDown)
            {
                if (currentSlot == null) //슬롯에 저장된 아이템이 없으면 리턴
                {
                    return;
                }

                currentSlot.OnClick(this); //슬롯 아이템 클릭
            }
            if (mouseIsUp)
            {
                if (currentSlot == null)
                {
                    return;
                }

                currentSlot.OnDropItem(this); //슬롯 아이템 드랍
            }
        }
    }
}

