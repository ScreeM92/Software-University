namespace Battlefield.Interfaces
{
    using System.Text;

    /// <summary>
    /// An abstraction for a Renderer which is responsible for showing messages on the output
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Gets the text to show on the output
        /// </summary>
        StringBuilder Output { get; }

        /// <summary>
        /// Shows a single message on the output
        /// </summary>
        /// <param name="message">The message to be shown</param>
        void RenderMessage(string message);

        /// <summary>
        /// Shows the text held in the Output and clears it.
        /// </summary>
        void RenderOutput();
    }
}
