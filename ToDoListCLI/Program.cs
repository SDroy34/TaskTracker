using System;
using ToDoListCLI.Class;
namespace ToDoListCLI
{
    class ToDoListCLI
    {
        static void Main(string[] args)
        {
            var interFace = new interfaceClass();
            interFace.RunView();
        }
    }
}