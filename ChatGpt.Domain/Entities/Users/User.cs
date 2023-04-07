
using ChatGpt.Domain.Entities.Users.ChatGpt;
using ChatGpt.Shared;
using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGpt.Shared.Enums;
using ChatGpt.Domain.Permissions;
using ChatGpt.Domain.Entities.Permissions;

namespace ChatGpt.Domain.Entities.Users
{
    public class User:AggregateRoot
    {
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public Uri? Avatar { get; private set; }
        public int MaxUseCountDaily { get; private set; }
        public int SurplusUserCountDaily { get; private set; }
        public ChatGptSetting ChatGptSetting { get; private set; }
        public Role Role { get; private set; }

        private User()
        {

        }
        internal User(string userName, string password, Uri? avatar,int maxUseCountDaily, Role role)
        {
            UserName = userName;
            PasswordHash = HashHelper.ComputeSha256Hash(password);
            Avatar = avatar;
            MaxUseCountDaily = maxUseCountDaily;
            SurplusUserCountDaily = maxUseCountDaily;
            ChatGptSetting = new ChatGptSetting(this);
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
        public void SetAvatar(Uri? avatar)
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
    }
}
