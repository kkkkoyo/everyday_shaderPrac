using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class users {
    public Itemquestions[] questions;
}

[Serializable]
public class Itemquestions
{
    public string name;
    public int age;
}
public class JsonUtil : MonoBehaviour {

    public Text txtString;

    void Start() {
        TextAsset txtData = Resources.Load("Json/test1")as TextAsset;
        string textJson = txtData.text;

        users item = JsonUtility.FromJson<users>(textJson);
        Debug.Log(item.questions[0].age+":"+item.questions[0].name);

    }
}
