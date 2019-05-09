using System;
using System.Collections.Generic;
using System.Text;

namespace _18Ghosts
{
    /// <summary>
    /// Portal class
    /// </summary>
    class Portal
    {
        /** \brief Variables*/
        // ╿ "\u257F", ╽" 2\u257D ", ╼ "\u257C", ╾ "\u257E " 
        public readonly string[] portal = { " \u257F", " \u257D ", "\u257C", "\u257E " };
        /** \brief Properties */ 
        public ConsoleColor Color { get; private set; }
        public Rotation MyRotation { get; set; }

        /// <summary>
        /// Constructor for Portal
        /// </summary>
        /// <param name="myRotation">Start rotation</param>
        /// <param name="color">Start color</param>
        public Portal(Rotation myRotation, ConsoleColor color)
        {
            MyRotation = myRotation;
            Color = color;
        }

        /// <summary>
        /// Method to rotate the portal
        /// </summary>
        public void Rotate()
        {
            //brief switch cicle
            switch (MyRotation)
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
