using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TraidingCompanyWPF.Commands;
using TraidingCompanyWPF;
using System.Windows.Controls;
using System.Windows;
using TraidingCompanyWPF.Models;
using BusinessLogic.Interfaces;

namespace TraidingCompanyWPF.ViewModels
{
   public  class LoginViewModel : INotifyPropertyChanged
    {
        private RelayCommand _LoginButtonCommand;
        public RelayCommand LoginButtonCommand
        {
            get { return _LoginButtonCommand; }
            private set { _LoginButtonCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private string _username;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private readonly IAuthManager _security;
        private readonly IUserInfoManager _userInfoManager;
        private ApplicationUser _user;
        public LoginViewModel(IAuthManager security,IUserInfoManager userInfoManager, ApplicationUser user)
        {
            this._security = security;
            this._user = user;
            this._userInfoManager = userInfoManager;
            _LoginButtonCommand = new RelayCommand(Login,p => true);
            CloseCommand = new RelayCommand(CloseWindow, p => true);
            ExitCommand = new RelayCommand(Exit, p => true);

        }

        public void Login(object obj)
        {
            var pwdBox = obj as PasswordBox;

            if (_security.Login(Username, pwdBox.Password))
            {
                _user.Username = Username;
                _user.UserId = this._userInfoManager.GetUserInfoByLogin(_user.Username).UserID;
                CloseCommand.Execute(CloseHandlerOk);
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
        public void Exit(object obj = null)
        {
            CloseCommand.Execute(CloseHandlerCancel);
        }

        public void CloseWindow(object obj)
        {
            var handler = obj as EventHandler;
            if (handler != null) handler.Invoke(this, EventArgs.Empty);
        }
        public EventHandler CloseHandlerOk;
        public EventHandler CloseHandlerCancel;

        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }


    }
}
