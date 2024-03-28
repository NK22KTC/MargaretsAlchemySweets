using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : GameSystems
{
    [SerializeField] private GameObject fadeImageObject;

    [SerializeField] private Text scoreText, moneyText;

    Image fadeImage;

    public bool changeScene = false;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = fadeImageObject.GetComponent<Image>();

        DisplayScoreMoneyText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(changeScene)
        {
            GameManager.instance.Init();
            FadeOut(fadeImageObject, fadeImage);
            if (fadeImage.color.a >= 1)
            {
                LoadingScene();
            }
        }
    }

    void DisplayScoreMoneyText()
    {
        scoreText.text += GameManager.instance.score;
        moneyText.text += GameManager.instance.haveMoney;
    }
}
