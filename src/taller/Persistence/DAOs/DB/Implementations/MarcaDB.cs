using System;
using System.Collections.Generic;
using System.Linq;
using RCVUcabBackend.Exceptions;
using RCVUcabBackend.Persistence.Database;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using Microsoft.EntityFrameworkCore;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.Persistence.Entities;

namespace RCVUcabBackend.Persistence.DAOs.Implementations
{
    public class MarcaDB:IMarca
    {   
        public string mensajeError = "Ocurrio un error inesperado ";
        private static DesignTimeDbContextFactory design = new DesignTimeDbContextFactory();
        private ITallerDbContext _context= design.CreateDbContext(null);

        public bool validarEspaciosBlancos(string texto)
        {
            var cantidad_espacios = 0;
            foreach (var caracter in texto)
            {
                if (caracter.Equals(' '))
                {
                    cantidad_espacios++;
                    Console.WriteLine(caracter); 
                }
            }

            if (cantidad_espacios == texto.Length)
            {
                return true;
            }

            return false;
        }

        public bool verificarMarca(MarcaCarroEntity marcaValidar)
        {
            if (_context.Marcas.Any(x => x.nombre_marca == marcaValidar.nombre_marca))
            {
                return true;   
            }
            return false;
        }

        public ICollection<MarcaCarroEntity> AsignarMarcaExistente(ICollection<MarcaCarroEntity> marcaValidar,TallererEntity taller)
        {
            ICollection<MarcaCarroEntity> nuevaLista=new List<MarcaCarroEntity>();
            var i=0;
            foreach (MarcaCarroEntity marca in marcaValidar)
            {
                if (verificarMarca(marca))
                {
                    i++;
                    MarcaCarroEntity marcaExistente = _context.Marcas.
                        Include(b=>b.talleres).
                        Where(b =>b.nombre_marca==marca.nombre_marca).First();
                        nuevaLista.Add(marcaExistente);
                }
                else
                {
                    _context.Marcas.Add(marca);
                    _context.DbContext.SaveChanges();
                    nuevaLista.Add(marca);
                }
            }
            return nuevaLista;
        }

        public MarcaDTO crearMarca(MarcaCarroEntity marcaNueva)
        {
            try
            {
                if ((String.IsNullOrEmpty(marcaNueva.nombre_marca)||validarEspaciosBlancos(marcaNueva.nombre_marca)))
                {
                    mensajeError = "No se puede crar una marca si el nombre de la marca esta vacio";
                    throw new ExcepcionTaller(mensajeError);
                }else
                {
                    _context.Marcas.Add(marcaNueva);
                    _context.DbContext.SaveChanges();
                    var dataRespuesta=_context.Marcas.
                    Where(marca=>marca.Id.Equals(marcaNueva.Id)).
                    Select(marca=>new MarcaDTO{
                        nombre_marca=marca.nombre_marca
                    });
                    return dataRespuesta.First();
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionTaller(mensajeError);
            }
        }
    }
}