using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    public Image image;
    public Damageable damageable;

    private float initWidth;

    void LateUpdate() {
        image.fillAmount = Mathf.Lerp(image.fillAmount, damageable.GetHealthPercentage(), 0.1f);
    }
}