using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    [SerializeField]
    Text _text;

    //in this case, enum is used for unique id not for type
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        ScoreText,
        PointText
    }
    enum GameObjects
    {
        TestObject,
    }
    enum Images
    {
        ItemIcon,
    }
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        Get<Text>((int)Texts.PointText).text="Bind Test";
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        evt.OnDragHandler += ((PointerEventData data) =>{go.transform.position = data.position;});
    }

    int _score =0;
    public void OnButtonClicked()
    {
        _score++;
        _text.text= $"점수 : {_score}";
    }
}
