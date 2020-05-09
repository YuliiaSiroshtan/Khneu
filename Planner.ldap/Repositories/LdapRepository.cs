using Novell.Directory.Ldap;
using Planner.ldap.Models;
using System;
using System.Collections.Generic;

namespace Planner.ldap
{
    public static class LdapRepository
    {
        private static readonly String _baseSearch = "dc=ldap,dc=hneu,dc=edu,dc=ua";
        private static ILdapConnection _connection;

        private static ILdapConnection GetConnection()
        {
            LdapConnection ldapConn = _connection as LdapConnection;

            if (ldapConn == null)
            {
                // Creating an LdapConnection instance 
                ldapConn = new LdapConnection();

                //Connect function will create a socket connection to the server - Port 389 for insecure and 3269 for secure    
                ldapConn.Connect("ldap.hneu.edu.ua", 389);

                //Bind function with null user dn and password value will perform anonymous bind to LDAP server 
                ldapConn.Bind(@"cn=auth_u,dc=ldap,dc=hneu,dc=edu,dc=ua", "104070Uu");
            }

            return ldapConn;
        }

        public static List<ResponseModel> GetUserByName(String name)
        {
            var ldapConn = GetConnection();

            var searchBase = _baseSearch;
            var filter = $"(givenName={name})";
            var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);
            return GetResponseModel(search);
        }

        public static List<ResponseModel> GetUserById(int id)
        {
            var ldapConn = GetConnection();

            var searchBase = _baseSearch;
            var filter = $"(uidNumber={id})";
            var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);
            return GetResponseModel(search);
        }

        public static List<ResponseModel> GetFak()
        {
            var ldapConn = GetConnection();

            var searchBase = "ou=FAK,dc=ldap,dc=hneu,dc=edu,dc=ua";
            var filter = String.Empty;
            var search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);
            return GetResponseModel(search);
        }

        public static List<ResponseModel> GetGroups()
        {
            var ldapConn = GetConnection();

            var searchBase = "ou=groups,dc=ldap,dc=hneu,dc=edu,dc=ua";
            var filter = String.Empty;
            ILdapSearchResults search = ldapConn.Search(searchBase, LdapConnection.ScopeSub, filter, null, false);
            return GetResponseModel(search);
        }

        private static List<ResponseModel> GetResponseModel(ILdapSearchResults search)
        {
            List<ResponseModel> results = new List<ResponseModel>();
            while (search.HasMore())
            {
                var nextEntry = search.Next();
                var attr = nextEntry.GetAttributeSet();
                var values = attr.Values;

                ResponseModel data = new ResponseModel();
                foreach (var item in values)
                {
                    var cn = item.StringValue;

                    data.Data.Add(item.Name, item.StringValue);
                }
                results.Add(data);
            }
            return results;
        }
    }
}
