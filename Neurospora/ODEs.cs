using System;
using System.ComponentModel;

namespace Neurospora
{
    public class ODEs : Solvable
    {
        private double[] M, Fc, Fn; // массивы для решений уравнений
        private double[] t; // массив для разбиения отрезка
        private double ht; // шаг по t

        private const double VALUE_THRESHOLD = 1E4;

        public ODEs() : base()
        {
            M0 = 1;
            Fc0 = 0.5;
            Fn0 = 0.5;
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

        public override void load()
        {
            ht = T / N;

            // выделение памяти под массивы
            M = new double[N];
            Fc = new double[N];
            Fn = new double[N];
            t = new double[N];

            // разбиение отрезка
            for (int j = 0; j < N; j++)
                t[j] = j * ht;
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
            double ki_n = Math.Pow(Ki, n);

            for (int j = 0; j < N - 1; j++)
            {
                /////////////////////////////////////////////////////////////////////
                // Euler's 2nd order                                               //
                double fn_j = fn(Fc[j], Fn[j]);
                double fntemp = Fn[j] + ht * fn_j;
                if (fntemp > VALUE_THRESHOLD)
                    return -1;

                double m_j = fm(M[j], Fn[j], ki_n);
                double mtemp = M[j] + ht * m_j;
                if (mtemp > VALUE_THRESHOLD)
                    return -1;

                double fc_j = fc(M[j], Fc[j], Fn[j]);
                double fctemp = Fc[j] + ht * fc_j;
                if (fctemp > VALUE_THRESHOLD)
                    return -1;

                M[j + 1] = M[j] + ht * 0.5 * (m_j + fm(mtemp, fntemp, ki_n));
                Fc[j + 1] = Fc[j] + ht * 0.5 * (fc_j + fc(mtemp, fctemp, fntemp));
                Fn[j + 1] = Fn[j] + ht * 0.5 * (fn_j + fn(fctemp, fntemp));
                //                                                                  //
                /////////////////////////////////////////////////////////////////////


                /////////////////////////
                //// Euler's 1st order //
                //double mtemp1 = fm(M[j], Fn[j], ki_n);
                //double mtemp = M[j] + ht * mtemp1;
                //if (mtemp > VALUE_THRESHOLD)
                //    return -1;
                //M[j + 1] = mtemp;

                //double fctemp1 = fc(M[j + 1], Fc[j], Fn[j]);
                //double fctemp = Fc[j] + ht * fctemp1;
                //if (fctemp > VALUE_THRESHOLD)
                //    return -1;
                //Fc[j + 1] = fctemp;

                //double fntemp1 = fn(Fc[j + 1], Fn[j]);
                //double fntemp = Fn[j] + ht * fntemp1;
                //if (fntemp > VALUE_THRESHOLD)
                //    return -1;
                //Fn[j + 1] = fntemp;
                ////                    //
                /////////////////////////
            }
            
            return 0;
        }

        // вспомогательные функции
        private double fm(double m, double fn, double ki_n)
        {
            return Vs * ki_n / (ki_n + Math.Pow(fn, n)) - Vm * m / (Km + m);
        }
        private double fc(double m, double fc, double fn)
        {
            return ks * m - Vd * fc / (Kd + fc) - k1 * fc + k2 * fn;
        }
        private double fn(double fc, double fn)
        {
            return k1 * fc - k2 * fn;
        }

        // геттеры для массивов
        public double getT(int j)
        { return t[j]; }
        public double getM(int j)
        { return M[j]; }
        public double getFc(int j)
        { return Fc[j]; }
        public double getFn(int j)
        { return Fn[j]; }
    }
}
