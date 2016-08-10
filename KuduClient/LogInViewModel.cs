using System;
using System.Windows.Input;

namespace KuduClient
{
    public class LogInViewModel : ObservableObject
    {
        private string _baseUrl;
        public string BaseUrl {
            get { return _baseUrl; }
            set { SetAndRaise(ref _baseUrl, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetAndRaise(ref _username, value); }
        }

        private ISecurePasswordProvider _passwordProvider = new MockPasswordProvider();
        public ISecurePasswordProvider PasswordProvider
        {
            get { return _passwordProvider; }
            set { SetAndRaise(ref _passwordProvider, value); }
        }

        public ICommand OK
        {
            get
            {
                return new ActionCommand(p =>
                {
                    var vm = this;
                    var stop = "here";
                });
            }
        }


        private class MockPasswordProvider : ISecurePasswordProvider
        {
            public string GetPassword()
            {
                throw new NotImplementedException();
            }
        }
    }

    public interface ISecurePasswordProvider
    {
        string GetPassword();
    }
}
