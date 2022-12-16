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
    public GameObject RolexPriceText;
    public Animator tween;

    public TokensScript ts;

    public GameObject Hut;
    public GameObject Rolex;

    public float HutPrice = 150;
    public float RolexPrice = 1500;
    void Start()
    {
        HutPrice = PlayerPrefs.GetFloat("HutPrice", 150);
        HutPriceText.GetComponent<Text>().text = HutPrice.ToString() + "$";
        RolexPrice = PlayerPrefs.GetFloat("RolexPrice", 1500);
        RolexPriceText.GetComponent<Text>().text = RolexPrice.ToString() + "$";
        int hutisactive = PlayerPrefs.GetInt("HutActive", 0);
        int rolexisactive = PlayerPrefs.GetInt("RolexActive", 0);
        if (hutisactive == 1)
        {
            Hut.active = true;
        }
        if (rolexisactive == 1)
        {
            Rolex.active = true;
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
        ts.TokensMultiplyer = ts.TokensMultiplyer + 0.2f;
        PlayerPrefs.SetFloat("TokensMultiplyer", ts.TokensMultiplyer);
        HutPrice = HutPrice * 2f;
        HutPrice = Mathf.Round(HutPrice * 100.0f) * 0.01f;
        HutPriceText.GetComponent<Text>().text = HutPrice.ToString() + "$";
        PlayerPrefs.SetFloat("HutPrice", HutPrice);
        float roundedtokensfloat = Mathf.Round(ts.Tokens * 100.0f) * 0.01f;
        float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer * 100.0f) * 0.01f;
        ts.TokensText.text = roundedtokensfloat + "$";
        ts.MultiplierText.text = roundedmultiplyerfloat + "x";
    }
    public void OnPurchaseRolex()
    {
        if (ts.Tokens < RolexPrice)
        {
            return;
        }
        if (Rolex.active == false)
        {
            Rolex.active = true;
        }
        PlayerPrefs.SetInt("RolexActive", 1);
        ts.Tokens = ts.Tokens - RolexPrice;
        PlayerPrefs.SetFloat("Tokens", ts.Tokens);
        ts.TokensMultiplyer = ts.TokensMultiplyer + 0.6f;
        PlayerPrefs.SetFloat("TokensMultiplyer", ts.TokensMultiplyer);
        RolexPrice = RolexPrice * 3f;
        RolexPrice = Mathf.Round(RolexPrice * 100.0f) * 0.01f;
        RolexPriceText.GetComponent<Text>().text = RolexPrice.ToString() + "$";
        PlayerPrefs.SetFloat("RolexPrice", RolexPrice);
        float roundedtokensfloat = Mathf.Round(ts.Tokens * 100.0f) * 0.01f;
        float roundedmultiplyerfloat = Mathf.Round(ts.TokensMultiplyer * 100.0f) * 0.01f;
        ts.TokensText.text = roundedtokensfloat + "$";
        ts.MultiplierText.text = roundedmultiplyerfloat + "x";
    }
}
