using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class Form1 : Form
    {
        public static bool mark1 = false;//用于判断一个数字是否只有一个小数点
        public static bool mark2 = false;//用于判断是否只有一个等号
        public Form1()
        {
            InitializeComponent();
        }
        //&& !Regex.IsMatch(textBox2.Text, @"\)+$")
        public bool Isnumok()//若非第一个数字且text1没有运算符或者text2以“）”结尾，不能输入数字,除非删除导致text2以运算符结尾
        {
            if (textBox2.Text == "" || textBox1.Text != ""|| Regex.IsMatch(textBox2.Text, "（+|-|×|÷）+$") ||
                Regex.IsMatch(textBox2.Text, @"\(+$"))
                return true;
            else
                return false;
        }
        public void Text1_disp(int num) //以字符串的形式在文本框显示
        {
            textBox1.Text = textBox1.Text + num.ToString();
        }
        private void Button12_Click(object sender, EventArgs e)//归零
        {     
            textBox1.Text = "";
            textBox2.Text = "";
            mark1 = false;
            mark2 = false;
        }
        public bool Isop()//判断文本框1是否是只有运算符
        {
            if (textBox1.Text != "") //如果文本框1不为空
            {
                string ch = textBox1.Text.Substring(textBox1.Text.Length - 1, 1);//提取表达式最后一个字符
                if (ch == "+" || ch == "-" || ch == "×" || ch == "÷")
                {
                    return true;
                }
            }
            return false;
        }
        private void Button1_Click(object sender, EventArgs e)//1
        {
            if(Isnumok())
            Text1_disp(1);
        }
        private void Button2_Click(object sender, EventArgs e)//2
        {
            if (Isnumok())
                Text1_disp(2);
        }
        private void Button3_Click(object sender, EventArgs e)//3
        {
            if (Isnumok())
                Text1_disp(3);
        }
        private void Button4_Click(object sender, EventArgs e)//4
        {
            if (Isnumok())
                Text1_disp(4);
        }
        private void Button5_Click(object sender, EventArgs e)//5
        {
            if (Isnumok())
                Text1_disp(5);
        }
        private void Button6_Click(object sender, EventArgs e)//6
        {
            if (Isnumok())
                Text1_disp(6);
        }
        private void Button7_Click(object sender, EventArgs e)//7
        {
            if (Isnumok())
                Text1_disp(7);
        }
        private void Button8_Click(object sender, EventArgs e)//8
        {
            if (Isnumok())
                Text1_disp(8);
        }
        private void Button9_Click(object sender, EventArgs e)//9
        {
            if (Isnumok())
                Text1_disp(9);
        }
        private void Button13_Click(object sender, EventArgs e)//0
        {
            if (Isnumok())
                Text1_disp(0);
        }
        private void Button14_Click(object sender, EventArgs e)//逗号
        {
            string str = textBox1.Text;//.Substring(textBox1.Text.Length - 1, 1);//提取最后一位字符，因为没有数字时最后一位就是运算符或空
            if (str == "" || str == "+" || str == "-" || str == "×" || str == "÷")
            { textBox1.Text += "0."; }
            else if (!mark1)//如果已经使用，则不改变文本框
                textBox1.Text += ".";
            mark1 = true;//标记一个数字已使用逗号
        }
        private void Button10_Click(object sender, EventArgs e)//加号
        {
            mark1 = false;
            if (!Regex.IsMatch(textBox1.Text, "="))
            {
                if (!Isop())//如果文本框1不是只有运算符则加到文本框2中
                {
                    textBox2.Text += textBox1.Text;
                }
                //运算符不出现在表达式第一位及左括号后面或等式后面
                if (textBox2.Text == "" || textBox2.Text.EndsWith("("))
                { textBox1.Text = ""; }
                else
                    textBox1.Text = "+";
            }
        }
        private void Button16_Click(object sender, EventArgs e)//减号
        {
            mark1 = false;//新数字未使用小数点
            if (!Regex.IsMatch(textBox1.Text, "="))
            {
                if (!Isop())//如果文本框1不是只有运算符则加到文本框2中
                {
                    textBox2.Text += textBox1.Text;
                }
                if (textBox2.Text == "" || textBox2.Text.EndsWith("("))
                {
                    textBox1.Text = "0-";
                }
                else
                    textBox1.Text = "-";
            }
        }
        private void Button11_Click(object sender, EventArgs e) //乘号
        {
            mark1 = false;
            if (!Regex.IsMatch(textBox1.Text, "="))
            {
                if (!Isop())//如果文本框1不是只有运算符则加到文本框2中
                {
                    textBox2.Text += textBox1.Text;
                }
                if (textBox2.Text == "" || textBox2.Text.EndsWith("(")) { textBox1.Text = ""; }
                else
                    textBox1.Text = "×";
            }
        }
        private void Button17_Click(object sender, EventArgs e)  //除号
        {
            mark1 = false;
            if (!Regex.IsMatch(textBox1.Text, "="))
            {
                if (!Isop())//如果文本框1不是只有运算符则加到文本框2中
                {
                    textBox2.Text += textBox1.Text;
                }
                if (textBox2.Text == "" || textBox2.Text.EndsWith("(")) { textBox1.Text = ""; }
                else textBox1.Text = "÷";
            }
        }
        private void Button20_Click(object sender, EventArgs e) // 左括号(
        {
            string str = textBox1.Text;
            //左括号前面只能为空或者运算符
            if (!Regex.IsMatch(textBox1.Text, "="))
                if (str == "+" || str == "-" || str == "×" || str == "÷" || str=="" && textBox2.Text == "")
            {
                textBox2.Text += textBox1.Text + "(";
                textBox1.Text = "";
            }
            
        }
        private void Button19_Click(object sender, EventArgs e)  // 右括号)
        {
            
            //前面只能为数字或者小数点
            //char ch;
            //ch = Convert.ToChar(textBox1.Text.Substring(textBox1.Text.Length - 1, 1));
            string str = textBox1.Text;
            if (!Regex.IsMatch(textBox1.Text, "="))
                if (Regex.IsMatch(str, "[0-9]+$") || str.EndsWith("."))
            {
                textBox2.Text += textBox1.Text + ")";
                textBox1.Text = "";
            }
        }
        private void Button21_Click(object sender, EventArgs e)//吐槽
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }
        private void Button22_Click(object sender, EventArgs e)//退出
        {
            Application.Exit();
        }
        private void Button15_Click(object sender, EventArgs e) //delete删除末尾,从文本1开始删
        {
            if (textBox1.Text == "")
            {//如果文本1空了开始删文本2
                if (textBox2.Text != "")
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }
            else
            {
                if (textBox1.Text.Length <= 1)//删完或者只有运算符
                { mark1 = false; }
                if (textBox1.Text != "")
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                if (textBox1.Text == "") { mark2 = false; }
            }
        }

        private void Button18_Click(object sender, EventArgs e)//等号=
        {     if (!mark2)
            {
                textBox2.Text += textBox1.Text;
            }
            textBox1.Text = "=";

            Stack<double> stackA = new Stack<double>();//存储运算数
            Stack<char> stackB = new Stack<char>();//存储运算符
            string str = textBox2.Text+"=",sch;//str储存表达式,=表示结尾，sch存储str单个字符
            double a = 0,b=0;//a暂时储存数字,b运算
            string snum = "", ch2="a";//存储字符型数字,运算符.ch2存放上一个字符
            char op;
            int numcount = 0, opcount = 0,pair=0;//记录运算数及操作符的数量，以判断是否合法
            //分别将操作数与运算符入栈,首先提取
            foreach (char ch in str)
            {
                sch = Convert.ToString(ch);
                if (Regex.IsMatch(sch, "[0-9]")||sch==".")//如果sch为0—9或者.
                { 
                    snum+=sch;
                }
                else//当开始出现非数字时
                {   //ch2!="a"&&ch2!="("&&ch2!=")")//如果运算符前面为括号则不需要入栈,如果第一个为非数字不需要入栈
                    if ((Regex.IsMatch(ch2, "[0-9]") || ch2 == ".")&&ch2!="a")//只有运算符前面是数据时才需要入栈,若第一个就是操作符也不需要入栈
                    {
                        a = Convert.ToDouble(snum);//将snum转换为double型数字入栈
                        stackA.Push(a);//将数字a入栈 
                        a = 0;//重置a
                        snum = "";//重置snum
                        numcount++;
                    }
                   opcount++;
                    if (ch == '+' || ch == '-')//如果为加、减则栈顶运算符可以运算了
                    {
                        if (stackB.Count == 0)//表示还没有运算符，则入栈
                        {
                            stackB.Push(ch);
                        }
                        else
                        {//()//stackB.Count!=0&&
                            while (stackB.Peek() == '×' || stackB.Peek() == '÷' || stackB.Peek() == '×' || stackB.Peek() == '÷')
                            {//取出运算符和两个数字
                                op = stackB.Pop();
                                a = stackA.Pop();
                                b = stackA.Pop();
                                stackA.Push(Cal(b, a, op));
                            }
                            stackB.Push(ch);
                        }
                        /* if (stackB.Count != 0)
                         {
                             if (stackB.Peek() == '(' || stackB.Peek() == ')')//!Regex.IsMatch(stackB.Peek().ToString(), "(+|-|×|÷)")
                             {//还没有操作运算符，则入栈
                                 stackB.Push(ch);
                             }
                             else
                             {   //如果有其他操作运算符则先运算
                                 //(stackB.Count!=0)//********************************
                                 while (stackB.Peek() == '+' || stackB.Peek() == '-' || stackB.Peek() == '×' || stackB.Peek() == '÷')
                                 {
                                     op = stackB.Pop();//取出运算符和两个数字
                                     a = stackA.Pop();
                                     b = stackA.Pop();
                                     stackA.Push(Cal(b, a, op));
                                 }
                                 stackB.Push(ch);//运算后将该运算符入栈
                             }
                         }
                         else
                         { //还没有运算符，则入栈
                             stackB.Push(ch);
                         }
                         */
                    }
                    else if (ch == '×' || ch == '÷')
                    {
                        if (stackB.Count == 0)//表示还没有运算符，则入栈
                        {
                            stackB.Push(ch);
                        }
                        else
                        {
                            while (stackB.Peek() == '×' || stackB.Peek() == '÷')
                            {
                                op = stackB.Pop();//取出运算符和两个数字
                                a = stackA.Pop();
                                b = stackA.Pop();
                                stackA.Push(Cal(b, a, op));
                            }
                            stackB.Push(ch);//直到为加减或无才入栈
                        }
                    }
                    else if (ch == '(')
                    {
                        stackB.Push(ch);//左括号直接入栈
                        opcount--;
                        pair++;
                    }
                    else if (ch == ')')//是右括号，则计算第一个左括号前的所有操作符，最后将此左括号直接弹出
                    {
                        pair--;
                        while (stackB.Peek() != '(')
                        {
                            op = stackB.Pop();//取出运算符和两个数字
                            a = stackA.Pop();
                            b = stackA.Pop();
                            stackA.Push(Cal(b, a, op));
                            /*
                            if (stackB.Count==0)
                            {
                                MessageBox.Show("表达式有误", "错误提示");
                                break;
                            }
                            */
                        }
                        op = stackB.Pop();//弹出（
                    }
                }
             ch2 = sch;
            }
           /* for(int i=0;i< str.Length;i++)
            {
                string ch=Convert.ToString(str[i]);//转为字符串型 
                while (Regex.IsMatch(ch, "[0-9]") || str[i] =='.')//是否为数字
                {
                    //为数字或者小数点时累加
                    snum += ch;
                    i++;
                }
                a = Convert.ToDouble(snum);

            }*/
            while(stackB.Count!=0)//如果运算符栈不为空计算剩下的
            {
                op = stackB.Pop();
                a = stackA.Pop();
                b = stackA.Pop();
                stackA.Push(Cal(b, a, op));
            }
        
            /*if(numcount==opcount&&pair==0)
            {
                a = stackA.Pop();
                textBox1.Text +=  Convert.ToString(a);
            }
            else
            {
                MessageBox.Show("表达式有误", "错误提示");
            }*/
            a = stackA.Pop();
            textBox1.Text += Convert.ToString(a);
            mark2 = true;
        }

        public double Cal(double a,double b,char op)//运算函数
        {
            switch(op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '×': return a * b;
                case '÷': return 1.0*a / b;
                default:return 0;
            }
        }
    }
}
