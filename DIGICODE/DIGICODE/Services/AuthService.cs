using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DIGICODE.Services
{
    class AuthService
    {
        private static AuthService inst;

        public string login { get; set; }
        public string mdp { get; set; }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static AuthService getInstance()
        {
            if (inst == null)
            {
                inst = new AuthService();
            }
            return inst;
        }
    }
}
