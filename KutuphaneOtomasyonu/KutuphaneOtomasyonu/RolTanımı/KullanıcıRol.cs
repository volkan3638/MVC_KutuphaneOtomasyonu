using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Kütüphaneotomasyonu.entities.Model.context;

namespace KutuphaneOtomasyonu.RolTanımı
{
    public class KullanıcıRol : RoleProvider
    {
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

        public override string[] GetRolesForUser(string username)//Roller İçin Kullanılacak
        {
            using (var context = new KutuphaneContext())
            { 
                var roles=(from k in context.kullanıcılars join
                           kr in context.kullanıcırolleris on k.Id equals kr.kullanıcıId
                           join r in context.rollers on kr.rolId equals r.Id
                           where k.email==username
                           
                           select r.rol).ToArray();
                return roles;
            
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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