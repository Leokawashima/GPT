﻿using UnityEngine;
using UnityEngine.UI;

namespace GameMode
{
    public class GameModeManager : SingletonMonoBehaviour<GameModeManager>
    {
        [SerializeField] private ModeChoiceManager m_modeChoice;
        [SerializeField] private InfoScrollViewManager m_infoScrollView;
        [SerializeField] private GameSettingManager m_gameSetting;
        [SerializeField] private PlayerSettingManager m_playerSetting;
        [SerializeField] private BotSettingManager m_botSetting;

        [SerializeField] private Canvas m_canvas;

        [SerializeField] private Button m_gameStartButton;

        public void Enable() => m_canvas.enabled = true;
        public void Disable() => m_canvas.enabled = false;
        private void Start() => Initialize();

        private void Initialize()
        {
            m_modeChoice.Initialize();
            m_infoScrollView.Initialize();
            m_gameSetting.Initialize();
            m_playerSetting.Initialize();
            m_botSetting.Initialize();

            Disable();
            m_gameSetting.Enable();
            m_playerSetting.Disable();
            m_botSetting.Disable();
            m_gameStartButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            var _mode = ModeChoiceManager.Singleton.GameMode;
            var _turnsd = GameSettingManager.Singleton.TurnSuddonDeath;
            var _turnff = GameSettingManager.Singleton.TurnForceFinish;
            var _settings = new PlayerSetting[InfoScrollViewManager.Singleton.Infos.Count];
            for (int i = 0; i < _settings.Length; ++i)
            {
                _settings[i] = InfoScrollViewManager.Singleton.Infos[i].Data;
            }

            Initialize(_mode, _turnsd, _turnff, _settings);
            Initiate.Fade(Name.Scene.Game, Name.Scene.GameMode, Color.black, 1.0f);
        }

        public static void Initialize(GameMode mode_, int turnSD_, int turnFF_, PlayerSetting[] settings_)
        {
            CurrentGameMode = mode_;
            TurnSuddonDeath = turnSD_;
            TurnForceFinish = turnFF_;
            PlayerSettings = settings_;
        }

        public static void Clear()
        {
            CurrentGameMode = GameMode.Non;
            TurnSuddonDeath = 0;
            TurnForceFinish = 0;
            PlayerSettings = null;
        }

        public enum GameMode
        {
            Non,
            Tutorial,
            Local,
            Multi,
        }
        public static GameMode CurrentGameMode { get; private set; } = GameMode.Non;
        public static int TurnSuddonDeath { get; private set; } = 0;
        public static int TurnForceFinish { get; private set; } = 0;
        public static PlayerSetting[] PlayerSettings { get; private set; }
    }
}