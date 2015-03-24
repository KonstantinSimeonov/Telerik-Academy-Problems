using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class NotIncreasingException : Exception
    {
        private string message;

        public NotIncreasingException()
        {
            message = "The given number doesn't continue the increasing sequence.";
        }

        public override string Message
        {
            get
            {
                return message;
            }
        }
    }

