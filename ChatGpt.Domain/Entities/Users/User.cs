using ChatGpt.Domain.Entities.Files;
using ChatGpt.Shared;
using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Users
{
    public class User:AggregateRoot
    {
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public Guid AvatarId { get; private set; }
        public int MaxUseCountDaily { get; private set; }
        public int SurplusUserCountDaily { get; private set; }

        private User()
        {

        }
        internal User(string userName, string password, FileItem avatar,int maxUseCountDaily)
        {
            UserName = userName;
            PasswordHash = HashHelper.ComputeSha256Hash(password);
            AvatarId = avatar.Id;
            MaxUseCountDaily = maxUseCountDaily;
            SurplusUserCountDaily = maxUseCountDaily;
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
        public void SetAvatar(FileItem avatar)
        {
            if(avatar!=null)
                AvatarId = avatar.Id;
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
        public bool Equals(User user)
        {
            return this.UserName == user.UserName;
        }

    }
}
