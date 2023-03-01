using System;

namespace MyTanks2D
{
    public interface IEventAssistant
    {
        public static event Action _onSetButton;

        public static void SendSetButton()
        {
            _onSetButton?.Invoke();
        }
    }
}
