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
    /// <summary>
    /// Контроллер окна окончания игры (консоль)
    /// </summary>
    public class ConsoleEndGameController : EndGameController
    {
        /// <summary>
        /// Код буквы A
        /// </summary>
        private const int A_LETTER_CODE = 65;

        /// <summary>
        /// Код буквы Z
        /// </summary>
        private const int Z_LETTER_CODE = 90;

        /// <summary>
        /// Сущность контроллера окончания игры
        /// </summary>
        private static ConsoleEndGameController _instance;

        /// <summary>
        /// Представление окна окончания игры
        /// </summary>
        private ViewEndGame _viewEndGame = null;

        /// <summary>
        /// Флаг статуса работы контроллера
        /// </summary>
        protected bool IsExit { get; set; }

        /// <summary>
        /// Коструктор котроллера окончания игры
        /// </summary>
        private ConsoleEndGameController() : base()
        {
            End = new Model.Game.EndGameScreen();
            _viewEndGame = new ConsoleViewEndGame(End);
            foreach (ControlItem elItem in End.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        /// <summary>
        /// Получает сущность контроллера окна окончания игры
        /// </summary>
        /// <returns>Сущность контроллера окна окончания игры (консоль)</returns>
        public static ConsoleEndGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleEndGameController();
            }
            return _instance;
        }

        /// <summary>
        /// Запускает работу контроллера
        /// </summary>
        public override void Start()
        {
            IsExit = false;
            _viewEndGame.Draw();
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
                        End.AddSymbol((int)key);
                        break;
                }
            } while (!IsExit);
        }

        /// <summary>
        /// Останавливает работу контроллера
        /// </summary>
        public override void Stop()
        {
            IsExit = true;
        }
    }
}
