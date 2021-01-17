using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DomainTeste.TesteDeEntidades
{
    [TestClass]
    public class TarefaTest
    {
        [DataTestMethod]
        [DataRow(50,12)]
        [DataRow(90,60)]
        [DataRow(0, 0)]
        public void DeveTestarMetodoProgredir(double progresso, double horas_de_esforço)
        {
            Tarefa tarefa = new Tarefa();

            tarefa.Progredir(
                progresso,
                horas_de_esforço);

            Assert.AreEqual(tarefa.Progresso, progresso);
            Assert.AreEqual(tarefa.HorasDeEsforco, horas_de_esforço);
        }

        [DataTestMethod]
        [DataRow(50, 12)]
        [DataRow(90, 60)]
        [DataRow(0, 0)]
        public void DeveTestarMetodoProgredirEmTarefasJaIniciadas(double progresso, double horas_de_esforço)
        {
            const double progresso_incial = 10;
            const double horas_de_esforco_inicial = 60;
            Tarefa tarefa = new Tarefa(progresso_incial, horas_de_esforco_inicial);

            tarefa.Progredir(
                progresso,
                horas_de_esforço);

            Assert.AreEqual(tarefa.Progresso, progresso + progresso_incial);
            Assert.AreEqual(tarefa.HorasDeEsforco, horas_de_esforço + horas_de_esforco_inicial);
        }


        [DataTestMethod]
        [DataRow(101,60)]
        [DataRow(0, -1)]
        [DataRow(-1, 0)]
        public void DeveTestarExceptionsDoMetodoProgredir(double progresso, double horas_de_progresso)
        {
            Tarefa tarefa = new Tarefa();
            Assert.ThrowsException<Exception>(() => tarefa.Progredir(progresso, horas_de_progresso));
        }

        [DataTestMethod]
        [DataRow(101, 60)]
        [DataRow(0, -1)]
        [DataRow(-1, 0)]
        public void DeveTestarExceptionsDoConstrutor(double progresso, double horas_de_progresso)
        {
            Assert.ThrowsException<Exception>(() => new Tarefa(progresso, horas_de_progresso));
        }


    }
}
