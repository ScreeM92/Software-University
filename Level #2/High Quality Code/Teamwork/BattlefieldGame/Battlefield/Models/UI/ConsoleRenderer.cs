namespace Battlefield.Models.UI
{
    using System;
    using System.Text;
    using Interfaces;

    /// <summary>
    /// A class for rendering messages on the console
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        // TODO Make this handler return strings and leave the parsing and checking to the engine

        /// <summary>
        /// Initializes a new instance of the ConsoleRenderer class
        /// </summary>
        public ConsoleRenderer()
        {
            this.Output = new StringBuilder();
        }

        /// <summary>
        /// Gets text to show on the console
        /// </summary>
        public StringBuilder Output { get; private set; }

        /// <summary>
        /// Prints a single message on the console
        /// </summary>
        /// <param name="message">The message to be shown</param>
        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Flushes the output on the console
        /// </summary>
        public void RenderOutput()
        {
            Console.WriteLine(this.Output);
            this.Output.Clear();
        }
    }
}
