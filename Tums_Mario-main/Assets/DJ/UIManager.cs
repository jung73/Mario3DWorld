using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //
    public TMP_Text CoinCheck;

    // Update is called once per frame
    void Update()
    {
        
        if (CoinCheck != null)
        {
            // Player 스크립트의 static 변수인 coin 값
            CoinCheck.text = "Coin : " + Player.coin;
        }
    }
}
