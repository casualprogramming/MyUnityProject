using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        Get<Text>((int)Texts.PointText).text="Bind Test";
    }

    int _score =0;
    public void OnButtonClicked()
    {
        _score++;
        _text.text= $"점수 : {_score}";
    }
}
