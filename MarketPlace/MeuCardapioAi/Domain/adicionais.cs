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
        public adicionais_campo campo7 { get; set; }
        public adicionais_campo campo8 { get; set; }
        public adicionais_campo campo9 { get; set; }
        public adicionais_campo campo10 { get; set; }
        public adicionais_campo campo11 { get; set; }
        public adicionais_campo campo12 { get; set; }
        public adicionais_campo campo13 { get; set; }
        public adicionais_campo campo14 { get; set; }
        public adicionais_campo campo15 { get; set; }

        public adicionais_lista lista0 { get; set; }
        public adicionais_lista lista1 { get; set; }
        public adicionais_lista lista2 { get; set; }
        public adicionais_lista lista3 { get; set; }
        public adicionais_lista lista4 { get; set; }
        public adicionais_lista lista5 { get; set; }
        public adicionais_lista lista6 { get; set; }
        public adicionais_lista lista7 { get; set; }
        public adicionais_lista lista8 { get; set; }
        public adicionais_lista lista9 { get; set; }
        public adicionais_lista lista10 { get; set; }
        public adicionais_lista lista11 { get; set; }
        public adicionais_lista lista12 { get; set; }
        public adicionais_lista lista13 { get; set; }
        public adicionais_lista lista14 { get; set; }
        public adicionais_lista lista15 { get; set; }        

        public List<adicionais_campo> getListaCampos()
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
            if (campo7 != null)
                lista.Add(campo7);
            if (campo8 != null)
                lista.Add(campo8);
            if (campo9 != null)
                lista.Add(campo9);
            if (campo10 != null)
                lista.Add(campo10);
            if (campo11 != null)
                lista.Add(campo11);
            if (campo12 != null)
                lista.Add(campo12);
            if (campo13 != null)
                lista.Add(campo13);
            if (campo14 != null)
                lista.Add(campo14);
            if (campo15 != null)
                lista.Add(campo15);            

            return lista;
        }

        public List<adicionais_lista> getListaLista()
        {
            var lista = new List<adicionais_lista>();
            if (lista0 != null)
                lista.Add(lista0);
            if (lista1 != null)
                lista.Add(lista1);
            if (lista2 != null)
                lista.Add(lista2);
            if (lista3 != null)
                lista.Add(lista3);
            if (lista4 != null)
                lista.Add(lista4);
            if (lista5 != null)
                lista.Add(lista5);
            if (lista6 != null)
                lista.Add(lista6);
            if (lista7 != null)
                lista.Add(lista7);
            if (lista8 != null)
                lista.Add(lista8);
            if (lista9 != null)
                lista.Add(lista9);
            if (lista10 != null)
                lista.Add(lista10);
            if (lista11 != null)
                lista.Add(lista11);
            if (lista12 != null)
                lista.Add(lista12);
            if (lista13 != null)
                lista.Add(lista13);
            if (lista14 != null)
                lista.Add(lista14);
            if (lista15 != null)
                lista.Add(lista15);

            return lista;
        }
    }

}
