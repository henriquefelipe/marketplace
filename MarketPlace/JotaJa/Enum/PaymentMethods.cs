using System;
using System.Collections.Generic;
using System.Text;

namespace JotaJa.Enum
{
    public class PaymentMethods
    {
        public const string Dinheiro = "Dinheiro";

        // Cartões
        public const string Debito = "Débito";
        public const string Credito = "Crédito";
        public const string CartaodeCredito = "Cartão de Crédito";
        public const string HiperCard = "Hiper Card";
        public const string Visa = "Visa";
        public const string VisaElectron = "Visa Electron";
        public const string Maestro = "Maestro";
        public const string Mastercard = "Mastercard";
        public const string AmericanExpress = "American Express";
        public const string EloDebito = "Elo Débito";
        public const string EloCredito = "Elo Crédito";

        //Vales Refeição/Alimentação
        public const string TicketRestaurante = "Ticket Restaurante";
        public const string TicketAlimentacao = "Ticket Alimentação";
        public const string BenVisaValeRefeicao = "Ben Visa Vale Refeição";
        public const string VRRefeicao = "VR Refeição";
        public const string VRAlimentacao = "VR Alimentação";
        public const string SodexoRefeicao = "Sodexo Refeição";
        public const string AleloRefeicao = "Alelo Refeição";
        public const string AleloAlimentacao = "Alelo Alimentação";
        public const string SodexoAlimentacao = "Sodexo Alimentação";
    }
}
