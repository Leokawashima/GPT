﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// AIがメッセージを受け取る用
/// </summary>
public class AIMessage : MonoBehaviour
{
    [SerializeField]
    bool GPTON = false;
    [SerializeField] InputField APIKey;
    [SerializeField] InputField Rule;
    [SerializeField] InputField Message;
    [SerializeField] Button DecisionButton;
    [SerializeField] Text AIMesse;

    void Start()
    {
        DecisionButton.onClick.AddListener(Decision);
    }



    async void Decision()
    {
        if (GPTON)
        {
            ChatGPTConnection gpt = new ChatGPTConnection(APIKey.text, Rule.text);
            var response = await gpt.RequestAsync(Message.text);
            AIMesse.text = response.choices[0].message.content;
        }
    }
} 
