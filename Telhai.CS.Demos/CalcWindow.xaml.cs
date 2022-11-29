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
using System.Windows.Shapes;

namespace Telhai.CS.Demos
{

    enum Operator
    {
        Plus,Minus,Multiply,Divide 
    };


    /// <summary>
    /// Interaction logic for CalcWindow.xaml
    /// </summary>
    public partial class CalcWindow : Window
    {
        public List<string> allExpressions; //==null by default (ref type)

        public CalcWindow()
        {
            InitializeComponent();
            //--initilize list s inner class member
            allExpressions = new List<string>();
        }

        /// <summary>
        /// Fill Combo Box Items acording Enum names
        /// Loadded events is triggered after constractor and after all 
        /// visual items laytout in GUI and ready to display itself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {  
            //01.generte array of nmes from specific enum type
            string[] names =  Enum.GetNames(typeof(Operator));
            
            //02.Fill Enum values to Combo
            for (int i = 0; i < names.Length; i++)
            {
                comboBoxOperator.Items.Add(names[i]);
            }
            //03.Insert user Suggestion and select it 
            comboBoxOperator.Items.Insert(0,"Choose Operator");
            comboBoxOperator.SelectedIndex = 0;
        }

        /// <summary>
        /// Result Button Clicked handler
        /// -validate user inputs
        /// -calulate result
        /// -add expression text to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRes_Click(object sender, RoutedEventArgs e)
        {
            //required expression varients
            string msgError = "";
            int convertedNum1 =0;
            int convertedNum2 = 0;
            int result = 0;
            string operatorSign = "";
            
            //Validation
            //--Check Combobox is not 0
            if (this.comboBoxOperator.SelectedIndex == 0)
            {
                msgError += "*Operator  is not selected\n";
            }
            //--Check txt1 is not empty
            if (string.IsNullOrEmpty(this.txt1.Text))
            {
                msgError += "*Operand 1 is empty\n";
            }
            //--if not empty get actual value
            else
            {
               
                bool isOk = int.TryParse(this.txt1.Text,out convertedNum1);
                if (!isOk)
                {
                    msgError += "*Operand 1 is not number\n";
                }
            }
            //--Check txt2 is not empty
            if (string.IsNullOrEmpty(this.txt2.Text))
            {
                msgError += "*Operand 2 is empty\n";
            }
            //--if not empty get actual value
            else
            {
                bool isOk = int.TryParse(this.txt2.Text, out convertedNum2);
                if (!isOk)
                {
                    msgError += "*Operand 2 is not number\n";
                }
            }
            
            //--user inputs errors exsist  
            if (msgError!=string.Empty)
            {
                MessageBox.Show(msgError);
            }
            //no user inputs errors
            else
            {
                //--convert listbox index to enum (int->enum)
                Operator op =  (Operator)this.comboBoxOperator.SelectedIndex -1;
                switch (op)
                {
                    //--Calculte results
                    case (Operator.Plus):
                        {
                            result = convertedNum1 + convertedNum2;
                            operatorSign = "+";
                            break;
                        }
                    case (Operator.Minus):
                        {
                            result = convertedNum1 - convertedNum2;
                            operatorSign = "-";

                            break;
                        }
                    case (Operator.Multiply):
                        {
                            result = convertedNum1 * convertedNum2;
                            operatorSign = "*";
                            break;
                        }
                    default:
                            {
                            break;
                        }
                }

                //--build expression text
               string msgExpression = 
                    $"{convertedNum1}{operatorSign}{convertedNum2}={result}";

                //--Add expressionctext and result to listbox
                lstBoxExpressions.Items.Add(msgExpression);
                //--Add expression to public memory list (not visual list)
                //--for accessing from parent window 
                allExpressions.Add(msgExpression);
            }


        }

        private void lstBoxExpressions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
