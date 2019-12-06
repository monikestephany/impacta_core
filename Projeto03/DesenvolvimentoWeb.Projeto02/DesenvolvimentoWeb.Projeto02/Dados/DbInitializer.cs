using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public static class DbInitializer
    {
        public static void Initialize(EventosContext context)
        {
            //O método EnsureCreated() fará o sincronismo com o BD
            context.Database.EnsureCreated();
        }
    }
}
