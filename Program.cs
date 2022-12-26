using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using VectorGraphicsEditor.Controller;

namespace VectorGraphicsEditor
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IModel model = new Model.Model();
            IController controller = new Controller.Controller(model);
            Form1 mainForm = new Form1();
            mainForm.controller = controller;
            model.SetGrPort(mainForm.g, 1, 1);
            Application.Run(mainForm);
        }
    }
}
