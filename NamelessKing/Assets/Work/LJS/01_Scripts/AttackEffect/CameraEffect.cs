using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraEffect : MonoSingleton<CameraEffect>
{
    private bool isActionEnd;
    public bool IsActionEnd
    {
        get => isActionEnd;
        set => isActionEnd = value;
    }

    public IEnumerator CameraShake(CinemachineBasicMultiChannelPerlin perlin, float amplitude, float time, float frequencyGain)
    {
        float currentTime = 0f;
        float value = 0f;
        perlin.m_FrequencyGain = frequencyGain;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            value = 1 - (currentTime / time);
            
            perlin.m_AmplitudeGain = amplitude * value;
            Debug.Log(perlin.m_AmplitudeGain);

            yield return null;
        }

        perlin.m_FrequencyGain = 0;
        perlin.m_AmplitudeGain = 0;

        IsActionEnd = true;
    }

    public IEnumerator TimeSlowEffect(float time, float slowTime){
        float originScale = Time.timeScale;
        Time.timeScale = slowTime;
        yield return new WaitForSeconds(time);
        Time.timeScale = originScale;
    }
}
