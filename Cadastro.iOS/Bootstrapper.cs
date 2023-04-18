using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace Cadastro.iOS
{
    internal class Bootstrapper : Cadastro.Bootstrapper
    {

        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}