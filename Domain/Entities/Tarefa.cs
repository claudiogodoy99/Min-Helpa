using Domain.Validation;
using System;

namespace Domain
{
    public class Tarefa
    {
        public Tarefa()
        {
        }

        public Tarefa(double progresso, double horasDeEsforco )
        {
            DomainValidation.Validar(() => progresso > 100, "progresso excedente 100%");
            DomainValidation.Validar(() => progresso < 0, "Seu progresso tem que ser positivo");
            DomainValidation.Validar(() => horasDeEsforco < 0, "Suas horas de esforço não devem ser menores que 0");

            Progresso = progresso;
            HorasDeEsforco = horasDeEsforco;
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public double Progresso { get; private set; }
        public double HorasDeEsforco { get; private set; }

        public void Progredir(
            double progresso,
            double horasDeEsforco) {

            DomainValidation.Validar(() => Progresso == 100, "Tarefa ja foi concluida");
            DomainValidation.Validar(() => progresso + Progresso > 100, "progresso excedente 100%");
            DomainValidation.Validar(() => progresso < 0, "Seu progresso tem que ser positivo");
            DomainValidation.Validar(() => horasDeEsforco < 0, "Suas horas de esforço não devem ser menores que 0");

            Progresso += progresso;
            HorasDeEsforco += horasDeEsforco;
        }


       
    }
}
