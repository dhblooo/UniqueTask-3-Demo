﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogue2 : MonoBehaviour
{
    public Text text_prefab;
    public Text speaker_prefab;
    public RawImage box_prefab;
    public RawImage portrait_prefab;

    private Text text;
    private Text speaker;
    private RawImage box;
    private RawImage portrait;

    private bool inited = false;
    private TextPool pool;

    public KeyCode key_continue = KeyCode.E;

    // Use this for initialization
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(key_continue))
            Destroy(gameObject);
    }

    public void Init(TextPool _pool)
    {
        if (inited)
            return;

        pool = _pool;
        portrait = Instantiate(portrait_prefab, transform);
        box = Instantiate(box_prefab, transform);
        speaker = Instantiate(speaker_prefab, transform);
        text = Instantiate(text_prefab, transform);

        // Set Game Stop
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Pause();

        inited = true;
    }

    public void SetText(string _text)
    {
        text.text = _text;
    }

    public void SetSpeaker(string _speaker)
    {
        speaker.text = _speaker;
    }

    private void OnDestroy()
    {
        if (inited)
        {
            pool.Continue();
            Destroy(text);
            Destroy(speaker);
            Destroy(box);
            Destroy(portrait);

            // Set Game Continue
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Continue();
        }
    }
}
