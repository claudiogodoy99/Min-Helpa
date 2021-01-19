
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id;
        public DiaDeTrabalho hoje;

        public bool PossuiPendencia() {
            return historico.Count(x => x.Fim == DateTime.MinValue) > 0;
        }

        public void NovoDiaDeTrabalho() {
            DomainValidation.Validar(() => PossuiPendencia(), "Você não pode começar um novo dia até ajustar suas dependências");
            hoje = new DiaDeTrabalho(date: DateTime.Now);
        }

        public void FinalizarDia() {
            hoje.FimDoDia(date: DateTime.Now);
            DomainValidation.Validar(() => hoje.HorasTrabalhadas <= 0, "Algo deu errado no seu apontamento");
            historico.Add(hoje);
        }


        public List<DateTime> incioApontamento;


        public ICollection<Tarefa> tarefas;
        public ICollection<DiaDeTrabalho> historico;


    }
}
