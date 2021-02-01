using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        labirinto Labirinto = new labirinto();
        public Form1()
        {
            InitializeComponent();
            numericUpDown5.Show();
            numericUpDown6.Show();
            label7.Show();
            label6.Show();
            panel1.Show();
            label5.Show();
            comboBox1.Hide();
            label8.Hide();
            Labirinto.onatualiza += new labirinto.atualiza(Labirinto_onatualiza);
        }

        void Labirinto_onatualiza()
        {
            desenhar_labirinto();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void desenhar_labirinto()
        {
            for (int i = 0; i < Labirinto.obtem_linhas(); i++)
            {
                d1.Rows[i].Height = 18;

                for (int j = 0; j < Labirinto.obtem_colunas(); j++)
                {
                    d1.Columns[j].Width = 18;

                    switch (Labirinto.obtem_valor(i, j))
                    {
                        case "p":
                            d1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(46, 204, 113);
                            break;

                        case "q":
                            d1.Rows[i].Cells[j].Style.BackColor = Color.Gold;
                            break;

                        case "r":
                            d1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                            break;
                        case "x":
                            d1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(250, 177, 160);
                            break;
                        case "xx":
                            d1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(214, 48, 49);
                            break;

                        default:
                            d1.Rows[i].Cells[j].Style.BackColor = Color.GhostWhite;
                            break;
                    }
                }
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Labirinto.define_linhas(Convert.ToInt32(numericUpDown1.Value));
            Labirinto.define_colunas(Convert.ToInt32(numericUpDown2.Value));
            Labirinto.define_tempo(Convert.ToInt32(numericUpDown7.Value));
            if((checkBox1.Checked==false) && (checkBox2.Checked==false))
            {
                checkBox1.Checked = true;
            }
            if (radioButton1.Checked)
            {
                Labirinto.define_parede(Convert.ToInt32(numericUpDown5.Value));
                Labirinto.define_parede2(Convert.ToInt32(numericUpDown6.Value));
                if (checkBox1.Checked)
                {
                    checkBox2.Checked = false;
                    Labirinto.define_queijo(Convert.ToInt32(numericUpDown3.Value));
                    Labirinto.define_passos(Convert.ToInt32(numericUpDown4.Value));
                }
                else
                {
                    checkBox1.Checked = false;
                    Labirinto.define_queijo(1);
                }

                Labirinto.lab_conect();
                MessageBox.Show(Labirinto.MSG);
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    Labirinto.define_aleatorio(Convert.ToInt32(comboBox1.Text));
                }
                catch { MessageBox.Show("INSIRA A PORCENTAGEM"); }
                if (checkBox1.Checked)
                {
                    checkBox2.Checked = false;
                    Labirinto.define_queijo(Convert.ToInt32(numericUpDown3.Value));
                    Labirinto.define_passos(Convert.ToInt32(numericUpDown4.Value));
                }
                else
                {
                    checkBox1.Checked = false;
                    Labirinto.define_queijo(1);
                }
                Labirinto.inicializar_matriz();
            }
            else
            {
                if (checkBox1.Checked)
                {
                    checkBox2.Checked = false;
                    Labirinto.define_queijo(Convert.ToInt32(numericUpDown3.Value));
                    Labirinto.define_passos(Convert.ToInt32(numericUpDown4.Value));
                }
                else
                {
                    checkBox1.Checked=false;
                    Labirinto.define_queijo(1);
                }

                Labirinto.lab_vazio();
            }
                //desenhar as colunas no datagrid
                d1.ColumnCount = Labirinto.obtem_colunas();
                d1.RowCount = Labirinto.obtem_linhas();

                desenhar_labirinto();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            int linha = d1.CurrentCell.RowIndex;
            int coluna = d1.CurrentCell.ColumnIndex;

            Labirinto.define_valor_celula(linha, coluna, "p");

            desenhar_labirinto();

            d1.ClearSelection();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            int linha = d1.CurrentCell.RowIndex;
            int coluna = d1.CurrentCell.ColumnIndex;

            Labirinto.define_valor_celula(linha, coluna, "");

            desenhar_labirinto();

            d1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Labirinto.movimenta_rato('w');
            desenhar_labirinto();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Labirinto.movimenta_rato('d');
            desenhar_labirinto();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Labirinto.movimenta_rato('a');
            desenhar_labirinto();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Labirinto.movimenta_rato('s');
            desenhar_labirinto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double temp;
            DateTime agora = DateTime.Now;

            if (checkBox1.Checked)
            {
                int cont = 0;
                Labirinto.atualiza_queijo();
                do
                {
                    TimeSpan depois = DateTime.Now - agora;
                    temp = depois.Minutes * 60;
                    temp = temp + depois.Seconds;
                    label10.Text = temp.ToString();
                    label10.Refresh();
                    //Labirinto.seguidor_de_parede();
                    Labirinto.tezeu();
                    if (Labirinto.PASSOS == Labirinto.PASSOS2)
                    {
                        Labirinto.apaga_queijo();
                        Labirinto.cria_queijo();
                    }
                    desenhar_labirinto();
                    //Form1.ActiveForm.Refresh();
                    d1.Refresh();

                    for (int i = 0; i < Labirinto.QUEIJOS; i++)
                    {
                        
                        if (Labirinto.rato.obtem_linhas() == Labirinto.queijo[i].obtem_linhas() &&
                            Labirinto.rato.obtem_colunas() == Labirinto.queijo[i].obtem_colunas())
                        {
                            Labirinto.queijo[i].define_linhas(1);
                            Labirinto.queijo[i].define_colunas(0);
                            Labirinto.define_queijo(Labirinto.QUEIJOS - 1);
                            cont++;
                            Labirinto.atualiza_passos(0);
                        }
                    }
                }
                while (cont != Labirinto.QUEIJOS2 && temp != Labirinto.TEMPO);

                if (temp == Labirinto.TEMPO)
                {
                    MessageBox.Show("Acabou o tempo");
                }
                else
                {
                    MessageBox.Show("Você achou todos os queijos");
                }
            }
            else
            {
                do
                {
                    TimeSpan depois = DateTime.Now - agora;
                    temp = depois.Minutes * 60;
                    temp = temp + depois.Seconds;
                    label10.Text = temp.ToString();

                    label10.Refresh();
                    Labirinto.tezeu();
                    desenhar_labirinto();
                    d1.Refresh();
                } while ((Labirinto.rato.obtem_linhas() != Labirinto.queijo[0].obtem_linhas() ||
                        Labirinto.rato.obtem_colunas() != Labirinto.queijo[0].obtem_colunas()) && temp != Labirinto.TEMPO);
                if (temp==Labirinto.TEMPO)
                {
                    MessageBox.Show("Acabou o tempo");
                }
                else
                {
                    MessageBox.Show("Você achou todos os queijos");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown5.Show();
            numericUpDown6.Show();
            label7.Show();
            label6.Show();
            panel1.Show();
            label5.Show();
            comboBox1.Hide();
            label8.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown5.Hide();
            numericUpDown6.Hide();
            label7.Hide();
            label6.Hide();
            panel1.Show();
            label5.Hide();
            comboBox1.Show();
            label8.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown5.Hide();
            numericUpDown6.Hide();
            label7.Hide();
            label6.Hide();
            panel1.Hide();
            label5.Hide();
            comboBox1.Hide();
            label8.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

    }

}
