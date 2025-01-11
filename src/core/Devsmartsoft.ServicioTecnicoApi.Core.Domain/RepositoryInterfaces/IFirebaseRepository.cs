using Devsmartsoft.ServicioTecnicoApi.Core.Domain.HelperEntities;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces
{
    public interface IFirebaseRepository
    {
        Task<bool> Guardar<T>(T entidad, FirebaseRutaBase rutaBase, string nodoRaiz);
        Task<bool> Actualizar<T>(T entidad, FirebaseRutaBase rutaBase, string nodoRaiz);
        Task<bool> Eliminar<T>(T entidad, FirebaseRutaBase rutaBase, string nodoRaiz);
        Task<T> ConsultarPorId<T>(FirebaseRutaBase rutaBase, string nodoRaiz, string id);
        Task<List<T>> ConsultarLista<T>(FirebaseRutaBase rutaBase, string nodoRaiz);
    }
}
