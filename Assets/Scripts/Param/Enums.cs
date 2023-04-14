namespace MyTanks2D
{
    public enum SideType : byte
    {
        Player,
        Enemy
    }

    public enum DirectionType : int
    {
        Right,
        Left,
        Up,
        Down
    }

    [System.Serializable]
    public enum TutorialEvent
    {
        Update,
        GameStart,
        PlayerMovement,
        PlayerFire,
        PlayerKillEnemy
    }

    [System.Serializable]
    public enum TutorialAction
    {
        ShowText,
        HintOnUI,
        HintOnGameObject,
        Clear,
        Wait
    }
}
