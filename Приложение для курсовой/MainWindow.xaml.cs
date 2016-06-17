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

namespace Приложение_для_курсовой
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VilkiList.Items.Clear();
            ChordList.Items.Clear();
            TangentList.Items.Clear();
            numforVilki0 = 0;
            numforVilki1 = 0;
            numforVilki2 = 0;
            numforVilki3 = 0;

            numForChord0 = 0;
            numForChord1 = 0;
            numForChord2 = 0;
            numForChord3 = 0;

            numberforTangent0 = 0;
            numberforTangent1 = 0;
            numberforTangent2 = 0;
            numberforTangent3 = 0;


            double epsilon;
            double a, b;
            tbEpsilon.Text = tbEpsilon.Text.Replace('.', ',');
            if (comboBox.SelectedItem == null || !double.TryParse(tbEpsilon.Text.Trim(' '), out epsilon)) return;
            if (epsilon > 1) return;
            switch(comboBox.SelectedIndex)
            {
                case 0:
                    a = 0;
                    b = 0.5;
                    vilkiMethod0(a, b, epsilon);
                    ChordMethod0(a, b, epsilon);

                    if (fn0(a) * SecondDerivative0(a) > 0)
                    {
                        tangentMethod0(a, epsilon);
                    }
                    else
                    {
                        tangentMethod0(b, epsilon);
                    }
                    break;
                case 1:
                    a = 1;
                    b = 1.5;
                    vilkiMethod1(a, b, epsilon);
                    ChordMethod1(a, b, epsilon);


                    if (fn1(a) * SecondDerivative1(a) > 0)
                    {
                        tangentMethod1(a, epsilon);
                    }
                    else
                    {
                        tangentMethod1(b, epsilon);
                    }
                    break;
                case 2:
                    a = -1;
                    b = 0;
                    vilkiMethod2(a,b, epsilon);
                    ChordMethod2(a, b, epsilon);


                    if (fn2(a) * SecondDerivative2(a) > 0)
                    {
                        tangentMethod2(a, epsilon);
                    }
                    else
                    {
                        tangentMethod2(b, epsilon);
                    }
                    break;
                case 3:
                    a = 2.5;
                    b = 4;
                    vilkiMethod3(a, b, epsilon);
                    ChordMethod3(a, b, epsilon);


                    if (fn3(a) * SecondDerivative3(a) > 0)
                    {
                        tangentMethod3(a, epsilon);
                    }
                    else
                    {
                        tangentMethod3(b, epsilon);
                    }
                    break;


            }
           

        }

         int numberforTangent0 = 0;
        //Метод касательных 
         double tangentMethod0(double x, double eplison)
        {

            double res = x - (fn0(x) / firstDetirative0(x));
            TangentList.Items.Add((numberforTangent0 + 1) + ") " + res);
            numberforTangent0++;
            if (Math.Abs(x - res) < eplison)
                return res;
            return tangentMethod0(res, eplison);
        }

        int numberforTangent1 = 0;
        //Метод касательных 
        double tangentMethod1(double x, double eplison)
        {

            double res = x - (fn1(x) / firstDetirative1(x));
            TangentList.Items.Add((numberforTangent1 + 1) + ") " + res);
            numberforTangent1++;
            if (Math.Abs(x - res) < eplison)
                return res;
            return tangentMethod1(res, eplison);
        }

        int numberforTangent2 = 0;
        //Метод касательных 
        double tangentMethod2(double x, double eplison)
        {

            double res = x - (fn2(x) / firstDetirative2(x));
            TangentList.Items.Add((numberforTangent2 + 1) + ") " + res);
            numberforTangent2++;
            if (Math.Abs(x - res) < eplison)
                return res;
            return tangentMethod2(res, eplison);
        }

        int numberforTangent3 = 0;
        //Метод касательных 
        double tangentMethod3(double x, double eplison)
        {

            double res = x - (fn3(x) / firstDetirative3(x));
            TangentList.Items.Add((numberforTangent3 + 1) + ") " + res);

            numberforTangent3++;
            if (Math.Abs(x - res) < eplison)
                return res;
            return tangentMethod3(res, eplison);
        }



        int numforVilki0 = 0;

        public double vilkiMethod0(double a, double b, double epsilon)
        {
            double x = (a + b) / 2;
            VilkiList.Items.Add((numforVilki0+1) + ") " + x);

            numforVilki0++;

            if (fn0(x) == 0 || Math.Abs(b - a) < epsilon) return x;

            if (fn0(a) * fn0(x) < 0) return vilkiMethod0(a, x, epsilon);
            else return vilkiMethod0(x, b, epsilon);

        }

        int numforVilki1 = 0;

        public double vilkiMethod1(double a, double b, double epsilon)
        {
            double x = (a + b) / 2;
            VilkiList.Items.Add((numforVilki1 + 1) + ") " + x);

            numforVilki1++;

            if (fn1(x) == 0 || Math.Abs(b - a) < epsilon) return x;

            if (fn1(a) * fn1(x) < 0) return vilkiMethod1(a, x, epsilon);
            else return vilkiMethod1(x, b, epsilon);

        }

        int numforVilki2 = 0;

        public double vilkiMethod2(double a, double b, double epsilon)
        {
            double x = (a + b) / 2;
            VilkiList.Items.Add((numforVilki2 + 1) + ") " + x);

            numforVilki2++;

            if (fn2(x) == 0 || Math.Abs(b - a) < epsilon) return x;

            if (fn2(a) * fn2(x) < 0) return vilkiMethod2(a, x, epsilon);
            else return vilkiMethod2(x, b, epsilon);

        }

        int numforVilki3 = 0;

        public double vilkiMethod3(double a, double b, double epsilon)
        {
            double x = (a + b) / 2;
            VilkiList.Items.Add((numforVilki3 + 1) + ") " + x);

            numforVilki3++;

            if (fn3(x) == 0 || Math.Abs(b - a) < epsilon) return x;

            if (fn3(a) * fn3(x) < 0) return vilkiMethod3(a, x, epsilon);
            else return vilkiMethod3(x, b, epsilon);

        }

        int numForChord0 = 0;
        //Метод хорд
         double ChordMethod0(double a, double b, double eplison)
        {

            if (fn0(b) * SecondDerivative0(b) > 0)
            {
                double res = a - fn0(a) * (b - a) / (fn0(b) - fn0(a));
                ChordList.Items.Add((numForChord0 + 1) + ") " + res);
                numForChord0++;
                if (Math.Abs(res - a) < eplison)
                    return res;
                return ChordMethod0(res, b, eplison);
            }
            else
            {
                double res = a + fn0(a) * (b - a) / (fn0(a) - fn0(b));
                ChordList.Items.Add((numForChord0 + 1) + ") " + res);

                numForChord0++;
                if (Math.Abs(res - b) < eplison)
                    return res;
                return ChordMethod0(a, res, eplison);
            }

        }

        int numForChord1 = 0;
        //Метод хорд
        double ChordMethod1(double a, double b, double eplison)
        {

            if (fn1(b) * SecondDerivative1(b) > 0)
            {
                double res = a - fn1(a) * (b - a) / (fn1(b) - fn1(a));
                ChordList.Items.Add((numForChord1 + 1) + ") " + res);

                numForChord1++;
                if (Math.Abs(res - a) < eplison)
                    return res;
                return ChordMethod1(res, b, eplison);
            }
            else
            {
                double res = a + fn1(a) * (b - a) / (fn1(a) - fn1(b));
                ChordList.Items.Add((numForChord1 + 1) + ") " + res);

                numForChord1++;
                if (Math.Abs(res - b) < eplison)
                    return res;
                return ChordMethod1(a, res, eplison);
            }

        }

        int numForChord2 = 0;
        //Метод хорд
        double ChordMethod2(double a, double b, double eplison)
        {

            if (fn2(b) * SecondDerivative2(b) > 0)
            {
                double res = a - fn2(a) * (b - a) / (fn2(b) - fn2(a));
                ChordList.Items.Add((numForChord2 + 1) + ") " + res);

                numForChord2++;
                if (Math.Abs(res - a) < eplison)
                    return res;
                return ChordMethod2(res, b, eplison);
            }
            else
            {
                double res = a + fn2(a) * (b - a) / (fn2(a) - fn2(b));
                ChordList.Items.Add((numForChord2 + 1) + ") " + res);

                numForChord2++;
                if (Math.Abs(res - b) < eplison)
                    return res;
                return ChordMethod2(a, res, eplison);
            }

        }

        int numForChord3 = 0;
        //Метод хорд
        double ChordMethod3(double a, double b, double eplison)
        {

            if (fn3(b) * SecondDerivative3(b) > 0)
            {
                double res = a - fn3(a) * (b - a) / (fn3(b) - fn3(a));
                ChordList.Items.Add((numForChord3 + 1) + ") " + res);

                numForChord3++;
                if (Math.Abs(res - a) < eplison)
                    return res;
                return ChordMethod3(res, b, eplison);
            }
            else
            {
                double res = a + fn3(a) * (b - a) / (fn3(a) - fn3(b));
                ChordList.Items.Add((numForChord3 + 1) + ") " + res);

                numForChord3++;
                if (Math.Abs(res - b) < eplison)
                    return res;
                return ChordMethod3(a, res, eplison);
            }

        }



        //2*x-4x=0
        public double fn0(double x)
        {
            return Math.Pow(2, x) - 4 * x;

        }
        public double firstDetirative0(double x)
        {
            return Math.Pow(2, x) * Math.Log(2) - 4;

        }
        public double SecondDerivative0(double x)
        {
            return Math.Pow(2, x) * Math.Log(2) * Math.Log(2);
        }
        //
        //x^3+4x-6=0
        public double fn1(double x)
        {
            return Math.Pow(x, 3) + 4 * x - 6;

        }
        public double firstDetirative1(double x)
        {
            return 3 * x * x + 4;

        }
        public double SecondDerivative1(double x)
        {
            return 6 * x;
        }
        //

        //x^3 + 3x + 2.2=0
        public double fn2(double x)
        {
            return Math.Pow(x, 3) + 3 * x + 2.2;

        }
        public double firstDetirative2(double x)
        {
            return 3 * x * x + 3;

        }
        public double SecondDerivative2(double x)
        {
            return 6 * x;
        }
        //

        //для функции x3−x2−9x+9=0 
        public double fn3(double x)
        {
            return x * x * x - x * x - 9 * x + 9;

        }
        public double firstDetirative3(double x)
        {
            return 3 * x * x - 2 * x - 9;

        }
        public double SecondDerivative3(double x)
        {
            return 6 * x - 2;
        }
        //

      

    }
}
