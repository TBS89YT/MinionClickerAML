using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokensScript : MonoBehaviour
{

    public float Tokens;
    public Text TokensText;

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
