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
            StartCoroutine(AddOfflineTime());
            StartCoroutine(AddOfflineProgression());
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
        if (ts.TotalHours >= 6)
        {
            offlineseconds.text = "Off-Time -> 6 Hour [MAX]";
            yield return new WaitForSeconds(8);
            offlineseconds.text = "";
        }
        else
        {
            offlineseconds.text = "Off-Time -> " + Mathf.Abs((float)ts.TotalMinutes) + " Minutes";
            yield return new WaitForSeconds(8);
            offlineseconds.text = "";
        }
    }
    public IEnumerator AddOfflineProgression()
    {
        yield return new WaitForSeconds(1);
        if (PlayerPrefs.HasKey("LAST_LOGIN"))
        {
            DateTime lastLogin = DateTime.Parse(PlayerPrefs.GetString("LAST_LOGIN"));

            TimeSpan ts = DateTime.Now - lastLogin;

            if(ts.TotalHours >= 6)
            {
                float moneytogive = 21600 * 2 * tss.TokensMultiplyer;
                offlineearnings.text = "Off-Earnings: " + tss.ChangeNumber(moneytogive) + " [MAX]";
                tss.Tokens += 21600 * 2 * tss.TokensMultiplyer;
                yield return new WaitForSeconds(8);
                offlineearnings.text = "";
            } else
            {
                tss.Tokens += (int)ts.TotalSeconds * 2 * tss.TokensMultiplyer;

                print((int)ts.TotalSeconds * 2 * tss.TokensMultiplyer);

                print(ts.TotalSeconds.ToString());
                float moneytogive = (int)ts.TotalSeconds * 2 * tss.TokensMultiplyer;
                offlineearnings.text = "Off-Earnings: " + tss.ChangeNumber(moneytogive);
                yield return new WaitForSeconds(8);
                offlineearnings.text = "";
            }
        }
        else
        {
            print("ERROR -> OfflineProgressionen Failure.");
        }
    }
}
