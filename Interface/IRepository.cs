using System;
using System.Collections.Generic;

namespace Criando_um_app_simples_de_cadastro_de_series_em_.NET.Interface
{
    public interface IRepository<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
