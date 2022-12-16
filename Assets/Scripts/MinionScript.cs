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
        float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer * 100.0f) * 0.01f;
        ts.TokensText.text = ts.ChangeNumber(ts.Tokens).ToString() + "$";
        ts.TokensMultiplyerText.text = roundedmultiplyerfloat + "x";
        PlayerPrefs.SetFloat("Tokens", ts.Tokens);
    }
    public IEnumerator MinionSetup()
    {
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(0.01f);
            ts.Tokens += 2 * ts.TokensMultiplyer;
            float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer * 100.0f) * 0.01f;
            ts.TokensText.text = ts.ChangeNumber(ts.Tokens).ToString() + "$";
            ts.TokensMultiplyerText.text = roundedmultiplyerfloat + "x";
            PlayerPrefs.SetFloat("Tokens", ts.Tokens);
            yield return new WaitForSecondsRealtime(1f);
        }

    }
}
