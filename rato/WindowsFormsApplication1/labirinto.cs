using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class labirinto
    {
        //metodos
        private int linhas = 0;
        private int colunas = 0;
        private int linha_atual;
        private int coluna_atual;
        private int queijos;
        private int queijo2;
        private int passos;
        private int passos2;
        private int ver;
        private int hor;
        private double p_a;
        private int tempo;
        private string msg;

        String[,] matriz;

        Random aleatorio = new Random();
        Random direc = new Random();

        public delegate void atualiza();
        public event atualiza onatualiza;

        public rato rato = new rato();

        public Queijo[] queijo;
        public int QUEIJOS { get { return queijos; } }

        public string MSG { get { return msg; } }
        public int QUEIJOS2 { get { return queijo2; } }
        public int PASSOS { get { return passos; } }
        public int PASSOS2 { get { return passos2; } set { value = PASSOS2; } }
        public int TEMPO { get { return tempo; } }

        //atributos
        public void define_linhas(int linhas) //parametro
        {
            if (linhas < 0)
            {
                linhas *= -1;
            }
            if (linhas < 10)
            {
                linhas = 10;
            }
            if (linhas > 20)
            {
                linhas = 20;
            }
            this.linhas = linhas;
            // linhas atributo = linhas parâmetro
        }
        public void define_colunas(int colunas) //parametro
        {
            if (colunas < 0)
            {
                colunas *= -1;
            }
            if (colunas < 10)
            {
                colunas = 10;
            }
            if (colunas > 20)
            {
                colunas = 20;
            }
            this.colunas = colunas;
            // linhas atributo = linhas parâmetro
        }
        public void define_queijo(int queijos)
        {
            if (queijos < 0)
            {
                queijos *= -1;
            }
            if (queijos > 10)
            {
                queijos = 10;
            }
            this.queijos = queijos;
        }
        public void define_passos(int passos)
        {
            if (passos < 0)
            {
                passos *= -1;
            }
            if (passos < 5)
            {
                passos = 5;
            }
            this.passos = passos;

        }
        public void define_parede(int parede)
        {
            this.ver = parede;
        }
        public void atualiza_passos(int pas)
        {
            passos2 = pas;
        }
        public void define_aleatorio(double aleatorio)
        {
            this.p_a = aleatorio;
        }
        public void define_parede2(int parede)
        {
            this.hor = parede;

        }
        public void define_tempo(int t)
        {
            if (t == 0)
            {
                t = 1000000000;
            }
            this.tempo = t;
        }
        public void atualiza_queijo()
        {
            queijo2 = queijos;
        }
        public int obtem_linhas()
        {
            return this.linhas;
        }
        public int obtem_colunas()
        {
            return this.colunas;
        }
        public void inicializar_matriz()
        {
            this.matriz = new String[linhas, colunas];
            double t;
            double p;
            p = p_a / 100;

            t = ((linhas - 1) * (colunas - 1)) * p;
            for (int i = 0; i < this.linhas; i++)
            {
                for (int j = 0; j < this.colunas; j++)
                {
                    if (i == 0 || i == this.linhas - 1 || j == 0 || j == this.colunas - 1)
                    {
                        this.matriz[i, j] = "p";
                    }
                    else
                    {
                        this.matriz[i, j] = "";
                    }
                }
            }
            for (int l = 0; l < t; l++)
            {
                int l_a;
                int c_a;
                do
                {
                    l_a = aleatorio.Next(1, linhas - 1);
                    c_a = aleatorio.Next(1, colunas - 1);

                } while (this.matriz[l_a, c_a] == "p");

                if (this.matriz[l_a, c_a] == "")
                {
                    this.matriz[l_a, c_a] = "p";
                }
            }

            this.rato.define_linhas(aleatorio.Next(1, this.linhas - 1));
            this.rato.define_colunas(aleatorio.Next(1, this.colunas - 1));
            this.matriz[rato.obtem_linhas(), rato.obtem_colunas()] = "r";

            cria_queijo();
        }
        public void lab_conect()
        {
            this.matriz = new String[linhas, colunas];

            for (int i = 0; i < this.linhas; i++)
            {
                for (int j = 0; j < this.colunas; j++)
                {
                    if (i == 0 || i == this.linhas - 1 || j == 0 || j == this.colunas - 1)
                    {
                        this.matriz[i, j] = "p";
                    }
                    else
                    {
                        this.matriz[i, j] = "";
                    }
                }
            }
            int p;
            p = linhas / 4;
            if (linhas > colunas)
            {
                p = colunas / 4;
            }
            if (p >= ver + hor)
            {

                for (int l = 0; l < ver; l++)
                {
                    do
                    {
                        linha_atual = aleatorio.Next(1, linhas - 2);
                        coluna_atual = aleatorio.Next(1, colunas - 2);

                    } while ((obtem_valor(linha_atual + 1, coluna_atual) == "p") ||
                (obtem_valor(linha_atual - 1, coluna_atual) == "p") ||
                (obtem_valor(linha_atual, coluna_atual + 1) == "p") ||
                (obtem_valor(linha_atual, coluna_atual - 1) == "p") ||
                (obtem_valor(linha_atual + 1, coluna_atual + 1) == "p") ||
                (obtem_valor(linha_atual - 1, coluna_atual + 1) == "p") ||
                (obtem_valor(linha_atual - 1, coluna_atual - 1) == "p") ||
                (obtem_valor(linha_atual + 1, coluna_atual - 1) == "p"));

                    int auxl = linha_atual;
                    int auxc = coluna_atual;

                    while (obtem_valor(linha_atual + 1, coluna_atual) != "p")
                    {
                        while (linha_atual < linhas - 2)
                        {
                            linha_atual += 1;
                            define_valor_celula(linha_atual, coluna_atual, "p");
                        }
                    }
                    while (obtem_valor(auxl - 1, coluna_atual) != "p")
                    {
                        while (auxl > 1)
                        {
                            auxl -= 1;
                            define_valor_celula(auxl, coluna_atual, "p");
                        }
                    }
                }
                for (int m = 0; m < hor; m++)
                {
                    do
                    {
                        linha_atual = aleatorio.Next(1, linhas - 2);
                        coluna_atual = aleatorio.Next(1, colunas - 2);

                    } while ((obtem_valor(linha_atual + 1, coluna_atual) == "p") ||
                (obtem_valor(linha_atual - 1, coluna_atual) == "p") ||
                (obtem_valor(linha_atual, coluna_atual + 1) == "p") ||
                (obtem_valor(linha_atual, coluna_atual - 1) == "p") ||
                (obtem_valor(linha_atual + 1, coluna_atual + 1) == "p") ||
                (obtem_valor(linha_atual - 1, coluna_atual + 1) == "p") ||
                (obtem_valor(linha_atual - 1, coluna_atual - 1) == "p") ||
                (obtem_valor(linha_atual + 1, coluna_atual - 1) == "p"));

                    int auxl = linha_atual;
                    int auxc = coluna_atual;
                    while (obtem_valor(linha_atual, coluna_atual + 1) != "p")
                    {
                        while (coluna_atual < colunas - 2)
                        {
                            coluna_atual += 1;
                            define_valor_celula(linha_atual, coluna_atual, "p");
                        }
                    }
                    while (obtem_valor(linha_atual, auxc - 1) != "p")
                    {
                        while (auxc > 1)
                        {
                            auxc -= 1;
                            define_valor_celula(linha_atual, auxc, "p");
                        }
                    }
                }
                msg = "Labirinto Gerado";
            }
            else
            {
                msg = "ERRO MUITAS PAREDES: diminua o numero de paredes";
            }

            this.rato.define_linhas(aleatorio.Next(1, this.linhas - 2));
            this.rato.define_colunas(aleatorio.Next(1, this.colunas - 2));
            this.matriz[rato.obtem_linhas(), rato.obtem_colunas()] = "r";
            cria_queijo();

        }

        public void lab_vazio()
        {
            this.matriz = new String[linhas, colunas];

            for (int i = 0; i < this.linhas; i++)
            {
                for (int j = 0; j < this.colunas; j++)
                {
                    if (i == 0 || i == this.linhas - 1 || j == 0 || j == this.colunas - 1)
                    {
                        this.matriz[i, j] = "p";
                    }
                    else
                    {
                        this.matriz[i, j] = "";
                    }
                }
            }

            this.rato.define_linhas(aleatorio.Next(1, this.linhas - 2));
            this.rato.define_colunas(aleatorio.Next(1, this.colunas - 2));
            this.matriz[rato.obtem_linhas(), rato.obtem_colunas()] = "r";
            cria_queijo();

        }
        public void cria_queijo()
        {
            queijo = new Queijo[queijos];
            int x1;
            int x2;
            for (int i = 0; i < queijos; i++)
            {
                queijo[i] = new Queijo();

                do
                {
                    x1 = aleatorio.Next(1, this.linhas - 2);
                    x2 = aleatorio.Next(1, this.colunas - 2);

                } while (obtem_valor(x1, x2) != "" && obtem_valor(x1, x2) != "x" && obtem_valor(x1, x2) != "xx");

                this.queijo[i].define_linhas(x1);
                this.queijo[i].define_colunas(x2);
                this.matriz[queijo[i].obtem_linhas(), queijo[i].obtem_colunas()] = "q";
            }
            passos2 = 0;
        }
        public void apaga_queijo()
        {
            for (int i = 0; i < this.linhas; i++)
            {
                for (int j = 0; j < this.colunas; j++)
                {
                    if (this.matriz[i, j] == "q")
                    {
                        this.matriz[i, j] = "";
                    }
                }
            }
            for (int i = 0; i < queijos; i++)
            {
                if (rato.obtem_linhas() == queijo[i].obtem_linhas() &&
                    rato.obtem_colunas() == queijo[i].obtem_colunas())
                {
                    queijo[i].define_linhas(1);
                    queijo[i].define_colunas(0);
                }
            }
        }


        public String obtem_valor(int linhas, int colunas)
        {
            return this.matriz[linhas, colunas];
        }

        public void define_valor_celula(int linha, int coluna, String valor)
        {
            this.matriz[linha, coluna] = valor;
        }

        public void movimenta_rato(Char direcao)
        {
            int linha_atual = rato.obtem_linhas();
            int coluna_atual = rato.obtem_colunas();

            switch (direcao)
            {
                case 'w':
                    if (obtem_valor(linha_atual - 1, coluna_atual) != "p")
                    {
                        //this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_linhas(linha_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                    }
                    break;

                case 's':
                    if (obtem_valor(linha_atual + 1, coluna_atual) != "p")
                    {
                        // this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_linhas(linha_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                    }
                    break;

                case 'd':
                    if (obtem_valor(linha_atual, coluna_atual + 1) != "p")
                    {
                        //this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_colunas(coluna_atual + 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                    }
                    break;

                case 'a':
                    if (obtem_valor(linha_atual, coluna_atual - 1) != "p")
                    {
                        //this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "";
                        this.rato.define_colunas(coluna_atual - 1);
                        this.matriz[this.rato.obtem_linhas(), this.rato.obtem_colunas()] = "r";
                    }
                    break;
            }

        }

        public void seguidor_de_parede()
        {
            int linha = rato.obtem_linhas();
            int colunas = rato.obtem_colunas();

            if (obtem_valor(linha, colunas + 1) != "p")
            {
                movimenta_rato('d');
            }
            else if (obtem_valor(linha + 1, colunas) != "p")
            {
                movimenta_rato('s');
            }
            else if (obtem_valor(linha - 1, colunas) != "p")
            {
                movimenta_rato('w');
            }
            else if (obtem_valor(linha, colunas - 1) != "p")
            {
                movimenta_rato('a');
            }
        }
        public void repinta()
        {
            for (int i = 0; i < this.linhas; i++)
            {
                for (int j = 0; j < this.colunas; j++)
                {
                    if (this.matriz[i, j] == "xx" || this.matriz[i, j] == "x")
                    {
                        ;
                        if (aleatorio.Next(0, 10) % 2 == 0)
                        {
                            this.matriz[i, j] = "";
                        }
                    }
                }
                onatualiza();
            }

        }
        public void tezeu()
        {
            int linha = rato.obtem_linhas();
            int colunas = rato.obtem_colunas();

            int auxl = linha;
            int auxc = colunas;

            if ((obtem_valor(linha + 1, colunas) != "p") && (obtem_valor(linha + 1, colunas) == "") || (obtem_valor(linha + 1, colunas) == "q"))
            {
                this.matriz[auxl, auxc] = "x";

                movimenta_rato('s');
                passos2++;
            }
            else if ((obtem_valor(linha - 1, colunas) != "p") && (obtem_valor(linha - 1, colunas) == "") || (obtem_valor(linha - 1, colunas) == "q"))
            {
                this.matriz[auxl, auxc] = "x";
                movimenta_rato('w');
                passos2++;

            }
            else if ((obtem_valor(linha, colunas + 1) != "p") && (obtem_valor(linha, colunas + 1) == "") || (obtem_valor(linha, colunas + 1) == "q"))
            {
                this.matriz[auxl, auxc] = "x";
                movimenta_rato('d');
                passos2++;
            }
            else if ((obtem_valor(linha, colunas - 1) != "p") && (obtem_valor(linha, colunas - 1) == "") || (obtem_valor(linha, colunas - 1) == "q"))
            {
                this.matriz[auxl, auxc] = "x";
                movimenta_rato('a');
                passos2++;
            }
            else if ((obtem_valor(auxl + 1, auxc) != "p") && (obtem_valor(auxl + 1, auxc) == "x"))
            {
                this.matriz[auxl, auxc] = "xx";
                movimenta_rato('s');
                passos2++;
            }
            else if ((obtem_valor(auxl - 1, auxc) != "p") && (obtem_valor(auxl - 1, auxc) == "x"))
            {
                this.matriz[auxl, auxc] = "xx";
                movimenta_rato('w');
                passos2++;
            }
            else if ((obtem_valor(auxl, auxc + 1) != "p") && (obtem_valor(auxl, auxc + 1) == "x"))
            {
                this.matriz[auxl, auxc] = "xx";
                movimenta_rato('d');
                passos2++;
            }
            else if ((obtem_valor(auxl, auxc - 1) != "p") && (obtem_valor(auxl, auxc - 1) == "x"))
            {
                this.matriz[auxl, auxc] = "xx";
                movimenta_rato('a');
                passos2++;
            }
            else
            {
                repinta();
            }
        }
    }
}
