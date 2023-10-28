using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace EuFalo.Domain
{
    public class retorno
    {
        public retorno()
        {
            information = new List<retorno_information>();
            errors = new List<retorno_errors>();
        }

        public List<retorno_information> information {  get; set; }
        public List<retorno_errors> errors { get; set; }
    }

    public class retorno_information
    {

    }

    public class retorno_errors
    {

    }
}
