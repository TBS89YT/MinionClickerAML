using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokensScript : MonoBehaviour
{

    public float Tokens = 0;
    public Text TokensText;

    // Start is called before the first frame update
    void Start()
    {
        TokensText.text = "Tokens: " + Tokens;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
