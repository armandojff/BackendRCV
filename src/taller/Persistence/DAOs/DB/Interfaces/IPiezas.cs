using System;
using System.Collections.Generic;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;

namespace RCVUcabBackend.Persistence.DAOs.Interfaces{
    public interface IPiezas{
        public List<PiezasConsultDTO> ConsultarPiezasAReparar(AnalisisEntity analisis);
        public PiezasConsultDTO EditarEstadoPieza(PiezasEntity id_pieza,CheckEstadoPieza estado);
        public PiezasConsultDTO EditardescripcionPieza(PiezasEntity PiezadescripcionVieja,string PiezadescripcionNueva);
    }
}