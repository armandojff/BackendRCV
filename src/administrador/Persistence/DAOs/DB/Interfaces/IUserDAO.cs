using administrador.BussinesLogic.DTOs;

namespace administrador.Persistence.DAOs.Interfaces
{
    public interface IUserDAO
    {
        public string createUser(UserDTO user);
    }
}