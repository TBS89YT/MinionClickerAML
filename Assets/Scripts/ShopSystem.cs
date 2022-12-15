using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public GameObject ShopButton;
    public GameObject ShopImage;
    public GameObject ShopText;
    public GameObject HutPriceText;
    public Animator tween;

    public TokensScript ts;

    public GameObject Hut;

    public float HutPrice = 25;
    void Start()
    {
        HutPrice = PlayerPrefs.GetFloat("HutPrice", 25);
        HutPriceText.GetComponent<Text>().text = HutPrice.ToString() + "$";
        int hutisactive = PlayerPrefs.GetInt("HutActive", 0);
        if (hutisactive == 1)
        {
            Hut.active = true;
        }
    }
    public void OnShopClick()
    {
        if(ShopText.transform.rotation.x == 0)
        {
            tween.SetTrigger("Highlighted");
        }
        ShopImage.active = true;
    }
    public void OnPurchaseHut ()
    {
        if(ts.Tokens < HutPrice)
        {
            return;
        }
        if (Hut.active == false)
        {
            Hut.active = true;
        }

        PlayerPrefs.SetInt("HutActive", 1);
        ts.Tokens = ts.Tokens - HutPrice;
        PlayerPrefs.SetFloat("Tokens", ts.Tokens);
        ts.TokensMultiplyer = ts.TokensMultiplyer + 0.2f; //Multiplier von "* 1.2f" auf "+ 0.2" geändert
        PlayerPrefs.SetFloat("TokensMultiplyer", ts.TokensMultiplyer);
        HutPrice = HutPrice * 1.6f;
        HutPriceText.GetComponent<Text>().text = HutPrice.ToString() + "$";
        PlayerPrefs.SetFloat("HutPrice", HutPrice);
        float roundedtokensfloat = Mathf.Round(ts.Tokens);
        float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer);
        ts.TokensText.text = roundedtokensfloat + "$ x" + roundedmultiplyerfloat;
    }
}
