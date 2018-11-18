using Redbet.Domain.Core.Events;
using Redbet.Domain.Models.Customer.Commands;
using System;

namespace Console.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new FakeBus();            

            // Add
            var addCommand = new AddCustomerCommand("Renan", "Pinto", "Av. Wilson Tavares", "Atletico");
            Start(addCommand);
            bus.SendCommand(addCommand);
            Finish(addCommand);

            // Add with errors
            addCommand = new AddCustomerCommand("", "", "", "");
            Start(addCommand);
            bus.SendCommand(addCommand);
            Finish(addCommand);

            // Update
            var updateCommand = new UpdateCustomerCommand(Guid.NewGuid(), "Renan", "Cosme", "Nossa senhora do O", "Atletico");
            Start(updateCommand);
            bus.SendCommand(updateCommand);
            Finish(updateCommand);

            // Delete
            var deleteCommand = new AddCustomerCommand("Renan", "Pinto", "Av. Wilson Tavares", "Atletico");
            Start(deleteCommand);
            bus.SendCommand(deleteCommand);
            Finish(deleteCommand);
            System.Console.ReadKey();
        }

        private static void Start(Message message)
        {
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("Command started " + message.MessageType);
        }

        private static void Finish(Message message)
        {
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("Command finished " + message.MessageType);
            System.Console.WriteLine("");
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("***********************");
            System.Console.WriteLine("");
        }
    }
}
