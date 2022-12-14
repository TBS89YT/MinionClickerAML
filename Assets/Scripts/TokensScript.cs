using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TokensScript : MonoBehaviour
{

    public float Tokens;
    public Text TokensText;
    public float LastTicks;

    void Start()
    {
        float savedtokens = PlayerPrefs.GetFloat("Tokens", 0);
        Tokens = savedtokens;
        TokensText.text = "Tokens: " + savedtokens;
    }

    void Update()
    {
        
    }
}
