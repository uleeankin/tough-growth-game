using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Базовое представление
    /// </summary>
    public abstract class View
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public View()
        {
    
        }

        /// <summary>
        /// Базовый метод рисования окна
        /// </summary>
        public abstract void Draw();
    }
}
