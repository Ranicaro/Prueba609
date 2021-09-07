using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Data
{
    public class DAOSecurity
    {
        public void almacenarToken(UToken token)
        {
            using (var db = new Mapeo())
            {
                db.token.Add(token);
                db.SaveChanges();
            }
        }

        public UAplicacion getAplicaionesByToken(string token)
        {
            using(var db = new Mapeo())
            {
                return (from t in db.token
                        join a in db.aplicacion on t.AplicacionId equals a.Id
                        where t.Token.Equals(token)
                        select new
                        {
                            a
                        }).ToList().Select(m => new UAplicacion
                        {
                            Id = m.a.Id,
                            Expiracion = m.a.Expiracion,
                            Key = m.a.Key,
                            Nombre = m.a.Nombre 
                        }).FirstOrDefault();
            }
        }
    }


}
