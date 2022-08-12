
using perito.BussinesLogic.DTOs;
using perito.Commands.Atomics.Perito;
using perito.Commands.Composes;
using perito.Persistence.Entities;

namespace perito.Commands
{
    public class CommandFactory
    {
        //Perito
        public static InsertAnalisisCommand createCreateAnalisisCommand(AnalisisEntity analisis)
        {
            return new InsertAnalisisCommand(analisis);
        }
        public static SendAnalisisToTallerCommand createSendAnalisisCommand(Guid response)
        {
            return new SendAnalisisToTallerCommand(response);
        }

        public static InsertPeritoCommand createCreatePeritoCommand(UsuarioPeritoEntity reponse)
        {
            return new InsertPeritoCommand(reponse);
        }
        
        public static InsertPiezaCommand createCreatePiezaCommand(PiezaEntity reponse)
        {
            return new InsertPiezaCommand(reponse);
        }

        public static CreateAnalisisCommand CreateCreateAnalisisCommand(AnalisisEntity response)
        {
            return new CreateAnalisisCommand(response);
        }

        public static DeleteAnalisisCommand CreateDeleteAnalisisCommand(Guid response)
        {
            return new DeleteAnalisisCommand(response);
        }

        public static ActualizarAnalisisCommand createActualizarAnalisisCommand(AnalisisEntity response,
            Guid id_analisis)
        {
            return new ActualizarAnalisisCommand(response, id_analisis);
        }
        
        public static DeletePeritoCommand CreateDeletePeritoCommand(Guid response)
        {
            return new DeletePeritoCommand(response);
        }

        public static ActualizarPeritoCommand CreateActualizarPeritoCommand(UsuarioPeritoEntity response,
            Guid id_perito)
        {
            return new ActualizarPeritoCommand(response, id_perito);
        }
        

        /*public static getAnalisisCommand createGetAnalisisCommand(Guid respnse)
        {
            return getAnalisisCommand(respnse);
        }*/
    }
}