using System;
using System.Collections.Generic;

namespace administrador.Persistence.DAOs.Interfaces
{
    public interface IMarcaDAO
    {
        public List<Guid> getMarca(string marca); // me trae el guid de la marca
        public String createMarca(String marca); //me crea una marca

    }
}