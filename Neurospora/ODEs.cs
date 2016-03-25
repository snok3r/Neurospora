using System;
using System.IO;
using System.ComponentModel;

namespace Neurospora
{
    public class ODEs : Solvable
    {
        private double[] Vs; // массив для значений параметра
        private double[] M, Fc, Fn; // массивы для решений уравнений
  
        // служебные переменные
        private int switchPace;
        private bool darkVs;
        private bool isVsVariable;
        private const double VALUE_THRESHOLD = 1E4;

        public ODEs() : base()
        {
            M0 = 1;
            Fc0 = 0.5;
            Fn0 = 0.5;

            // выделение памяти под массивы
            M = new double[2];
            Fc = new double[2];
            Fn = new double[2];
            Vs = new double[] { 1.6, 2.0 }; // первый для постоянного/ночного режима
                                            // второй для дневного режима
            darkVs = false;
            isVsVariable = false;
        }

        // свойства
        [Description("Начальное значение M(0)")]
        [Category("Начальные условия")]
        public double M0
        {
            get;
            set;
        }

        [Description("Начальное значение Fc(0)")]
        [Category("Начальные условия")]
        public double Fc0
        {
            get;
            set;
        }

        [Description("Начальное значение Fn(0)")]
        [Category("Начальные условия")]
        public double Fn0
        {
            get;
            set;
        }

        // меняем постоянность/переменность Vs
        public void changeVsVariability()
        {
            isVsVariable = !isVsVariable;
        }

        public bool isVsVar() 
        { 
            return isVsVariable; 
        }

        public void setVs(int j, double val)
        {
            Vs[j] = val;
        }
        public double getVs(int j)
        {
            // если Vs постоянный
            if (!isVsVariable)
                return Vs[0];

            // каждые 12 часов переключаем режим
            if (j % switchPace == 0)
            {
                if (j / switchPace % 2 == 0)
                    darkVs = false;
                else
                    darkVs = true;
            }

            // если Vs переменный и режим ночной
            if (darkVs)
                return Vs[0];
            // если Vs переменный и режим дневной
            else
                return Vs[1];
        }
        public double getVs(bool darkVs)
        {
            if (darkVs)
                return Vs[0];
            else
                return Vs[1];
        }

        public override void load()
        {
            switchPace = (int)(12 / ht + 1);

            // разбиение отрезка
            Directory.CreateDirectory("tmp");
            StreamWriter swT = new StreamWriter("./tmp/T.ira", false);
            for (int j = 0; j <= (int)(T / ht); j++) 
                swT.WriteLine(j * ht);
            swT.Close();
        }

        public override void initials()
        {   // начальные условия
            M[0] = M0;
            Fc[0] = Fc0;
            Fn[0] = Fn0;
        }

        // возращает -1, если решение расходится,
        // в противном случае, возращает 0
        public override int solve()
        {
            StreamWriter swM = new StreamWriter("./tmp/M.ira", false);
            StreamWriter swFc = new StreamWriter("./tmp/Fc.ira", false);
            StreamWriter swFn = new StreamWriter("./tmp/Fn.ira", false);
            swM.WriteLine(M0); 
            swFc.WriteLine(Fc0); 
            swFn.WriteLine(Fn0);

            double ki_n = Math.Pow(Ki, n);

            for (int j = 0; j < (int)(T / ht); j++)
            {
                double fn_j = fn(Fc[j % 2], Fn[j % 2]);
                double fntemp = Fn[j % 2] + ht * fn_j;
                if (fntemp > VALUE_THRESHOLD)
                    return -1;

                double m_j = fm(M[j % 2], Fn[j % 2], ki_n, getVs(j));
                double mtemp = M[j % 2] + ht * m_j;
                if (mtemp > VALUE_THRESHOLD)
                    return -1;

                double fc_j = fc(M[j % 2], Fc[j % 2], Fn[j % 2]);
                double fctemp = Fc[j % 2] + ht * fc_j;
                if (fctemp > VALUE_THRESHOLD)
                    return -1;

                M[(j + 1) % 2] = M[j % 2] + ht * 0.5 * (m_j + fm(mtemp, fntemp, ki_n, getVs(j)));
                Fc[(j + 1) % 2] = Fc[j % 2] + ht * 0.5 * (fc_j + fc(mtemp, fctemp, fntemp));
                Fn[(j + 1) % 2] = Fn[j % 2] + ht * 0.5 * (fn_j + fn(fctemp, fntemp));

                swM.WriteLine(M[(j + 1) % 2]);
                swFc.WriteLine(Fc[(j + 1) % 2]);
                swFn.WriteLine(Fn[(j + 1) % 2]);
            }

            swM.Close();
            swFc.Close(); 
            swFn.Close();

            return 0;
        }

        // вспомогательные функции
        private double fm(double m, double fn, double ki_n, double vs)
        {
            return vs * ki_n / (ki_n + Math.Pow(fn, n)) - Vm * m / (Km + m);
        }
        private double fc(double m, double fc, double fn)
        {
            return ks * m - Vd * fc / (Kd + fc) - k1 * fc + k2 * fn;
        }
        private double fn(double fc, double fn)
        {
            return k1 * fc - k2 * fn;
        }
    }
}
