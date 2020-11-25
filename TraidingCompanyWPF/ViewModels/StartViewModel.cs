using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraidingCompanyWPF.Commands;
using TraidingCompanyWPF.Models;
using TraidingCompanyWPF.Windows;
using Unity;

namespace TraidingCompanyWPF.ViewModels
{
    public class StartViewModel : INotifyPropertyChanged
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

        private ApplicationUser _user;
        private readonly IUserInfoManager _userInfoManager;
        public StartViewModel(ApplicationUser user,IUserInfoManager userInfoManager)
        {
            this._user = user;
            this._userInfoManager = userInfoManager;
            this._user.UserId = _userInfoManager.GetUserInfoByLogin(user.Username).UserID;
            CloseCommand = new RelayCommand(CloseWindow, p => true);
            ExitCommand = new RelayCommand(Exit, p => true);
            OrderButtonCommand = new RelayCommand(ShowOrders, p => true);

        }
        public void Exit(object obj = null)
        {
            CloseCommand.Execute(CloseHandler);
        }

        public void CloseWindow(object obj)
        {
            var handler = obj as EventHandler;
            if (handler != null) handler.Invoke(this, EventArgs.Empty);
        }
        public void ShowOrders(object obj = null)
        {
            App.Container.Resolve<OrderList>().Show();
        }

        public EventHandler CloseHandler;

        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand OrderButtonCommand { get; private set; }
        public RelayCommand ProductListButtonCommand { get; private set; }
    }
}
