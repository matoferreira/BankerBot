using System;
using System.Collections.Generic;

//Esta clase es la encargada de analizar el ahorro de los usuarios
//Recibe una lista con paymentMethods y los recorre, tomando el ahorro presente en cada cuenta bancaria y en la billetera
//Devolviendo un string con el siguiente formato: (PaymentMethod),(Total)#, para su posterior uso por Telegram.
//Es un Singleton pues no tiene sentido que exista más de un objeto.
//Cumple con SRP pues su única razon de cambio es cuando es llamada por UserInterface.
//Cuando esto ocurre, esta clase devuelve un string con los gastos desglosados por cuenta.
namespace Library
{
    public class SavingsAnalysis
    {
        public string AnalyseSavings(List<PaymentMethod> savingsAccounts)
        {
            string lista = "El ahorro mensual es:\n";
            double total = 0;
            foreach (PaymentMethod item in savingsAccounts)
            {
                total = total + item.GetBalance();
                lista = lista + item.GetSavings();
            }
            lista = lista + $"Ahorro total: {total} Pesos#";
            return lista;
        }
    }
}