﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextPool : MonoBehaviour
{
    public GameObject dialogue1_prefab;
    public GameObject dialogue2_prefab;
    public GameObject tip_prefab;

    private Queue<GameObject> object_pool;

    private bool active = true;

    // Use this for initialization
    void Start()
    {
        object_pool = new Queue<GameObject>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!active)
            return;

        if (object_pool.Count > 0)
        {
            GameObject obj = object_pool.Dequeue();
            obj.SetActive(true);
            active = false;
        }
    }

    public void Continue()
    {
        active = true;
    }

    public void AddDialogue1(float _time, string _text)
    {
        GameObject obj = Instantiate(dialogue1_prefab, transform);
        Dialogue1 dialogue1 = obj.GetComponent<Dialogue1>();
        dialogue1.Init(this);
        dialogue1.SetTime(_time);
        dialogue1.SetText(_text);
        obj.SetActive(false);
        object_pool.Enqueue(obj);
    }

    public void AddDialogue2(string _speaker, string _text)
    {
        GameObject obj = Instantiate(dialogue2_prefab, transform);
        Dialogue2 dialogue2 = obj.GetComponent<Dialogue2>();
        dialogue2.Init(this);
        dialogue2.SetSpeaker(_speaker);
        dialogue2.SetText(_text);
        obj.SetActive(false);
        object_pool.Enqueue(obj);
    }

    public void AddTip(float _time, string _text)
    {
        GameObject obj = Instantiate(tip_prefab, transform);
        Tip tip = obj.GetComponent<Tip>();
        tip.Init(this);
        tip.SetTime(_time);
        tip.SetText(_text);
        obj.SetActive(false);
        object_pool.Enqueue(obj);
    }
}
