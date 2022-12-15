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
        ts.Tokens = ts.Tokens + 1 *ts.TokensMultiplyer;
        float roundedtokensfloat = Mathf.Round(ts.Tokens);
        float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer);
        ts.TokensText.text = roundedtokensfloat + "$";
        ts.MultiplierText.text = roundedmultiplyerfloat + "x";
        PlayerPrefs.SetFloat("Tokens", ts.Tokens);
    }
    public IEnumerator MinionSetup()
    {
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(0.01f);
            ts.Tokens = ts.Tokens + 2 * ts.TokensMultiplyer;
            float roundedtokensfloat = Mathf.Round(ts.Tokens);
            float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer);
            ts.TokensText.text = roundedtokensfloat + "$";
            ts.MultiplierText.text = roundedmultiplyerfloat + "x";
            PlayerPrefs.SetFloat("Tokens", ts.Tokens);
            yield return new WaitForSecondsRealtime(2f);
        }
    }
}
