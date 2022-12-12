using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public TokensScript ts;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MinionSetup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMinionClick()
    {
        ts.Tokens = ts.Tokens + 1;
        ts.TokensText.text = "Tokens: " + ts.Tokens;
    }
    public IEnumerator MinionSetup()
    {
        for (; ; )
        {
            ts.Tokens = ts.Tokens + 2;
            ts.TokensText.text = "Tokens: " + ts.Tokens;
            yield return new WaitForSecondsRealtime(1.5f);
        }
    }
}
