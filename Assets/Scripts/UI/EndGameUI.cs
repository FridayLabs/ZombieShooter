using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour {
    public Text Text;
    public string format;

    public void SetWin(bool isWin) {
        Text.text = format.Replace("{isWin}", isWin ? "WIN" : "LOSE");
    }
}