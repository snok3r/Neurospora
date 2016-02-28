using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurospora
{
    class ODEs : Solvable
    {
        private double[] M, Fc, Fn; // массивы для решений уравнений
        private double[] t; // массив для разбиения отрезка
        private double ht; // шаг по t

        public ODEs() : base()
        {
            M0 = 1;
            Fc0 = 1;
            Fn0 = 1;
        }

        // свойства
        public double M0
        {
            get;
            set;
        }
        public double Fc0
        {
            get;
            set;
        }
        public double Fn0
        {
            get;
            set;
        }

        public override void load()
        {
            ht = T / N;

            t = new double[N];

            // разбиение отрезка
            for (int j = 0; j < N; j++)
                t[j] = j * ht;

            // выделение памяти под массивы
            M = new double[N];
            Fc = new double[N];
            Fn = new double[N];
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
                double fntemp1 = fn(Fc[j], Fn[j]);
                double fntemp = Fn[j] + ht * fntemp1;
                if (Double.IsNaN(fntemp))
                    return -1;

                double mtemp1 = fm(M[j], Fn[j], ki_n);
                double mtemp = M[j] + ht * mtemp1;
                if (Double.IsNaN(mtemp))
                    return -1;
                M[j + 1] = M[j] + ht * 0.5 * (mtemp1 + fm(mtemp, fntemp, ki_n));

                double fctemp1 = fc(M[j + 1], Fc[j], Fn[j]);
                double fctemp = Fc[j] + ht * fctemp1;
                if (Double.IsNaN(fctemp))
                    return -1;
                Fc[j + 1] = Fc[j] + ht * 0.5 * (fctemp1 + fc(mtemp, fctemp, fntemp));

                Fn[j + 1] = Fn[j] + ht * 0.5 * (fntemp1 + fn(fctemp, fntemp));
                //                                                                  //
                /////////////////////////////////////////////////////////////////////


                /////////////////////////
                //// Euler's 1st order //
                //double mtemp1 = fm(M[j], Fn[j], ki_n);
                //double mtemp = M[j] + ht * mtemp1;
                //if (Double.IsNaN(mtemp))
                //    return -1;
                //M[j + 1] = mtemp;

                //double fctemp1 = fc(M[j + 1], Fc[j], Fn[j]);
                //double fctemp = Fc[j] + ht * fctemp1;
                //if (Double.IsNaN(fctemp))
                //    return -1;
                //Fc[j + 1] = fctemp;

                //double fntemp1 = fn(Fc[j + 1], Fn[j]);
                //double fntemp = Fn[j] + ht * fntemp1;
                //if (Double.IsNaN(fntemp))
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
