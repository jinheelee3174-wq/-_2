using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 계산기_2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool op_after;
        private double? l_vaule;
        private double? r_value;
        private char m_op;

        public MainWindow()
        {
            InitializeComponent();

            txtResult.Text = "0";
            txtResult.TextAlignment = TextAlignment.Right;

        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            string btn_str = btn.Content.ToString();

            if(btn_str == "C")
            {
                txtResult.Text = "0";
                l_vaule = null;
                r_value = null;
                m_op = '\0';
                op_after = false;

            }

            else if("0123456789".Contains(btn_str))
            {
                if(txtResult.Text == "0" || op_after)
                {
                    txtResult.Text = btn_str;
                    op_after = false;
                }
                else
                {
                    txtResult.Text += btn_str;
                }
            }

              else if("+-X/%".Contains(btn_str))
              {
                  l_vaule = double.Parse(txtResult.Text);
                  m_op = btn_str[0];
                  op_after = true;
                  


              }

              else if("=".Contains(btn_str))
              {
                  r_value = double.Parse(txtResult.Text);
                  double result = 0;

                  switch(m_op)
                  {
                      case '+':
                                    result = (double)l_vaule + (double)r_value;
                                    break;

                      case '-':
                                    result = (double)l_vaule - (double)r_value;
                                    break;

                      case 'X':
                                    result = (double)l_vaule * (double)r_value;
                                    break;
             

                      case '/':
                                    result = (double)l_vaule / (double)r_value;
                                    break;
                        
             

                      case '%':
                                    result = (double)l_vaule % (double)r_value;
                                    break;
             

                  }

                  txtResult.Text = result.ToString();
                  l_vaule = result;
                  op_after = true;

              }
            /


        }

        
    }
}
