using ESAPIX.Common;
using ESAPIX.Common.Args;
using ESAPIX.Extensions;
using System;
using System.Collections.Generic;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using V = VMS.TPS.Common.Model.API;
//[assembly: V.ESAPIScript(IsWriteable = true)]

namespace ESAPIScriptTemplate
{
    class Program
    {
        static ConsoleUI _ui = new ConsoleUI();
        static bool _requestExit = false;

        [STAThread]
        static void Main(string[] args)
        {
            _ui.WriteSectionHeader("My ESAPI Script");
            var context = new StandAloneContext(Application.CreateApplication());
            if (args != null) { ArgContextSetter.Set(context, args); }
            _ui.GetPatient(context);

            //Optional enable write
            //context.Patient.BeginModifications();
            //Optional - manual set focus
            //var course = _ui.GetCourse(context);
            //var ss = _ui.GetStructureSet(context);

            while (!_requestExit)
            {
                var options = new Dictionary<string, Action>()
                {
                   {"Option 1", ()=>Option1(context)},
                   {"Option 2", ()=>Option2(context)},
                   {"Option 3", ()=>Option3(context)},
                   {"Exit", ()=> _requestExit = true },
                };

                _ui.GetResponseAndDoAction(options);
            }

            context.Application.Dispose();
            Console.Read();
        }

        public static void Option1(StandAloneContext context) { }
        public static void Option2(StandAloneContext context) { }
        public static void Option3(StandAloneContext context) { }
    }
}
