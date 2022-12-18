using ConsoleView.Game;
using Controller.Game;
using Model.Enums;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;

namespace ConsoleController.Game
{
    public class ConsoleEndGameController : EndGameController
    {

        private const int A_LETTER_CODE = 44;
        private const int Z_LETTER_CODE = 69;

        private static ConsoleEndGameController _instance;

        private ViewEndGame _viewEndGame = null;

        protected bool IsExit { get; set; }


        private ConsoleEndGameController() : base()
        {
            End = new Model.Game.EndGameScreen();
            _viewEndGame = new ConsoleViewEndGame(End);
            foreach (ControlItem elItem in End.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        public static ConsoleEndGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleEndGameController();
            }
            return _instance;
        }

        public override void Start()
        {
            IsExit = false;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        End.SaveRecord();
                        End.SelectFocusedItem();
                        break;
                    case ConsoleKey.Backspace:
                        End.RemoveLastSymbol();
                        break;
                    case ConsoleKey key when (int)key >= A_LETTER_CODE && (int)key <= Z_LETTER_CODE:
                        End.AddSymbol((int)key + 'A' - A_LETTER_CODE);
                        break;
                }
            } while (!IsExit);
        }

        public override void Stop()
        {
            IsExit = true;
        }
    }
}
