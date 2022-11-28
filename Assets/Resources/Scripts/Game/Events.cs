using UnityEngine;
using Platinum.Settings;

namespace Unity.FPS.Game
{
    public enum Result
    {
        Win,
        Lose,
        None,
    }
    // The Game Events used across the Game.
    // Anytime there is a need for a new event, it should be added here.

    public static class Events
    {
        public static StartGenerationEvent StartGenerationEvent = new StartGenerationEvent();
        public static ObjectiveUpdateEvent ObjectiveUpdateEvent = new ObjectiveUpdateEvent();
        public static AllObjectivesCompletedEvent AllObjectivesCompletedEvent = new AllObjectivesCompletedEvent();
        public static EndSpawnEvent EndSpawnEvent = new EndSpawnEvent();
        public static GamePauseEvent GamePauseEvent = new GamePauseEvent();
        public static MenuPauseEvent MenuPauseEvent = new MenuPauseEvent();
        public static WaveCompletedEvent WaveCompletedEvent = new WaveCompletedEvent();
        public static AllWaveCompletedEvent AllWaveCompletedEvent = new AllWaveCompletedEvent();
        public static RefreshMatchEvent RefreshMatchEvent = new RefreshMatchEvent();
        public static PlayerDeathEvent PlayerDeathEvent = new PlayerDeathEvent();
        public static KillEvent KillEvent = new KillEvent();
        public static DieEvent DieEvent = new DieEvent();
        public static PickupEvent PickupEvent = new PickupEvent();
        public static AmmoPickupEvent AmmoPickupEvent = new AmmoPickupEvent();
        public static DisplayMessageEvent DisplayMessageEvent = new DisplayMessageEvent();
    }

    public class StartGenerationEvent : GameEvent
    {
        public int Seed;
    }

    public class ObjectiveUpdateEvent : GameEvent
    {
        public Objective Objective;
        public string DescriptionText;
        public string CounterText;
        public bool IsComplete;
        public string NotificationText;
    }

    public class AllObjectivesCompletedEvent : GameEvent { }

    public class KillEvent : GameEvent
    {
        public Actor killed;
        public Actor killer;
    }

    public class DieEvent : GameEvent
    {
        public Actor Actor;
    }

    public class EndSpawnEvent : GameEvent
    {
        public LoadManager LoadManager;
    }

    public class GamePauseEvent : GameEvent
    {
        public bool ServerPause = false;
    }

    public class MenuPauseEvent : GameEvent
    {
        public bool MenuPause = false;
    }

    public class RefreshMatchEvent : GameEvent { }

    public class AllWaveCompletedEvent : GameEvent { }

    public class WaveCompletedEvent : GameEvent
    {
        public int BossKillCount = 0;
        public int WaveLevel = 0;
        public int CountActiveEnemySpawner = 0;
    }

    public class PlayerDeathEvent : GameEvent
    {
        public bool Die;
    }

    public class PickupEvent : GameEvent
    {
        public GameObject Pickup;
    }

    public class AmmoPickupEvent : GameEvent
    {
        public WeaponController Weapon;
    }

    public class DisplayMessageEvent : GameEvent
    {
        public string Message;
        public float DelayBeforeDisplay;
    }
}
