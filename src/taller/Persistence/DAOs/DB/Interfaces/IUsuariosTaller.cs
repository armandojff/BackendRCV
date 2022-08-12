using System;
using System.Collections.Generic;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
namespace RCVUcabBackend.Persistence.DAOs.Interfaces{
    public interface IUsuarioTaller
    {
        public crearUsuarioTallerDTO crearUsuarioTaller(UsuarioTallerEntity usuarioTaller);
        public string EliminarUsuarioTaller(UsuarioTallerEntity usuario_taller);
        public string ActualizarUsuarioTaller(UsuarioTallerEntity UsuariotallerCambios,UsuarioTallerEntity UsuariotallerSinCambios);
        
    }
}