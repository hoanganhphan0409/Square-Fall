using System;
public static class Observer
{
    public static Action UpdateScore;
    public static Action LoseGame;
    public static Action ReplayGame;
    public static Action StartGame;
    public static Action<ESound> PlaySound;

}
