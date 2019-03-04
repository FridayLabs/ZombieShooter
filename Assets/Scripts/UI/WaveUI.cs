using System;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour {
    public Text Text;
    private string format;

    private void Start() {
        format = Text.text;
    }

    private void LateUpdate() {
        if (GameManager.Instance.IsPrepearingStage) {
            Text.text = "PREPARE";
        } else {
            Text.text = format.Replace("{n}", GameManager.Instance.GetCurrentWaveNumber().ToString());
        }
    }
}