using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game.GameObjects;

namespace ConsoleView.Game.GameObjects
{
    public class ConsoleViewGameObject : ViewGameObject
    {

        public ConsoleViewGameObject(GameObject parGameObject) : base(parGameObject)
        {

        }

        public override void Draw()
        { 
        
        }
            

        protected override void RedrawGameObject()
        {
            
        }
    }
}
