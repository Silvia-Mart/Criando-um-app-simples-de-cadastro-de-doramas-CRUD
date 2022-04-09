using System;
using System.Collections.Generic;
using Criando_um_app_simples_de_cadastro_de_series_em_.NET.Interface;

namespace Criando_um_app_simples_de_cadastro_de_series_em_.NET
{
    public class DoramaRepository : IRepository<Doramas>
    {
        private List<Doramas> listaDoramas = new List<Doramas>();
        public void Atualiza(int id, Doramas objeto)
        {
            listaDoramas[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaDoramas[id].Excluir();
        }

        public void Insere(Doramas objeto)
        {
            listaDoramas.Add(objeto);
        }

        public List<Doramas> Lista()
        {
            return listaDoramas;
        }

        public int ProximoId()
        {
            return listaDoramas.Count;
        }

        public Doramas RetornaPorId(int id)
        {
            return listaDoramas[id];
        }
    }
}
