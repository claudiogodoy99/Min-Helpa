

using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class DiaDeTrabalho
    {
        public DiaDeTrabalho(){
            Inicio = DateTime.Now;

            Pausas = new List<DateTime>();
            Retornos = new List<DateTime>();
        }


        public int UsuarioId { get; set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; } 

        public ICollection<DateTime> Pausas { get; private set; }
        public ICollection<DateTime> Retornos { get; private set; }

        public void FimDoDia()
        {
            DomainValidation.Validar(() => Inicio != DateTime.MinValue, "Seu dia não começou");
            Fim = DateTime.Now;
        }
        public void SairParaUmaPausa()
        {
            DomainValidation.Validar(() => Pausas.Count > Retornos.Count, "Você está em uma pausa");
            ValidaInicioFimDoDia();

            Pausas.Add(DateTime.Now);
        }
        public void VoltarDeUmaPausa()
        {
            DomainValidation.Validar(() => Pausas.Count < Retornos.Count, "Você não está em uma pausa");
            ValidaInicioFimDoDia();

            Retornos.Add(DateTime.Now);
        }

        public double HorasTrabalhadas
        {
            get
            {
                return  Fim.Date.Hour - Inicio.Date.Hour;
            }
            private set { }
        }


        private void ValidaInicioFimDoDia() {
            DomainValidation.Validar(() => Fim != DateTime.MinValue, "Seu dia já acabou");
            DomainValidation.Validar(() => Inicio != DateTime.MinValue, "Seu dia não começou");
        }
    }
}
