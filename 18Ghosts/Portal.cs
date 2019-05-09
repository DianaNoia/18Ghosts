using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    class Portal
    {
        // Variables
        //╿ "\u257F", ╽" 2\u257D ", ╼ "\u257C", ╾ "\u257E " 
        public readonly string[] portal = { " \u257F", " \u257D ", "\u257C", "\u257E " };
        // Properties
        public ConsoleColor Color { get; private set; }
        public Rotation MyRotation { get; set; }

        // Constructor
        public Portal(Rotation myRotation, ConsoleColor color)
        {
            MyRotation = myRotation;
            Color = color;
        }

        public void Rotate()
        {
            switch(MyRotation)
            {
                case Rotation.North:
                    MyRotation = Rotation.East;
                    break;
                case Rotation.South:
                    MyRotation = Rotation.West;
                    break;
                case Rotation.East:
                    MyRotation = Rotation.South;
                    break;
                case Rotation.West:
                    MyRotation = Rotation.North;
                    break;
            }
        }
    }
}
