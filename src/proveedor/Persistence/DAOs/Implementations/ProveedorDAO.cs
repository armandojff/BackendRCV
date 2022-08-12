using System;
using System.Collections.Generic;
using System.Linq;
using backendRCVUcab.Exceptions;
using backendRCVUcab.Persistence.Database;
using backendRCVUcab.Persistence.Entities;
using backendRCVUcab.Persistence.Entities.ChecksEntitys;
using Microsoft.EntityFrameworkCore;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend.Persistence.DAOs.Implementations
{
    public class ProveedorDao : IProveedorDAO
    {
        public ProveedorEntity Proveedor = new ProveedorEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado ";
        public ICollection<MarcaEntity> listaMarcas = new List<MarcaEntity>();
        public Tipo_Proveedor tipos = new Tipo_Proveedor();
        
        
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);
        

        public bool verificarMarca(IRCVDbContext context, MarcaDTO marcaValidar)
        {
            if (context.Marcas.Any(x => x.nombre == marcaValidar.nombre))
            {
                return true;
            }

            return false;
        }

        public bool AsignarMarcaExistente(IRCVDbContext context, MarcaDTO marcaValidar)
        {
            if (verificarMarca(context, marcaValidar))
            {
                var marca = context.Marcas.Where(b => b.nombre.Equals(marcaValidar.nombre)).First();
                this.listaMarcas.Add(marca);
                return true;
            }

            return false;
        }

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

        public bool validarExistenciaProveedor(IRCVDbContext context, ProveedorDTO proveedorValidar)
        {
            if (context.Proveedores.Any(x => x.nombre == proveedorValidar.nombre &&
                                             x.direccion.Equals(proveedorValidar.direccion) &&
                                             x.telefono.Equals(proveedorValidar.telefono)
                )
               )
            {
                return true;
            }

            return false;
        }

        public bool verificarTipo(IRCVDbContext context, Tipo_Proveedor proveedorValidar)
        {
            if (context.Tipos.Any(x => x.tipo == proveedorValidar.tipo))
            {
                return true;
            }

            return false;
        }

        public bool AsignarTiposExistente(IRCVDbContext context, Tipo_Proveedor tipoValidar)
        {
            if (verificarTipo(context, tipoValidar))
            {
                var tipo = context.Tipos.Where(b => b.tipo.Equals(tipoValidar.tipo)).First();
                tipos = tipo;
                return true;
            }

            return false;
        }

        public void crearProveedorEntity(ProveedorDTO P)
        {
            var i2 = 0;
            var mp = new MarcaEntity();
            foreach (var marcaproveedor in P.marcas)
            {
                if (!AsignarMarcaExistente(_context, marcaproveedor))
                {
                    mp = new MarcaEntity();
                    mp.nombre = marcaproveedor.nombre;
                    mp.CreatedAt = DateTime.Now;
                    mp.CreatedBy = null;
                    mp.UpdatedAt = null;
                    mp.UpdatedBy = null;
                    listaMarcas.Add(mp);
                    _context.Marcas.Add(mp);
                    i2 = _context.DbContext.SaveChanges();
                }
            }

            if (!AsignarTiposExistente(_context, P.tipoProveedor))
            {
                var tp = new Tipo_Proveedor();
                tp = new Tipo_Proveedor();
                mp.nombre = P.tipoProveedor.tipo;
                mp.CreatedAt = DateTime.Now;
                mp.CreatedBy = null;
                mp.UpdatedAt = null;
                mp.UpdatedBy = null;

            }
           

            this.Proveedor.marcas = listaMarcas;
            this.Proveedor.direccion = P.direccion;
            this.Proveedor.tipo = this.tipos;
            this.Proveedor.telefono = P.telefono;
            this.Proveedor.nombre = P.nombre;
            this.Proveedor.CreatedAt = DateTime.Now;
            this.Proveedor.UpdatedAt = null;
            this.Proveedor.CreatedBy = null;
            this.Proveedor.UpdatedBy = null;
        }

        public ProveedorDTO CreateProveedor(ProveedorDTO proveedor)
        {
            var i = 0;
            try
            {
                if (validarExistenciaProveedor(_context, proveedor) == true)
                {
                    error++;
                    mensajeError = "No se puede crear este proveedor porque ya existe";
                    throw new RCVExceptions(mensajeError);
                }

                if ((String.IsNullOrEmpty(proveedor.direccion) || validarEspaciosBlancos(proveedor.direccion)) ||
                    (String.IsNullOrEmpty(proveedor.nombre) || validarEspaciosBlancos(proveedor.nombre)) ||
                    (String.IsNullOrEmpty(proveedor.telefono) || validarEspaciosBlancos(proveedor.telefono)) ||
                    proveedor.marcas.Count == 0)
                {
                    error++;
                    mensajeError =
                        "No se puede crear un proveedor si alguno de estos datos esta vacio:nombre del proveedor, direccion, telefono y marcas ";
                    throw new RCVExceptions(mensajeError);
                }
                else
                {
                    crearProveedorEntity(proveedor);
                    var data = _context.Proveedores.Add(this.Proveedor);
                    i = _context.DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RCVExceptions(mensajeError);
            }

            return proveedor;
        }



        public ProveedorDTO consultarSolicitudesAsignadas(Guid id_proveedor)
        {
            try
            {
                var data = _context.Proveedores.Include(b => b.solicitudes).Where(b => b.Id == id_proveedor)
                    .Select(b => new ProveedorDTO
                    {
                        nombre = b.nombre,
                        direccion = b.direccion,
                        telefono = b.telefono,
                        tipoProveedor = b.tipo,
                        solicitudes = b.solicitudes.Select(s => new SolicitudDTO()
                        {
                            nombre = s.nombre,
                            idAnalisis = s.idAnalisis,
                            estado = s.estado.ToString()
                            
                        }).ToList()
                    });
                return data.Single();

            }
            catch (Exception e)
            {
                throw new RCVExceptions(mensajeError);
            }
            
            
        }
    }
}
