using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Atomic;
using RCVUcabBackend.BussinesLogic.TallerCommands.Commands.Composes;
using RCVUcabBackend.Persistence.Entities;
using RCVUcabBackend.BussinesLogic.DTOs.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs;
using RCVUcabBackend.BussinesLogic.DTOs.DTOMQ;
using RCVUcabBackend.Persistence.Entities.ChecksEntitys;


namespace RCVUcabBackend.BussinesLogic.TallerCommands{
    public class CommandFactory{
        public static InsertTallerCommand crearInsertTallerCommand(TallererEntity tallerEntity){
            return new InsertTallerCommand(tallerEntity);
        }

        public static InsertListaDeTelefonoCommand crearInsertListaDeTelefonoCommand(ICollection<TelefonoEntity> telefono){
            return new InsertListaDeTelefonoCommand(telefono);
        }

        public static InsertUsuarioTallerCommand crearInsertUsuarioTallerCommand(UsuarioTallerEntity usuarioTaller){
            return new InsertUsuarioTallerCommand(usuarioTaller);
        }
        

        public static ConsultarListaMarcaCommand crearConsultarListaMarcaCommand(ICollection<MarcaCarroEntity> marcaEntity,TallererEntity taller){
            return new ConsultarListaMarcaCommand(marcaEntity,taller);
        }

        public static CrearTallerCommand crearCrearTallerCommand(TallererEntity tallerEntity){
            return new CrearTallerCommand(tallerEntity);
        }

        public static CrearUsuarioTallerCommand crearCrearUsuarioTallerCommand(UsuarioTallerEntity usuarioTaller,Guid id_taller){
            return new CrearUsuarioTallerCommand(usuarioTaller,id_taller);
        }

        public static EliminarTallerCommand crearEliminarTallerCommand(Guid id_taller){
            return new EliminarTallerCommand(id_taller);
        }

        public static ActualizarTallerCommand crearActualizarTallerCommand(TallererEntity tallerEntity,Guid id_taller){
            return new ActualizarTallerCommand( tallerEntity, id_taller);
        }

        public static UpdateTallerCommand crearUpdateTallerCommand(TallererEntity tallerEntity,Guid id_taller){
            return new UpdateTallerCommand( tallerEntity, id_taller);
        }

        public static ConsultarAnalisisPorIdCommand crearConsultarAnalisisPorIdCommand(Guid id_taller){
            return new ConsultarAnalisisPorIdCommand( id_taller);
        }

        public static ConsultarPiezasARepararCommand crearConsultarPiezasARepararCommand(AnalisisEntity analisis){
            return new ConsultarPiezasARepararCommand( analisis);
        }

        public static ObtenerPiezasARepararDelAnalisisCommand crearObtenerPiezasARepararDelAnalisisCommand(Guid id_analisis){
            return new ObtenerPiezasARepararDelAnalisisCommand(id_analisis);
        } 

        public static ConsultarPiezaPorIdCommand crearConsultarPiezaPorIdCommand(Guid id_pieza){
            return new ConsultarPiezaPorIdCommand(id_pieza);
        }

        public static EditarEstadoPiezaCommand crearEditarEstadoPiezaCommand(PiezasEntity pieza,CheckEstadoPieza estado){
            return new EditarEstadoPiezaCommand(pieza,estado);
        }

        public static ActualizarEstadoDeLaPiezaCommand crearActualizarEstadoDeLaPiezaCommand(Guid id_pieza,CheckEstadoPieza estado){
            return new ActualizarEstadoDeLaPiezaCommand(id_pieza,estado);
        }

        public static EditarDescripcionDeLaPiezaCommand crearEditarDescripcionDeLaPiezaCommand(PiezasEntity pieza,string descripcion_nueva){
            return new EditarDescripcionDeLaPiezaCommand(pieza,descripcion_nueva);
        }

        public static ActualizarDescripcionDeLaPiezaCommand crearActualizarDescripcionDeLaPiezaCommand(Guid id_pieza,string descripcion_nueva){
            return new ActualizarDescripcionDeLaPiezaCommand(id_pieza,descripcion_nueva);
        }


        public static ConsultarTallerPorIdCommand crearConsultarTallerPorIdCommand(Guid id_taller){
            return new ConsultarTallerPorIdCommand(id_taller);
        }

        public static ConsultarUsuarioTallerPorIdCommand crearConsultarUsuarioTallerPorIdCommand(Guid id_usuario_taller){
            return new ConsultarUsuarioTallerPorIdCommand(id_usuario_taller);
        }

        public static EliminarUsuarioTallerCommand crearEliminarUsuarioTallerCommand(UsuarioTallerEntity usuario_taller){
            return new EliminarUsuarioTallerCommand(usuario_taller);
        }

        public static DeleateUsuarioTallerCommand crearDeleateUsuarioTallerCommand(Guid id_usuario_taller){
            return new DeleateUsuarioTallerCommand(id_usuario_taller);
        }

        public static ConsultarRequerimientosAsignadosPorFiltroCommand crearConsultarRequerimientosAsignadosPorFiltroCommand(Guid id_taller,CheckEstadoAnalisisAccidente estado){
            return new ConsultarRequerimientosAsignadosPorFiltroCommand(id_taller,estado);
        }

        public static ConsultarListaTelefonoComand crearConsultarListaTelefonosComand(ICollection<TelefonoEntity> telefonosEntity,UsuarioTallerEntity usuarioTaller){
            return new ConsultarListaTelefonoComand(telefonosEntity,usuarioTaller);
        }

        public static ActualizarUsuarioTallerCommand crearActualizarUsuarioTallerCommand(UsuarioTallerEntity usuarioTallerSinCambios,UsuarioTallerEntity usuarioTallerConnCambios){
            return new ActualizarUsuarioTallerCommand(usuarioTallerSinCambios,usuarioTallerConnCambios);
        }

        public static UpdateUsuarioTallerCommand crearUpdateUsuarioTallerCommand(UsuarioTallerEntity usuarioTallerConnCambios,Guid idUsuarioTaller){
            return new UpdateUsuarioTallerCommand(usuarioTallerConnCambios,idUsuarioTaller);
        }

        public static SendCotizacionCommand crearSendCotizacionCommand(CotizacionMQ cotizacion){
            return new SendCotizacionCommand(cotizacion);
        }

        public static InsertCotizacionTallerCommand crearInsertCotizacionTallerCommand(CotizacionTallerEntity cotizacion,string fechaInicio,string fechaCulminacion){
            return new InsertCotizacionTallerCommand(cotizacion,fechaInicio,fechaCulminacion);
        }

        public static crearCotizacionDeAnalisisCommand crearCrearCotizacionDeAnalisisCommandd(CotizacionTallerEntity cotizacion,Guid idUsuarioTaller,string fechaInicio,string fechaCulminacion){
            return new crearCotizacionDeAnalisisCommand(cotizacion,idUsuarioTaller,fechaInicio,fechaCulminacion);
        }







    }
}