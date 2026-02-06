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
using System.Windows.Threading;

namespace 계산기_2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool op_after;
        //op_after = true (처음치는 숫자랑 연결)
        //op_after = false (화면을 지우고 새로운 숫자를 적음)
        private double? l_vaule;
        private double? r_value;
        private char m_op;
        DispatcherTimer myTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            txtResult.Text = "0";
            txtResult.TextAlignment = TextAlignment.Right;
            myTimer.Interval = new TimeSpan(0, 0, 1);
            myTimer.Tick += myTimer_Tick;
        

            myTimer.Start();

        }

        void myTimer_Tick(object sender , EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString();
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            // 클릭된 객체를 버튼타입으로 변환

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
                // op_after는 bool형을 사용하여 기본값이 false
                {
                    txtResult.Text = btn_str;
                    op_after = false;   
                }
                else
                {
                    txtResult.Text += btn_str;
                }
            }

              else if("+-x%".Contains(btn_str))
              {

                try
                {
                    l_vaule = double.Parse(txtResult.Text);
                    m_op = btn_str[0];
                    op_after = true;
                    txtResult.Text += btn_str;
                    txtExpression.Text = l_vaule + "" + m_op;
                }

                catch(Exception ex)
                {
                    MessageBox.Show("연산자는 한번만 입력");
                }


              }
            else if(".".Contains(btn_str))
            {
                try
                {
                    if (txtResult.Text == "0")
                    {
                        txtResult.Text = "0.";
                        op_after = false;
                    }

                    else if (double.Parse(txtResult.Text) == (int)(double.Parse(txtResult.Text)))
                    // 정수일떄만 소수점 찍기가능
                    {
                        txtResult.Text += ".";
                    }
                }

                catch(Exception ex)
                {
                    MessageBox.Show("연속입력 X");
                }
            }

            else if("backCE".Contains(btn_str))
            {
                if(btn.Content.ToString() == "back")
                {
                    txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);

                    if(txtResult.Text.Length ==0)
                    {
                        txtResult.Text = "0";
                    }
                }

                if(btn.Content.ToString()=="CE")
                {
                    txtResult.Text = "0";

                    
                }
            }

            else if("End".Contains(btn_str))
            {
                Close();
            }

              else if ("=".Contains(btn_str))
            {
                r_value = double.Parse(txtResult.Text);
                double result = 0;

                switch (m_op)
                {
                    case '+':
                        result = (double)l_vaule + (double)r_value;
                        break;

                    case '-':
                        result = (double)l_vaule - (double)r_value;
                        break;

                    case 'x':
                        result = (double)l_vaule * (double)r_value;
                        break;


                    case '%':
                        result = (double)l_vaule % (double)r_value;
                        break;


                }

                txtResult.Text = result.ToString();
                l_vaule = result;
                op_after = true;

            }



        }

        
    }
}
