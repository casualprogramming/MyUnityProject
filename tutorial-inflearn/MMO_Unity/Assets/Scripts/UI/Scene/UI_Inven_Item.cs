using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name;

    public override void init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        Get<GameObject>((int)GameObjects.ItemIcon).AddUIEvent((PointerEventData)=>{ Debug.Log($"아이템 출력! {_name}"); });
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    
    //this function must be called before Start()
    public void SetInfo(string name)
    {
        _name=name;
    }
}
