﻿namespace Map
{
    public enum DirectionState
    {
        Forward,
        Right,
        Backward,
        Left,
    }
}

namespace Bot
{
    public enum HealthState
    {
        Non,
        Alive,
        Dead
    }
    public enum ThinkState
    {
        Non,
        Attack,
        Move,
        CantMove,
        CollisionPredict
    }

    public enum MoveState
    {
        Step,
        Warp,
        Attack,
    }
}

namespace Player
{

}

namespace Game
{
    public enum GameModeState
    {
        Non,
        Tutorial,
        Local,
        Multi
    }

    public enum GameState
    {
        Non,
        Initialize,
        DecidedTheOrder,
        Battle,
        GameSet,
        Finalize,
    }

    public enum BattleState
    {
        Non,
        Initialize,
        Place,
        TurnEnd,
        AIAction,
        Finalize,
        GameSet,
    }
}