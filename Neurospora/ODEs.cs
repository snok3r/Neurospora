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

        public override int solve()
        {
            throw new NotImplementedException();

            return 0;
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
