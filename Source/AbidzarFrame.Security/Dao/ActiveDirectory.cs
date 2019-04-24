using AbidzarFrame.Security.Interface.Dto;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using AbidzarFrame.Utils;
using System.Configuration;

namespace AbidzarFrame.Security.Dao
{
    public class ActiveDirectory
    {
        private static bool IsAccountLocked(SearchResult user)
        {
            // if they have a lockoutTime
            if (user.Properties.Contains("lockoutTime"))
            {
                var lockout = user.Properties["lockoutTime"][0];
                // check to see if it's not already unlocked
                if ((lockout != null && (int)lockout != 0))
                {
                    return true;
                }

            }

            return false;
        }

        public static ActiveDirectoryResult IsAuthenticated(string userId)
        {
            PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
            List<ActiveDirectoryResult> lUser_helper = new List<ActiveDirectoryResult>();
            string domainName = ConfigurationSettings.AppSettings["ActiveDirectoryServer"];
            string connection = ("LDAP://" + domainName);
            DirectoryEntry dEntry = new DirectoryEntry(connection);
            DirectorySearcher dssearch = new DirectorySearcher(dEntry);

            dssearch.Filter = ("(&(sAMAccountName=" + (userId + (")" + ("(objectCategory=person)" + ")"))));

            SearchResultCollection sresult;
            sresult = dssearch.FindAll();
            if ((sresult.Count > 0))
            {
                foreach (SearchResult result in sresult)
                {
                    DirectoryEntry dsresult = new DirectoryEntry();
                    dsresult = result.GetDirectoryEntry();
                    if (dsresult.Properties["mail"].Value != null)
                    {
                        lUser_helper.Add(MappingAd(dsresult));
                    }
                }
            }

            return lUser_helper[0];
        }

        public static List<ActiveDirectoryResult> GetActiveDirBy(string filterAdBy, string value)
        {
            PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
            List<ActiveDirectoryResult> lUser_helper = new List<ActiveDirectoryResult>();
            if ((filterAdBy != ""))
            {
                string domainName = ConfigurationSettings.AppSettings["ActiveDirectoryServer"];
                string connection = ("LDAP://" + domainName);
                DirectoryEntry dEntry = new DirectoryEntry(connection);
                DirectorySearcher dssearch = new DirectorySearcher(dEntry);

                if(filterAdBy != null)
                {
                    if (filterAdBy.ToUpper() == EnumList.FilterAdBy.Email.ToString().ToUpper())
                    {
                        dssearch.Filter = ("(&(mail=" + (value + ("*)" + ("(objectCategory=person)" + ")"))));
                    }
                    else
                    {
                        dssearch.Filter = ("(&(sAMAccountName=" + (value + ("*)" + ("(objectCategory=person)" + ")"))));
                    }
                }               
                else
                {
                    dssearch.Filter = ("(&(sAMAccountName=" + (value + ("*)" + ("(objectCategory=person)" + ")"))));
                }

                SearchResultCollection sresult;
                sresult = dssearch.FindAll();
                if ((sresult.Count > 0))
                {
                    foreach (SearchResult result in sresult)
                    {
                        DirectoryEntry dsresult = new DirectoryEntry();
                        dsresult = result.GetDirectoryEntry();
                        if (dsresult.Properties["mail"].Value != null)
                        {
                            lUser_helper.Add(MappingAd(dsresult));
                        }
                    }
                }
            }
            return lUser_helper;
        }

        private static ActiveDirectoryResult MappingAd(DirectoryEntry dsresult)
        {
            List<ActiveDirectoryResult> lUser_helper = new List<ActiveDirectoryResult>();
            ActiveDirectoryResult user_helper = new ActiveDirectoryResult()
            {
                UserId = dsresult.Properties["sAMAccountName"][0] != null ? dsresult.Properties["sAMAccountName"][0].ToString() : string.Empty,
                UserName = dsresult.Properties["displayName"][0] != null ? dsresult.Properties["displayName"][0].ToString() : string.Empty,
                Email = dsresult.Properties["mail"][0] != null ? dsresult.Properties["mail"][0].ToString() : string.Empty,
                Departement = dsresult.Properties["distinguishedName"][0] != null ? dsresult.Properties["distinguishedName"][0].ToString() : string.Empty
            };
            return user_helper;
        }
    }
}
