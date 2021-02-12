using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainTeste.TesteDeEntidades
{
    [TestClass]
    public class DiaDeTrabalhoTest
    {
      
        [DataTestMethod]
        public void DeveTestarCalculoDeHorasTrabalhadas (){
            DiaDeTrabalho hoje = new DiaDeTrabalho(DateTime.Now);
            hoje.SairParaUmaPausa(DateTime.Now.AddMinutes(15));
            hoje.VoltarDeUmaPausa(DateTime.Now.AddMinutes(30));
            hoje.FimDoDia(DateTime.Now.AddHours(8));

            Assert.IsTrue(hoje.HorasTrabalhadas >= 7.75 && hoje.HorasTrabalhadas <= 7.76);
        }
    }
}
