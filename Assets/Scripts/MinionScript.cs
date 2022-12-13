using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public TokensScript ts;
    void Start()
    {
        StartCoroutine(MinionSetup());
    }
    public void OnMinionClick()
    {
        ts.Tokens = ts.Tokens + 1;
        ts.TokensText.text = "Tokens: " + ts.Tokens;
        PlayerPrefs.SetFloat("Tokens", ts.Tokens);
    }
    public IEnumerator MinionSetup()
    {
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(0.01f);
            ts.Tokens = ts.Tokens + 2;
            ts.TokensText.text = "Tokens: " + ts.Tokens;
            PlayerPrefs.SetFloat("Tokens", ts.Tokens);
            yield return new WaitForSecondsRealtime(2f);
        }
    }
}
