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

    }
}
