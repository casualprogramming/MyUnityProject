using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField]
    Text _text;
    Dictionary<Type,UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();//for reflection

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
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Get<Text>((int)Texts.PointText).text="Bind Test";
    }

    void Bind<T>(Type type) where T:UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for(int i=0;i<names.Length;i++)
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if(_objects.TryGetValue(typeof(T),out objects)==false)
            return null;
        return objects[idx] as T;
    }

    int _score=0;
    public void OnButtonClicked()
    {
        _score++;
        _text.text= $"점수 : {_score}";
    }
}
