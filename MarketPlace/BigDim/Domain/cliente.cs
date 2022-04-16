using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class cliente
    {
        public int id { get; set; }
        public string company { get; set; }
        public address address { get; set; }
        public string name { get; set; }
        public string cpfCnpj { get; set; }
        public string email { get; set; }
        public string emailDateLastChange { get; set; }
        public string exclusionDate { get; set; }
        public string gender { get; set; }
        public string birth { get; set; }
        public string type { get; set; }
        public string dddPhoneNumber { get; set; }
        public string phoneNumber { get; set; }
        public string dddCelPhoneNumber { get; set; }
        public string celPhoneNumber { get; set; }
        public bool emailVerified { get; set; }
        public string registrationLocal { get; set; }
        public string lastSendEmailVerification { get; set; }
        public string dateRegistry { get; set; }
        public bool cadastroTemporario { get; set; }
        public string disableMarketing { get; set; }
        public string dataVinculo { get; set; }
        public bool completarCadastro { get; set; }
    }
}
