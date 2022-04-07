using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintView : MonoBehaviour
{
    [SerializeField] Button hintEnabledIcon;
    [SerializeField] Sprite hintDisabledIcon;

    static bool hint;
    [SerializeField] GameObject PlayerView;
    [SerializeField] GameObject HintsView;

    [SerializeField] float hintAllowed;

    // Start is called before the first frame update
    void Start()
    {
        hint = true;
    }

    public void changeImage()
    {
        hintEnabledIcon.image.sprite = hintDisabledIcon;

        toggleView();
    }

    void toggleView()
    {
        if (hint)
        {
            PlayerView.SetActive(false);
            if(HintsView.activeSelf)
            HintsView.SetActive(true);
            hint = false;
            Invoke("disableHint", 10);
        }
    }

    void disableHint()
    {
        HintsView.SetActive(false);
        PlayerView.SetActive(true);

    }
}
