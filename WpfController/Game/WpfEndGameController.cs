﻿using Controller.Game;
using Model.Enums;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Game;
using WpfView;

namespace WpfController.Game
{
    public class WpfEndGameController : EndGameController
    {

        private const int A_LETTER_CODE = 65;
        private const int Z_LETTER_CODE = 90;

        private static WpfEndGameController _instance;

        private ViewEndGame _viewEndGame = null;
        private MainScreen _screen = null;

        private WpfEndGameController() : base()
        {
            _screen = MainScreen.GetInstance();
            End = new Model.Game.EndGameScreen();
            _viewEndGame = new WpfView.Game.WpfViewEndGame(End);
            foreach (ControlItem elItem in End.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        public static WpfEndGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfEndGameController();
            }
            return _instance;
        }

        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    End.SelectFocusedItem();
                    break;
                case Key.Back:
                    End.RemoveLastSymbol();
                    break;
                case Key key when (int)key >= A_LETTER_CODE && (int)key <= Z_LETTER_CODE:
                    End.AddSymbol((int)key);
                    break;
            }
        }

        public override void Start()
        {
            _viewEndGame.Draw();
            _screen.KeyDown += OnKeyDownHandler;
            
        }

        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
