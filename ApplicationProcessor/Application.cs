using Ulaw.ApplicationProcessor.Managers;
using Ulaw.ApplicationProcessor.Models;

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        private readonly IApplicationManager _applicationManager;
        
        public Application(IApplicationManager applicationManager)
        {
            _applicationManager = applicationManager;
        }
        
        public string Process(ApplicationModel model)
        {
            return _applicationManager.GetApplicationResponseEmailasHtml(model);
        }
    }
}

