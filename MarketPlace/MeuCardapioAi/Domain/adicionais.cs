using System.Collections.Generic;

namespace MeuCardapioAi.Domain
{
    public class adicionais
    {
        public adicionais_campo campo0 { get; set; }
        public adicionais_campo campo1 { get; set; }
        public adicionais_campo campo2 { get; set; }
        public adicionais_campo campo3 { get; set; }
        public adicionais_campo campo4 { get; set; }
        public adicionais_campo campo5 { get; set; }
        public adicionais_campo campo6 { get; set; }

        public List<adicionais_campo> getLista()
        {
            var lista = new List<adicionais_campo>();
            if (campo0 != null)
                lista.Add(campo0);
            if (campo1 != null)
                lista.Add(campo1);
            if (campo2 != null)
                lista.Add(campo2);
            if (campo3 != null)
                lista.Add(campo3);
            if (campo4 != null)
                lista.Add(campo4);
            if (campo5 != null)
                lista.Add(campo5);
            if (campo6 != null)
                lista.Add(campo6);

            return lista;
        }
    }

}
