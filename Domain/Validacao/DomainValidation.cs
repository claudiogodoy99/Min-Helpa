
using System;

namespace Domain.Validation
{
    public class DomainValidation
    {
        public static void Validar(Func<bool> action, string menssagemDeErro)
        {
            if (action.Invoke()) throw new Exception(menssagemDeErro);
        }
    }
}
