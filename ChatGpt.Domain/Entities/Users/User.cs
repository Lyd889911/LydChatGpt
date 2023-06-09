﻿
using ChatGpt.Domain.Entities.Users.ChatGpt;
using ChatGpt.Shared;
using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGpt.Shared.Enums;
using ChatGpt.Domain.Entities.Permissions;

namespace ChatGpt.Domain.Entities.Users
{
    public class User:AggregateRoot
    {
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string? Avatar { get; private set; }
        public int MaxUseCountDaily { get; private set; }
        public int SurplusUserCountDaily { get; private set; }
        public Role Role { get; private set; }

        private User()
        {

        }
        internal User(string userName, string password, string? avatar,Role role)
        {
            UserName = userName;
            PasswordHash = HashHelper.ComputeSha256Hash(password);
            Avatar = avatar;
            MaxUseCountDaily = GetMaxUseCountDaily(role);
            SurplusUserCountDaily = MaxUseCountDaily;
            Role = role;
        }

        public bool CheckPassword(string password)
        {
            return PasswordHash == HashHelper.ComputeSha256Hash(password) ? true : false;
        }
        public void SetPassword(string newPassword)
        {
            if(!string.IsNullOrEmpty(newPassword))
                PasswordHash = HashHelper.ComputeSha256Hash(newPassword);
        }
        public void SetAvatar(string? avatar)
        {
            if(avatar!=null)
                Avatar = avatar;
        }
        public void SetUserName(string userName)
        {
            if(!string.IsNullOrEmpty(userName))
                UserName = userName;
        }
        public void UseAI()
        {
            if (SurplusUserCountDaily<=0)
                throw new ArgumentException("每天次数已经使用完成");
            else
                SurplusUserCountDaily--;
        }
        public void ResumeAICount()
        {
            SurplusUserCountDaily=MaxUseCountDaily;
        }
        public void SetRole(Role role)
        {
            this.Role = role;
            int max = this.MaxUseCountDaily;
            this.MaxUseCountDaily = GetMaxUseCountDaily(role);
            max = MaxUseCountDaily - (max - SurplusUserCountDaily);
            this.SurplusUserCountDaily = max<0?0:max;
        }
        public bool Equals(User user)
        {
            if(user==null) return false;
            return this.UserName == user.UserName;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
        public int GetMaxUseCountDaily(Role role)
        {
            switch (role)
            {
                case Role.SuperAdmin: return 2000;
                case Role.Admin: return 1000;
                case Role.SVip: return 100;
                case Role.Vip: return 50;
                default: return 2;
            }
        }
    }
}
