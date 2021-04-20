using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }
    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    public override void init()
    {
        base.init();
        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPannel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach(Transform child in gridPannel.transform)
            Managers.Resource.Destory(child.gameObject);//clear
        
        //TODO: refer to inventory data
        const int invCount = 8;
        for(int i=0;i< invCount; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent: gridPannel.transform).gameObject;
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"집행검{i}번");//called before UI_Inven_Item.start() has been called yet
        }
    }
    // Update is called once per frame
    void Update()
    {
        return;
    }
}
