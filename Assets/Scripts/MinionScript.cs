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
        ts.Tokens += 2 * ts.TokensMultiplyer / 2;
        float roundedtokensfloat = Mathf.Round(ts.Tokens * 100.0f) * 0.01f;
        float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer * 100.0f) * 0.01f;
        ts.TokensText.text = roundedtokensfloat + "$";
        ts.MultiplierText.text = roundedmultiplyerfloat + "x";
        PlayerPrefs.SetFloat("Tokens", ts.Tokens);
    }
    public IEnumerator MinionSetup()
    {
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(0.01f);
            ts.Tokens += 2 * ts.TokensMultiplyer;
            float roundedtokensfloat = Mathf.Round(ts.Tokens * 100.0f) * 0.01f;
            float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer * 100.0f) * 0.01f;
            ts.TokensText.text = roundedtokensfloat + "$";
            ts.MultiplierText.text = roundedmultiplyerfloat + "x";
            PlayerPrefs.SetFloat("Tokens", ts.Tokens);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
