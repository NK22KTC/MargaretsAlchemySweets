using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : SingletonDontDestroy<SoundManager>
{
    [SerializeField]
    AudioSource[] sources;  //sources[0]がBGM,sources[1]がSE
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource se;

    [SerializeField]
    AudioClip[] BGM_Clips;

    [SerializeField]
    AudioClip[] SE_Clips;

    int nowLoadSceneIndex = 0;


    void Start()
    {
        nowLoadSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (!sources[0].isPlaying)
        {
            PlayBGM();
        }

        if(nowLoadSceneIndex != SceneManager.GetActiveScene().buildIndex)
        {
            ChangeBGM();
        }
    }

    void PlayBGM()  //BGMが止まったら再生する
    {
        sources[0].Play();
    }

    void ChangeBGM()
    {
        nowLoadSceneIndex = SceneManager.GetActiveScene().buildIndex;
        sources[0].clip = BGM_Clips[nowLoadSceneIndex];
    }

    public void OnButtonPush(AudioClip clip)  //効果音を鳴らす関数
    {
        se.clip = clip;
        se.Play();
    }

    public void PlaySE(int seNum) => OnButtonPush(SE_Clips[seNum]);

    public void ChangeBGMVol(float f) => bgm.volume = f;
    public void ChangeSEVol(float f) => se.volume = f;
}
