using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCoinsMana : MonoBehaviour
{
    [SerializeField] AudioClip coinsSound;
    [SerializeField] AudioClip potionsSound;

    [SerializeField] int livePlus, manaPlus, coinsPlus;

    public int live, mana, coins;

    [SerializeField] Text liveTxt, manaTxt, coinsTxt;

    public void AddLive()
    {
        if(live < 100)
        {
            live += livePlus;
            GetComponent<AudioSource>().clip = potionsSound;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            live = 100;
        }

        liveTxt.text = live.ToString();
    }

    public void AddMana()
    {
        if(mana < 100)
        {
            mana += manaPlus;
            GetComponent<AudioSource>().clip = potionsSound;
            GetComponent<AudioSource>().Play();
        }

        else
        {
            mana = 100;
        }

        manaTxt.text = mana.ToString();
    }

    public void AddCoins()
    {
        coins += coinsPlus;

        GetComponent<AudioSource>().clip = coinsSound;
        GetComponent<AudioSource>().Play();

        coinsTxt.text = coins.ToString();
    }

    public void RemoveMana()
    {
        mana -= 10;
        manaTxt.text = mana.ToString();
    }

    public void RemoveLife()
    {
        live -= 20;
        liveTxt.text = live.ToString();
    }
}
