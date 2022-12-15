using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TokensScript : MonoBehaviour
{
    public float Tokens;
    public Text TokensText;
    public Text MultiplierText;
    public float TokensMultiplyer = 1;

    void Start()
    {
        float savedtokens = PlayerPrefs.GetFloat("Tokens", 0);
        Tokens = savedtokens;
        float tokensmultiplyer = PlayerPrefs.GetFloat("TokensMultiplyer", 1);
        TokensMultiplyer = tokensmultiplyer;
        float roundedtokensfloat = Mathf.Round(Tokens);
        float roundedmultiplyerfloat = Mathf.Round(TokensMultiplyer);
        TokensText.text = roundedtokensfloat + "$";
        MultiplierText.text = roundedmultiplyerfloat + "x";
    }
}
