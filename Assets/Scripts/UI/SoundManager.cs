using System;
using UnityEngine;


namespace MyTanks2D
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _SoundClickButton;
        [SerializeField] private AudioSource _SoundInputText;

        private void Start()
        {
            IEventAssistant._onSetButton += SetButtonSound;
            IEventAssistant._onSetInputText += SetInputTextSound;
        }

        private void SetButtonSound()
        {
            _SoundClickButton.Play();
        }

        private void SetInputTextSound()
        {
            _SoundInputText.Play();
        }
    } 
}