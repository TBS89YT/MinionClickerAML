using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TokensScript : MonoBehaviour
{
    public float Tokens;
    public Text TokensText;
    public Text TokensMultiplyerText;
    public float TokensMultiplyer = 1;

    void Start()
    {
        float savedtokens = PlayerPrefs.GetFloat("Tokens", 0);
        Tokens = savedtokens;
        float tokensmultiplyer = PlayerPrefs.GetFloat("TokensMultiplyer", 1);
        TokensMultiplyer = tokensmultiplyer;
        float roundedmultiplyerfloat = Mathf.Round(TokensMultiplyer * 100.0f) * 0.01f;
        TokensText.text = ChangeNumber(Tokens).ToString() + "$";
        TokensMultiplyerText.text = roundedmultiplyerfloat + "x";
    }
    public string ChangeNumber(float Tokens)
    {
        string value;
        if (Tokens >= 1000000000000)
            value = Math.Abs(Tokens / 1000000000000).ToString("N2") + "T";
        else if (Tokens >= 1000000000)
            value = Math.Abs(Tokens / 1000000000).ToString("N2") + "B";
        else if (Tokens >= 1000000)
            value = Math.Abs(Tokens / 1000000).ToString("N2") + "M";
        else if (Tokens >= 1000)
            value = Math.Abs(Tokens / 1000).ToString("N2") + "K";
        else
            value = Tokens.ToString();
        return value;
    }
}
