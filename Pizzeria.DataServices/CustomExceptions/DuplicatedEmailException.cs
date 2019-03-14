using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.DataServices.CustomExceptions
{
    public class DuplicatedEmailException : Exception
    {
        public DuplicatedEmailException(string emailAddress)
            : base($"Email address: /{emailAddress}/ already exists ! ")
        {
            {

            }
        }
    }
}
