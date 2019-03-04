using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesManager : MonoBehaviour {
    public Animator GatesAnimator;

    public void OpenGates() {
        triggerGates(true);
    }

    public void CloseGates() {
        triggerGates(false);
    }

    private void triggerGates(bool open) {
        GatesAnimator.SetBool("IsOpen", open);
    }
}