using Ulaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Managers
{
    public interface IApplicationManager
    {
        /// <summary>
        /// Get the default email text based on application result
        /// </summary>
        /// <param name="applicationModel">the application Model</param>
        /// <returns>The response email to the application in HTML</returns>
        string GetApplicationResponseEmailasHtml(ApplicationModel applicationModel);
    }
}
