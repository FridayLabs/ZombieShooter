using UnityEngine;

public class PainNarrator : MonoBehaviour {
    public float painScore;

    private CanvasGroup canvasGroup;

    private void Start() {
        canvasGroup = GameManager.Instance.DamageUI.GetComponent<CanvasGroup>();
    }

    public void ShowPain() {
        painScore = 1f;
    }

    public void Update() {
        painScore = Mathf.Lerp(painScore, 0f, 1.5f * Time.deltaTime);
        canvasGroup.alpha = painScore;
    }
}