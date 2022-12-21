using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;
using Model.Enums;

namespace Controller
{
    /// <summary>
    /// Базовый класс для всех контроллеров
    /// </summary>
    public abstract class Controller
    {
        /// <summary>
        /// Делегат на сменю контроллера
        /// </summary>
        /// <param name="parItemCode">Код следующего контроллера</param>
        public delegate void dChangeController(ControlItemCode parItemCode);
        /// <summary>
        /// Событие на смену контроллера
        /// </summary>
        public event dChangeController ChangeController = null;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Controller()
        {
            
        }

        /// <summary>
        /// Метод, вызывающий событие смены контроллера
        /// </summary>
        /// <param name="parItemCode">Код следующего контроллера</param>
        public void SwitchController(ControlItemCode parItemCode)
        {
            ChangeController?.Invoke(parItemCode);
        }

        /// <summary>
        /// Запуск контроллера
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Остановка работы текущего контроллера
        /// </summary>
        public abstract void Stop();
    }
}
