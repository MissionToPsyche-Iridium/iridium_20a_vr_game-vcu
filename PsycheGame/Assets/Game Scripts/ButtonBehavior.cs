using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {
    private CanvasGroup canvasGroup;
    private Button button;

    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        StartCoroutine(FlashButton());
    }

    IEnumerator FlashButton() {
        while(canvasGroup.alpha > 0) {
            float time = 0f;
            while(time < 1f) {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, time);
                yield return null;
            }
            time = 0f;
            while(time < 1f) {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, time);
                yield return null;
            }
        }
    }

    void OnButtonClick() {
        StopCoroutine(FlashButton());
        canvasGroup.alpha = 1f;
    }
}
