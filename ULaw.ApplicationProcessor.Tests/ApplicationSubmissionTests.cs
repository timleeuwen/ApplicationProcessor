using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ulaw.ApplicationProcessor.Enums;
using Ulaw.ApplicationProcessor.Managers;
using Ulaw.ApplicationProcessor.Models;

namespace ULaw.ApplicationProcessor.Tests
{
    [TestClass]
    public class ApplicationSubmissionTests
    {
        private const string OfferEmailForFirstLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law degree at grade: 1st.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForTwoOneLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law degree at grade: 2:1.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForFirstLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law and Business degree at grade: 1st.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForTwoOneLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law and Business degree at grade: 2:1.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";

        private const string FurtherInfoEmailResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application for our course reference: ABC123 starting on 22 September 2019, we are writing to inform you that we are currently assessing your information and will be in touch shortly.<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string RejectionEmailForAnyThirdDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";

        // TODO Mock these / Use interface ??
        static readonly ApplicationManager ApplicationManager = new ApplicationManager();
        private Application application;
        
        [TestInitialize]
        public void TestInit()
        {
            application = new Application(ApplicationManager);
        }
        
        [TestMethod]
        public void ApplicationSubmissionWithFirstLawDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.First,
                DegreeSubject = DegreeSubjectEnum.Law
            };

            // Act
            string emailHtml = application.Process(applicationModel);
            
            // Assert
            Assert.AreEqual(emailHtml, OfferEmailForFirstLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawAndBusinessDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.First,
                DegreeSubject = DegreeSubjectEnum.LawAndBusiness
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, OfferEmailForFirstLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstEnglishDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.First,
                DegreeSubject = DegreeSubjectEnum.English
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.TwoOne,
                DegreeSubject = DegreeSubjectEnum.Law
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneMathsDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.TwoOne,
                DegreeSubject = DegreeSubjectEnum.Maths
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawAndBusinessDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.TwoOne,
                DegreeSubject = DegreeSubjectEnum.LawAndBusiness
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoEnglishDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.TwoTwo,
                DegreeSubject = DegreeSubjectEnum.English
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoLawDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.TwoTwo,
                DegreeSubject = DegreeSubjectEnum.Law
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithThirdDegree()
        {
            // Arrange
            var applicationModel = new ApplicationModel
            {
                ApplicationId = Guid.NewGuid(),
                Faculty = "Law",
                CourseCode = "ABC123",
                StartDate = new DateTime(2019, 9, 22),
                Title = "Mr",
                FirstName = "Test",
                LastName = "Tester",
                DateOfBirth = new DateTime(1991, 08, 14),
                RequiresVisa = false,
                DegreeGrade = DegreeGradeEnum.Third,
                DegreeSubject = DegreeSubjectEnum.Maths
            };

            // Act
            string emailHtml = application.Process(applicationModel);

            // Assert
            Assert.AreEqual(emailHtml, RejectionEmailForAnyThirdDegreeResult);
        }
    }

}