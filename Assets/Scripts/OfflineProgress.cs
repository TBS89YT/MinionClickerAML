using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OfflineProgress : MonoBehaviour
{
    public MinionScript ms;
    public TokensScript tss;

    void Start()
    {
        StartCoroutine(AddOfflineProgression());
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LAST_LOGIN", DateTime.Now.ToString());
    }
    public IEnumerator AddOfflineProgression()
    {
        yield return new WaitForSeconds(2);
        if (PlayerPrefs.HasKey("LAST_LOGIN"))
        {
            DateTime lastLogin = DateTime.Parse(PlayerPrefs.GetString("LAST_LOGIN"));

            TimeSpan ts = DateTime.Now - lastLogin;

            tss.Tokens += (int)ts.TotalSeconds * 2 * tss.TokensMultiplyer;

            print((int)ts.TotalSeconds * 2 * tss.TokensMultiplyer);

            print(ts.TotalSeconds.ToString());
        }
        else
        {
            print("lol");
        }
    }
}
