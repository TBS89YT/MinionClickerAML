using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class OfflineProgress : MonoBehaviour
{
    public MinionScript ms;
    public TokensScript tss;
    public Text offlineearnings;
    public Text offlineseconds;


    void Start()
    {
    }
    public void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            StartCoroutine(AddOfflineProgression());
            StartCoroutine(AddOfflineTime());
        } else
        {
            PlayerPrefs.SetString("LAST_LOGIN", DateTime.Now.ToString());
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LAST_LOGIN", DateTime.Now.ToString());
    }
    public IEnumerator AddOfflineTime()
    {
        yield return new WaitForSeconds(1);
        DateTime lastLogin = DateTime.Parse(PlayerPrefs.GetString("LAST_LOGIN"));
        TimeSpan ts = DateTime.Now - lastLogin;
        offlineseconds.text = "Off-Time -> " + (int)ts.TotalSeconds +" Seconds";
        StartCoroutine(AddOfflineProgression());
        yield return new WaitForSeconds(8);
        offlineseconds.text = "";
    }
    public IEnumerator AddOfflineProgression()
    {
        yield return new WaitForSeconds(1);
        if (PlayerPrefs.HasKey("LAST_LOGIN"))
        {
            DateTime lastLogin = DateTime.Parse(PlayerPrefs.GetString("LAST_LOGIN"));

            TimeSpan ts = DateTime.Now - lastLogin;

            tss.Tokens += (int)ts.TotalSeconds * 2 * tss.TokensMultiplyer;

            print((int)ts.TotalSeconds * 2 * tss.TokensMultiplyer);

            print(ts.TotalSeconds.ToString());
            offlineearnings.text = "Off-Earnings: "+ (int)ts.TotalSeconds * 2 * tss.TokensMultiplyer;
            yield return new WaitForSeconds(8);
            offlineearnings.text = "";
        }
        else
        {
            print("ERROR -> OfflineProgressionen Failure.");
        }
    }
}
