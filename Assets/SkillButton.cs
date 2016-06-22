using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {
    public float coldTime = 2;
    private float timer = 0;
    private Image filledImage;
    private bool isStartTimer = false;
    // Use this for initialization

    void Start()
    {
        filledImage = transform.Find("FilledImage").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        if (isStartTimer)
        {
            timer += Time.deltaTime;
            filledImage.fillAmount = timer / coldTime;
            if (timer >= coldTime)
            {
                filledImage.fillAmount = 1;
                timer = 0;
                isStartTimer = false;
            }
        }
    }
    public void OnClick()
    {
        isStartTimer = true;
    }
}
