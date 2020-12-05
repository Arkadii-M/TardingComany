using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TradingCompanyMVC.App.Security
{
    public class CustomRole : RoleProvider
    {
        protected readonly IUserInfoManager _userInfoManager;
        protected readonly IAccountManager _accountManager;

        public CustomRole()
        {
            _userInfoManager = DependencyResolver.Current.GetService<IUserInfoManager>();
            _accountManager = DependencyResolver.Current.GetService<IAccountManager>();
        }
        public CustomRole(IUserInfoManager userInfoManager, IAccountManager accountManager)
        {
            _userInfoManager = userInfoManager;
            _accountManager = accountManager;

        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if(!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return this._accountManager.GetAccountByLogin(username).Privileges.Select(p => p.Name).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var roles =this.GetRolesForUser(username);
            return roles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}