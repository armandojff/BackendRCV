using System;
using System.Collections.Generic;
using System.Linq;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Persistence.Database;
using administrador.Exceptions;
using administrador.Persistence.Entities;

namespace administrador.Persistence.DAOs.Implementations
{
    public class IncidenteDAO : IIncidenteDAO
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);
        
        public IncidenteDAO(){}
        
        public IncidenteDAO(IRCVDbContext context)
        {
            _context = context; //evaluar
        }
        
        /*--------------------------Crea un incidente-----------------------------*/
        public string createAccident(IncidentesEntity incident)
        {
            try
            {
                _context.incident.Add(incident);
                _context.DbContext.SaveChanges();
                return "Incidente registrado con éxito";
            }
            catch(Exception ex){
                throw new RCVExceptions("No se puede crear el incidente", ex);
                
            }
            return NotImplementedException;
        }
        
        /*--------------------------Consultar un incidente-------------------------*/
        public List<IncidentesSimpleDTO> getAccident(Guid id)
        {
            try
            {
                var accident = _context.incident
                    .Where(b => b.PolizaEntityId == id)
                    .Select(p => new IncidentesSimpleDTO()
                    {
                        fecha = p.fecha,
                        ubicacion = p.ubicacion,
                        descripcion = p.descripcion
                    }).ToList();
                if(accident.ToList().Count == 0){
                    throw new Exception("Esta poliza no tiene incidentes registrados");
                }
                return accident.ToList();
            }
            catch(Exception ex)
            {
                throw new RCVExceptions("No se ha podido presentar la lista de incidentes", ex.Message, ex);
            }
        }
        
        /*--------------------------Borrar un incidente-------------------------*/
        public string deleteAccident(Guid id)
        {
            try
            {
                var accident = _context.incident
                    .Where(p => p.Id == id)
                    .ToList();
                if (accident.ToList().Count == 0){
                    throw new Exception("El incidente ingresado no existe");
                }
                accident.FirstOrDefault();
                _context.incident.Remove(accident.ToList()[0]);
                return "Incidente borrado con éxito";
            }
            catch(Exception ex)
            {
                throw new RCVExceptions("No se ha podido borrar el incidente", ex.Message, ex);
            }
        }
        
        public string NotImplementedException { get; set; }
    }
}