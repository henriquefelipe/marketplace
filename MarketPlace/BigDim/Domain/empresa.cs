using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigdim.Domain
{
    public class empresa
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public object dateExclusion { get; set; }
        public string email { get; set; }
        public string dateRegistry { get; set; }
        public string timeRegistry { get; set; }
        public bool passwordExpired { get; set; }
        public bool blocked { get; set; }
        public string dateLastChangePassword { get; set; }
        public string timeLastChangePassword { get; set; }
        public bool emailValidated { get; set; }
        //public List<object> profiles { get; set; }
        public address address { get; set; }
        public object matriz { get; set; }
        public string corporateName { get; set; }
        public string shortName { get; set; }
        public string cpfCnpj { get; set; }
        public string nameResponsible { get; set; }
        public string cpfResponsavel { get; set; }
        public string numWhats { get; set; }
        public string whatsAppLink { get; set; }
        public string urlFacebook { get; set; }
        public string urlInstagram { get; set; }
        public string consultorId { get; set; }
        public string origin { get; set; }
        public string ultimoAcesso { get; set; }
        public string diasUltimoAcesso { get; set; }
        public string vencimentoPlano { get; set; }
        public string experimental { get; set; }
        public string clienteIdIugu { get; set; }
        public string keywords { get; set; }
    }
}
