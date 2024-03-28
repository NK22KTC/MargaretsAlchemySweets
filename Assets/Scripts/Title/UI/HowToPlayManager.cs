using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayManager : MonoBehaviour
{
    [SerializeField] private Button returtnButton;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        returtnButton.onClick.AddListener(() =>  //戻るボタンに処理追加
        {
            SoundManager.instance.PlaySE(7);
        });
    }
}
