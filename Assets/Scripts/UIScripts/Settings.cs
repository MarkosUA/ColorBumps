using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace UIScripts
{
    public class Settings : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer _audioMixer;

        public void Volume(float sliderValue)
        {
            _audioMixer.SetFloat("masterVolume", sliderValue);
        }
    }
}