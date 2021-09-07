using System.Collections.Generic;
using System.Linq;
using Utilitarios;

namespace Data
{
    public class DAOUser
    {
        public UUsuario login(LoginRequest user)
        {
            using (var db = new Mapeo())
            {
                UUsuario usuario = db.usuario.Where(x => x.UserName == user.Username && x.Clave == user.Password).FirstOrDefault();
                if (usuario != null)
                {
                    var propiedades = db.aplicacion.Where(x => x.Id == user.AplicacionId).FirstOrDefault();
                    usuario.Expiracion = propiedades.Expiracion;
                    usuario.Key = propiedades.Key;
                    usuario.AplicacionId = user.AplicacionId;
                }
            return usuario;
            }
        }

        public List<Utilitarios.UUsuario> GetUsers()
        {
            var lista = new Mapeo().usuario.ToList();
            return lista;
        }




    }
}