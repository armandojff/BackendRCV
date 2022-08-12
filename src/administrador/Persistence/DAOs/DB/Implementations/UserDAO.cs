using System;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Exceptions;
using Novell.Directory.Ldap;
namespace administrador.Persistence.DAOs.Implementations
{
    public class UserDAO : IUserDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);

        public UserDAO(IRCVDbContext context)
        {
            _context = context;
        }
        
        public string createUser(UserDTO user){
            //datos para entrar al ldap
            string ldapHost = "localhost";
            int ldapPort = 10389;
            string loginDN = "uid=admin,ou=system";
            string password = "secret";
            string searchBase = "ou=users,o=Company";
            string searchFilter = "objectClass=inetOrgPerson";
            try{
                LdapConnection conn = new LdapConnection();
                conn.Connect(ldapHost, ldapPort);
                conn.Bind(loginDN, password);
                LdapAttributeSet attributeSet = new LdapAttributeSet();
                attributeSet.Add( new LdapAttribute( "objectclass","inetOrgPerson")); 
                attributeSet.Add( new LdapAttribute("cn", new string[]{"James Smith",
                    "Jimmy Smith"}));
                attributeSet.Add( new LdapAttribute("givenname", "James"));
                attributeSet.Add( new LdapAttribute("sn", "Smith"));
                attributeSet.Add( new LdapAttribute("mail", "JSmith@Acme.com"));
                attributeSet.Add(	new LdapAttribute("userpassword","newpassword"));
                string dn = "cn=Administrators,ou=users";
                LdapEntry newEntry = new LdapEntry( dn, attributeSet );
                conn.Add( newEntry );
                conn.Disconnect();
                return "Asegurado creado";
            }
            catch(Exception ex){
                throw new RCVExceptions("Error al crear el asegurado", ex);
                
            }
        }
        
        
    }
}