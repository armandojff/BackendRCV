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

namespace RCVUcabBackend.Persistence.DAOs.Implementations{

    public class AnalisisDB:IAnalisis{
        public string mensajeError = "Ocurrio un error inesperado ";
        private static DesignTimeDbContextFactory design = new DesignTimeDbContextFactory();
        private ITallerDbContext _context= design.CreateDbContext(null);

        public AnalisisEntity consultarAnalisisPorId(Guid id_analisis)
        {
            if (_context.Analisis.Any(x => x.Id == id_analisis ))
            {
                var analisis = _context.Analisis.Include(b => b.piezas).Where(c => c.Id.Equals(id_analisis)).First();
                return analisis;
            }
            return null;
        }

        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignados(Guid id_taller)
        {
            try
            {
                var data = _context.Analisis.Include(b => b.piezas).Where(c => c.id_usuario_taller.Equals(id_taller))
                    .Select(b => new AnalisisConsultaDTO
                    {
                        titulo_analisis = b.titulo_analisis,
                        estado = b.estado.ToString(),
                        piezas=b.piezas.Select(PiezaDTO=> new PiezasConsultDTO{
                            descripcion_pieza=PiezaDTO.descripcion_pieza,
                            estado=PiezaDTO.estado.ToString(),
                            precio=PiezaDTO.precio
                        }).ToList()
                    }).ToList();
                return data;
            }
            catch (Exception e)
            {
                throw new ExcepcionTaller(mensajeError);
            }
        }

        public List<AnalisisConsultaDTO> ConsultarRequerimientosAsignadosPorFiltro(Guid id_taller,CheckEstadoAnalisisAccidente filtro)
        {
            try
            {
                var data = _context.Analisis.
                    Include(b => b.piezas).
                    Where(c => c.id_usuario_taller.Equals(id_taller)&&
                               c.estado==filtro)
                    .Select(b => new AnalisisConsultaDTO
                    {
                        titulo_analisis = b.titulo_analisis,
                        estado = b.estado.ToString(),
                        piezas=b.piezas.Select(PiezaDTO=> new PiezasConsultDTO{
                            descripcion_pieza=PiezaDTO.descripcion_pieza,
                            estado=PiezaDTO.estado.ToString(),
                            precio=PiezaDTO.precio
                        }).ToList()
                    }).ToList();
                return data;
            }
            catch (Exception e)
            {
                throw new ExcepcionTaller(mensajeError);
            }
        }

    }




}