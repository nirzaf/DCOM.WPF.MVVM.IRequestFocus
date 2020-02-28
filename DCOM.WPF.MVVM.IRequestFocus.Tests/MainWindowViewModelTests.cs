namespace DCOM.WPF.MVVM.IRequestFocus.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Security.Authentication;
    using Moq;

    [TestClass]
    public class MainViewModelTests
    {
        private Mock<ILoginService> mock;
        private MainWindowViewModel viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<ILoginService>();
            viewModel = new MainWindowViewModel(mock.Object);
        }

        [TestMethod]
        public void LoginCommand_RequestsPasswordFocusWhenExceptionIsThrown()
        {
            mock.Setup(p => p.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<AuthenticationException>();

            bool raised = false;
            string propertyName = null;

            viewModel.FocusRequested += (sender, e) =>
            {
                raised = true;
                propertyName = e.PropertyName;
            };

            viewModel.LoginCommand.Execute(null);

            Assert.IsTrue(raised);
            Assert.AreEqual(nameof(viewModel.Password), propertyName);
        }
    }
}