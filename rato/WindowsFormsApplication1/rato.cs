using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class rato
    {
        private int linhas;
        private int colunas;

        public void define_linhas(int linhas)
        {
            this.linhas = linhas;
        }

        public void define_colunas(int colunas)
        {
            this.colunas = colunas;
        }

        public int obtem_linhas()
        {
            return this.linhas;
        }

        public int obtem_colunas()
        {
            return this.colunas;
        }

        public void andar_direita(int colunas)
        {
            this.colunas++;
        }

        public void andar_esquerda(int colunas)
        {
            this.colunas--;
        }

        public void andar_cima(int linhas)
        {
            this.linhas--;
        }

        public void andar_baixo(int linhas)
        {
            this.linhas++;
        }
    }
}
