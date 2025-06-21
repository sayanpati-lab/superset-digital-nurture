using System;

namespace CommandPatternExample
{
    // Step 2: Command Interface
    public interface ICommand
    {
        void Execute();
    }

    // Step 5: Receiver Class
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is OFF");
        }
    }

    // Step 3: Concrete Command - Turn Light On
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    // Step 3: Concrete Command - Turn Light Off
    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }

    // Step 4: Invoker Class
    public class RemoteControl
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            if (_command != null)
            {
                _command.Execute();
            }
            else
            {
                Console.WriteLine("No command set!");
            }
        }
    }

    // Step 6: Test Class
    class Program
    {
        static void Main(string[] args)
        {
            // Receiver
            Light livingRoomLight = new Light();

            // Commands
            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            // Invoker
            RemoteControl remote = new RemoteControl();

            Console.WriteLine("== Turning the light ON ==");
            remote.SetCommand(lightOn);
            remote.PressButton();

            Console.WriteLine("\n== Turning the light OFF ==");
            remote.SetCommand(lightOff);
            remote.PressButton();

            Console.ReadKey();
        }
    }
}
