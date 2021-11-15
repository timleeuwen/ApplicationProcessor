using System.Text;
using ULaw.ApplicationProcessor;
using Ulaw.ApplicationProcessor.Enums;
using Ulaw.ApplicationProcessor.Models;

namespace Ulaw.ApplicationProcessor.Managers
{
    public class ApplicationManager : IApplicationManager
    {
        // TODO Create Application Setting to make it easier to change the value when the deposit amount changes
        private const string depositAmount = "350.00";

        // TODO Create Application Setting to make it easier to change the receiving email address
        private const string admissionsTeamEmail = "AdmissionsTeam@Ulaw.co.uk";

        /// <inheritdoc />
        public string GetApplicationResponseEmailasHtml(ApplicationModel applicationModel)
        {
            if (applicationModel == null) return string.Empty;

            var result = new StringBuilder();

            result.Append("<html><body><h1>Your Recent Application from the University of Law</h1>");
            result.Append($"<p> Dear {applicationModel.FirstName}, </p>");

            switch (applicationModel.DegreeGrade)
            {
                case DegreeGradeEnum.TwoTwo:
                    
                    result.Append($"<p/> Further to your recent application for our course reference: {applicationModel.CourseCode} starting on {applicationModel.StartDate.ToLongDateString()}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.");
                    // TODO Make email address a Link in html
                    result.Append($"<br/> If you wish to discuss any aspect of your application, please contact us at {admissionsTeamEmail}.");
                    
                    break;
                case DegreeGradeEnum.Third:
                    
                    result.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
                    result.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");
                    
                    break;
                default:
                    {
                        if (applicationModel.DegreeSubject == DegreeSubjectEnum.Law || applicationModel.DegreeSubject == DegreeSubjectEnum.LawAndBusiness)
                        {
                            result.Append($"<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {applicationModel.CourseCode} starting on {applicationModel.StartDate.ToLongDateString()}.");
                            result.Append($"<br/> This offer will be subject to evidence of your qualifying {applicationModel.DegreeSubject.ToDescription()} degree at grade: {applicationModel.DegreeGrade.ToDescription()}.");
                            result.Append($"<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{depositAmount} deposit fee to secure your place.");
                            result.Append("<br/> We look forward to welcoming you to the University,");
                            
                        }
                        else
                        {
                            result.Append($"<p/> Further to your recent application for our course reference: {applicationModel.CourseCode} starting on {applicationModel.StartDate.ToLongDateString()}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.");
                            // TODO Make email address a Link in html
                            result.Append($"<br/> If you wish to discuss any aspect of your application, please contact us at {admissionsTeamEmail}.");
                        }

                        break;
                    }
            }

            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            result.Append("</body></html>");

            return result.ToString();
        }
    }
}
