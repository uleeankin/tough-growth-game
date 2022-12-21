using Controller.Game;
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
    /// <summary>
    /// Контроллер окна окончания игры (wpf)
    /// </summary>
    public class WpfEndGameController : EndGameController
    {
        /// <summary>
        /// Код буквы A
        /// </summary>
        private const int A_LETTER_CODE = 44;
        /// <summary>
        /// Код буквы Z
        /// </summary>
        private const int Z_LETTER_CODE = 69;

        /// <summary>
        /// Сущность контроллера окна окончания игры
        /// </summary>
        private static WpfEndGameController _instance;

        /// <summary>
        /// Представление окна окончания игры
        /// </summary>
        private ViewEndGame _viewEndGame = null;

        /// <summary>
        /// Общее wpf окно для всех окон
        /// </summary>
        private MainScreen _screen = null;

        /// <summary>
        /// Конструктор контроллера окончания игры
        /// </summary>
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

        /// <summary>
        /// Получает сущность контроллера окончания игры
        /// </summary>
        /// <returns>Контроллер окончания игры</returns>
        public static WpfEndGameController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfEndGameController();
            }
            return _instance;
        }

        /// <summary>
        /// Обработчик события нажатия на клавиши клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    End.SaveRecord();
                    End.SelectFocusedItem();
                    break;
                case Key.Back:
                    End.RemoveLastSymbol();
                    break;
                case Key key when (int)key >= A_LETTER_CODE && (int)key <= Z_LETTER_CODE:
                    End.AddSymbol((int)key + 'A' - A_LETTER_CODE);
                    break;
            }
        }

        /// <summary>
        /// Запускает работу MVC окончания игры
        /// </summary>
        public override void Start()
        {
            _viewEndGame.Draw();
            _screen.KeyDown += OnKeyDownHandler;
        }

        /// <summary>
        /// Останавливает работу MVC окончания игры
        /// </summary>
        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
