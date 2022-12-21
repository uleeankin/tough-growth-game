using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    /// <summary>
    /// Виды разделов приложения
    /// </summary>
    public enum ControlItemCode : int
    {
        /// <summary>
        /// Игра
        /// </summary>
        Game,
        /// <summary>
        /// Рекорды
        /// </summary>
        Records,
        /// <summary>
        /// Справка
        /// </summary>
        Info,
        /// <summary>
        /// Выход
        /// </summary>
        Exit,
        /// <summary>
        /// Главное меню
        /// </summary>
        MainMenu,
        /// <summary>
        /// Конец игры
        /// </summary>
        EndGame
    }
}
