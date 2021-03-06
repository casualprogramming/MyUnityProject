﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{

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
        init();
    }

    public override void init()
    {
        base.init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));


        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    int _score =0;
    public void OnButtonClicked(PointerEventData eventData)
    {
        _score++;
        Get<Text>((int)Texts.ScoreText).text = $"점수 : {_score}";
        /* @ Before
         * _text.text= $"점수 : {_score}"; and connect ScoreText to '_text' variable in unity
         */
    }
}
