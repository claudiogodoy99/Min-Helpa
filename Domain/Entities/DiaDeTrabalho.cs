

using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class DiaDeTrabalho
    {
        public DiaDeTrabalho(DateTime date)
        {
            Inicio = date;

            Pausas = new List<DateTime>();
            Retornos = new List<DateTime>();
        }
        public int UsuarioId { get; set; }

        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }

        public List<DateTime> Pausas { get; private set; }
        public List<DateTime> Retornos { get; private set; }

        public double HorasTrabalhadas
        {
            get => CalcularHorasTrabalhadas();
            private set { }
        }

        public void FimDoDia(DateTime date)
        {
            DomainValidation.Validar(() => Inicio == DateTime.MinValue, "Seu dia não começou");
            DomainValidation.Validar(() => date.CompareTo(Inicio) <= 0 , "Você está passando uma data menor que a data de início");

            Fim = date;
        }

        public void SairParaUmaPausa(DateTime date)
        {
            DomainValidation.Validar(() => Pausas.Count > Retornos.Count, "Você está em uma pausa");
            ValidaInicioFimDoDia();

            Pausas.Add(date);
        }

        public void VoltarDeUmaPausa(DateTime date)
        {
            DomainValidation.Validar(() => Pausas.Count < Retornos.Count, "Você não está em uma pausa");
            ValidaInicioFimDoDia();

            Retornos.Add(date);
        }

        private double CalcularHorasTrabalhadas()
        {
            DomainValidation.Validar(() => Inicio == DateTime.MinValue, "Seu dia não começou");

            DateTime data_final = Fim != DateTime.MinValue ? Fim : DateTime.Now ;

            double minutos_trabalhados = data_final.Subtract(Inicio).TotalMinutes;

            double agregado_pausas = 0;

            for (int i = 0; i < Retornos.Count; i++)
            {
                agregado_pausas += Retornos[i].Subtract(Pausas[i]).TotalMinutes;
            }

            return (minutos_trabalhados - agregado_pausas) / 60;
        }

        private void ValidaInicioFimDoDia()
        {
            DomainValidation.Validar(() => Fim != DateTime.MinValue, "Seu dia já acabou");
            DomainValidation.Validar(() => Inicio == DateTime.MinValue, "Seu dia não começou");
        }
    }
}
