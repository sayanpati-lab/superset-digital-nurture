using System;

namespace BuilderPatternExample
{
    // Step 2: Define the Product class
    public class Computer
    {
        // Attributes
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }
        public string GraphicsCard { get; private set; }

        // Step 4: Private constructor, only accessible through Builder
        private Computer(Builder builder)
        {
            CPU = builder.CPU;
            RAM = builder.RAM;
            Storage = builder.Storage;
            GraphicsCard = builder.GraphicsCard;
        }

        // Display method
        public void ShowConfiguration()
        {
            Console.WriteLine("Computer Configuration:");
            Console.WriteLine($"CPU: {CPU}");
            Console.WriteLine($"RAM: {RAM}");
            Console.WriteLine($"Storage: {Storage}");
            Console.WriteLine($"Graphics Card: {GraphicsCard}");
            Console.WriteLine();
        }

        // Step 3: Static nested Builder class
        public class Builder
        {
            // Same attributes as Computer
            public string CPU { get; private set; }
            public string RAM { get; private set; }
            public string Storage { get; private set; }
            public string GraphicsCard { get; private set; }

            // Builder methods to set optional parts
            public Builder SetCPU(string cpu)
            {
                CPU = cpu;
                return this;
            }

            public Builder SetRAM(string ram)
            {
                RAM = ram;
                return this;
            }

            public Builder SetStorage(string storage)
            {
                Storage = storage;
                return this;
            }

            public Builder SetGraphicsCard(string graphicsCard)
            {
                GraphicsCard = graphicsCard;
                return this;
            }

            // build() method returns final Computer object
            public Computer Build()
            {
                return new Computer(this);
            }
        }
    }

    // Step 5: Test the Builder implementation
    class Program
    {
        static void Main(string[] args)
        {
            // Basic computer
            Computer basicComputer = new Computer.Builder()
                .SetCPU("Intel i3")
                .SetRAM("4GB")
                .SetStorage("256GB SSD")
                .Build();

            // Gaming computer
            Computer gamingComputer = new Computer.Builder()
                .SetCPU("AMD Ryzen 7")
                .SetRAM("16GB")
                .SetStorage("1TB SSD")
                .SetGraphicsCard("NVIDIA RTX 3080")
                .Build();

            // Office computer
            Computer officeComputer = new Computer.Builder()
                .SetCPU("Intel i5")
                .SetRAM("8GB")
                .SetStorage("512GB SSD")
                .Build();

            // Display all configurations
            basicComputer.ShowConfiguration();
            gamingComputer.ShowConfiguration();
            officeComputer.ShowConfiguration();

            Console.ReadKey();
        }
    }
}
