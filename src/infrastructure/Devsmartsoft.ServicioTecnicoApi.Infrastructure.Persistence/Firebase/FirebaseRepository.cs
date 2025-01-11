using Devsmartsoft.ServicioTecnicoApi.Core.Domain.HelperEntities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Firebase.Database;
using Firebase.Database.Query;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Firebase
{
    public sealed class FirebaseRepository : IFirebaseRepository
    {
        #region Fields     
        private readonly string firbaseUri = "https://mybusinessservices-5d0d1-default-rtdb.firebaseio.com/";
        private readonly string firebaseDbSecret = "MGS0L9WtAcf26ZPe4WnRA4lz1sQHxOT4TvNyl82d";
        private readonly FirebaseClient _firebaseClient;
        #endregion

        #region Ctor
        public FirebaseRepository()
        {
            _firebaseClient = new FirebaseClient(firbaseUri, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(firebaseDbSecret)
            });
        }
        #endregion

        #region Methods   
        public async Task<bool> Guardar<T>(T entidad, FirebaseRutaBase rutaBase, string nodoRaiz)
        {
            await _firebaseClient
                .Child(nodoRaiz)
                .Child(rutaBase.IdNegocio)
                .Child(rutaBase.NodoEntidad)
                .Child(rutaBase.Path)
                .PatchAsync(entidad);
            return true;
        }

        public async Task<bool> Actualizar<T>(T entidad, FirebaseRutaBase rutaBase, string nodoRaiz)
        {
            await _firebaseClient
                .Child(nodoRaiz)
                .Child(rutaBase.IdNegocio)
                .Child(rutaBase.NodoEntidad)
                .Child(rutaBase.Path)
                .PutAsync(entidad);
            return true;
        }

        public async Task<bool> Eliminar<T>(T entidad, FirebaseRutaBase rutaBase, string nodoRaiz)
        {
            await _firebaseClient
               .Child(nodoRaiz)
               .Child(rutaBase.IdNegocio)
               .Child(rutaBase.NodoEntidad)
               .Child(rutaBase.Path)
               .DeleteAsync();
            return true;
        }

        public async Task<T> ConsultarPorId<T>(FirebaseRutaBase rutaBase, string nodoRaiz, string id)
        {
            var result = await _firebaseClient
                .Child(nodoRaiz)
                .Child(rutaBase.IdNegocio)
                .Child(rutaBase.NodoEntidad)
                .Child(rutaBase.Path)
                .Child(id)
                .OnceSingleAsync<T>();
            return result;
        }

        public async Task<List<T>> ConsultarLista<T>(FirebaseRutaBase rutaBase, string nodoRaiz)
        {
            var result = await _firebaseClient
                .Child(nodoRaiz)
                .Child(rutaBase.IdNegocio)
                .Child(rutaBase.NodoEntidad)
                .Child(rutaBase.Path)
                .OnceAsync<T>();

            var list = new List<T>();
            foreach (var item in result)
            {
                list.Add(item.Object);
            }
            return list;
        }
        #endregion
    }
}

