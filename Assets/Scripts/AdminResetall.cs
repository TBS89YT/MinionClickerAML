using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminResetall : MonoBehaviour
{
    public TokensScript ts;
    public ShopSystem ss;
    public Text AdminResetText;
    public void OnAdminResetAll()
    {
        PlayerPrefs.SetFloat("Tokens", 0);
        PlayerPrefs.SetFloat("TokensMultiplyer", 1);
        PlayerPrefs.SetFloat("HutActive", 0);
        PlayerPrefs.SetFloat("RolexActive", 0);
        PlayerPrefs.SetFloat("HutPrice", 150);
        PlayerPrefs.SetFloat("RolexPrice", 1500);
        ss.Hut.active = false;
        ss.Rolex.active = false;
        ss.HutPriceText.GetComponent<Text>().text = "150$";
        ss.RolexPriceText.GetComponent<Text>().text = "1500$";
        ss.HutPrice = 150;
        ss.RolexPrice = 1500;
        ts.Tokens = 0;
        ts.TokensText.text = "0$";
        ts.TokensMultiplyer = 1;
        ts.TokensMultiplyerText.text = "1x";
        StartCoroutine(SucessReset());
    }
    public IEnumerator SucessReset()
    {
        AdminResetText.text = "Everything got resettet.";
        yield return new WaitForSeconds(4);
        AdminResetText.text = "Reset-All [WARN]";
    }
}
