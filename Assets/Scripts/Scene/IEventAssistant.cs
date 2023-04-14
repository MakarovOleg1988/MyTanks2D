using System;

namespace MyTanks2D
{
    public interface IEventAssistant
    {
        public static event Action _onSetButton;
        public static event Action _onSetInputText;

        public static void SendSetButton()
        {
            _onSetButton?.Invoke();
        }

        public static void SendSetInputText()
        {
            _onSetInputText?.Invoke();
        }
    }
}
