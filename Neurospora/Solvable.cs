using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Neurospora
{
    abstract class Solvable
    {
        public abstract void load();
        public abstract void initials();
        public abstract int solve();

        // конструктор
        protected Solvable()
        {
            N = 10000;
            T = 72;

            n = 4;
            
            Vm = 0.505; 
            Vd = 1.4;
            Vs = 1.6;

            ks = 0.5;
            k1 = 0.5;
            k2 = 0.6;

            Km = 0.5;
            Ki = 1;
            Kd = 0.13;
        }

        // переменные для свойств
        private int varN;

        // свойства
        [Description("Кол-во точек по t")]
        public int N
        {
            get { return varN; }
            set
            {
                if (value > 10)
                    varN = value;
            }
        }

        [Description("Степень")]
        public int n
        {
            get;
            set;
        }

        [Description("Интервал [0,T] (h)")]
        public double T
        {
            get;
            set;
        }

        [Description("(nM/h)")]
        public double Vs
        {
            get;
            set;
        }

        [Description("(nM/h)")]
        public double Vm
        {
            get;
            set;
        }

        [Description("(nM/h)")]
        public double Vd
        {
            get;
            set;
        }

        [Description("(nM)")]
        public double Ki
        {
            get;
            set;
        }

        [Description("(nM)")]
        public double Km
        {
            get;
            set;
        }

        [Description("(nM)")]
        public double Kd
        {
            get;
            set;
        }

        [Description("(1/h)")]
        public double k1
        {
            get;
            set;
        }

        [Description("(1/h)")]
        public double k2
        {
            get;
            set;
        }

        [Description("(1/h)")]
        public double ks
        {
            get;
            set;
        }
    }
}
