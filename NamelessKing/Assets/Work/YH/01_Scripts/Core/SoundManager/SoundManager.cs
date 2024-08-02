using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoSingleton<SoundManager>
{
    

    [Header("Music")]
    [SerializeField] private AudioSource _titleMusic;
    [SerializeField] private float _fadeTimerInterval = 0.001f;
    private bool _titleMusicPlaying = false;
    private bool _gameMusicPlaying = false;

    [Header("Impact")]
    [SerializeField] private AudioSource _attackImpactSource;
    [SerializeField] private AudioSource _archerAttackSource;
    [SerializeField] private AudioSource _hitImpactSource;
    [SerializeField] private AudioSource _magicImpactSource;
    [SerializeField] private AudioSource _jumpSource;
    [SerializeField] private AudioSource _fireBallSource;
    [SerializeField] private AudioSource _stringAttackSource;
    [SerializeField] private AudioSource _biteAttackSource;
    [SerializeField] private AudioSource _textSource;

    public override void Awake()
    {
        base.Awake();
        _magicImpactSource.Stop();
        _jumpSource.Stop();
        _attackImpactSource.Stop();
        _hitImpactSource.Stop();
        _archerAttackSource.Stop();
        _textSource.Stop();
    }
    //����� �ҽ� ���

    public void StopSound(){
        _attackImpactSource.Stop();
        _archerAttackSource.Stop();
        _hitImpactSource.Stop();
        _magicImpactSource.Stop();
        _jumpSource.Stop();
        _fireBallSource.Stop();
        _stringAttackSource.Stop();
        _biteAttackSource.Stop();
        _textSource.Stop();
    }

    public void StartTitleMusic()
    {
        _titleMusic.Play();
        _titleMusic.volume = 0.5f;
        _gameMusicPlaying = false;
        _titleMusicPlaying = true;
    }

    public void StartHitImpactSource()
    {
        _hitImpactSource.Play();
    }

    public void StartFireBallSoruce()
    {
        _fireBallSource.Play();
    }

    public void StartBiteAttackSoruce()
    {
        _biteAttackSource.Play();
    }

    public void StartStingSoruce()
    {
        _stringAttackSource.Play();
    }

    public void StartAttackImpactSoruce()
    {
        _attackImpactSource.Play();
    }

    public void StartArherAttackSoruce()
    {
        _archerAttackSource.Play();
    }

    public void StartJumpSoruce()
    {
        _jumpSource.Play();
    }
    public void StartMagicImpactSoruce()
    {
        _magicImpactSource.Play();
    }
    public void StartTextSoruce()
    {
        _textSource.Play();
    }

    public void StartFadeTitleOut(AudioSource music)
    {
        StartCoroutine(FadeTitleMusic(true,music));
    }

    public void StartFadeMusicIn(AudioSource music)
    {
        StartCoroutine(FadeTitleMusic(false,music));
    }

    private IEnumerator FadeTitleMusic(bool fadeOut, AudioSource music)
    {
        if (fadeOut)
        {
            while (music.volume > 0)
            {
                music.volume -= 0.001f;
                yield return new WaitForSeconds(_fadeTimerInterval);
            }
        }
        else if (!fadeOut)
        {
            while (music.volume < 0.5f)
            {
                music.volume += 0.001f;
                yield return new WaitForSeconds(_fadeTimerInterval);
            }
        }
    }
    //---------------------------------------------------------------------------------

    //���� ����
    [Header("AudioMixer")]
    [SerializeField] private AudioMixer _soundMixer;

    private void Start()
    {
        StartTitleMusic();
    }

    public void SetTotalValue(float volume)
    {
        _soundMixer.SetFloat("Total", volume);
        PlayerPrefs.SetFloat("TotalVolume", volume);
    }
    public void SetMusicValue(float volume)
    {
        _soundMixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetEffectValue(float volume)
    {
        _soundMixer.SetFloat("Effect", volume);
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }

    
}



