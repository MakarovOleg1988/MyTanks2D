using System;
using UnityEngine;


namespace MyTanks2D
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _SoundClickButton;

        private void Start()
        {
            IEventAssistant._onSetButton += SetButtonSound;
        }

        private void SetButtonSound()
        {
            _SoundClickButton.Play();
        }
    }
        
}