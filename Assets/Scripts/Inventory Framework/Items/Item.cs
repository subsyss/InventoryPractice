using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.Items//아이템은 UI 처리와 관련이 없으므로 다른 네임스페이스로 분류
{
    public abstract class Item : ScriptableObject //abstract: 스스로 생성되지 않도록(어떤 타입으로 생성되는지 알아야 함)
    {
        public Item_UI_Info uI_Info;
    }
}
