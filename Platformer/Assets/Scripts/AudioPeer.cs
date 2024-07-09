using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    private AudioSource _audioSource;
    public static float[] _samples = new float[512];

    // Threshold for beat detection
    public float beatThreshold = 0.029f;
    private float[] previousSamples = new float[512];

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    public bool IsBeatDetected()
    {
        float sum = 0f;
        for (int i = 0; i < _samples.Length; i++)
        {
            sum += _samples[i];
        }
        float average = sum / _samples.Length;

        float previousSum = 0f;
        for (int i = 0; i < previousSamples.Length; i++)
        {
            previousSum += previousSamples[i];
        }
        float previousAverage = previousSum / previousSamples.Length;

        bool isBeat = average > previousAverage * beatThreshold;

        // Update previous samples
        for (int i = 0; i < _samples.Length; i++)
        {
            previousSamples[i] = _samples[i];
        }

        return isBeat;
    }
}
