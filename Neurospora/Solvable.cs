using System.ComponentModel;

namespace Neurospora
{
    public abstract class Solvable
    {
        public abstract void load();
        public abstract void initials();
        public abstract int solve();

        // конструктор
        protected Solvable()
        {
            ht = 0.01;
            T = 72;
            
            n = 4;
            
            Vm = 0.505; 
            Vd = 1.4;

            ks = 0.5;
            k1 = 0.5;
            k2 = 0.6;

            Km = 0.5;
            Ki = 1;
            Kd = 0.13;
        }

        // переменные для свойств
        private double varHt;

        [Description("Шаг в сетке по t")]
        [Category("Для решения")]
        public double ht
        {
            get { return varHt; }
            set
            {
                if (value > 0)
                    varHt = value;
            }
        }

        [Description("Интервал [0,T] (h)")]
        [Category("Для решения")]
        public double T
        {
            get;
            set;
        }

        [Description("Степень")]
        [Category("Параметры")]
        public int n
        {
            get;
            set;
        }

        [Description("(nM/h)")]
        [Category("Параметры")]
        public double Vm
        {
            get;
            set;
        }

        [Description("(nM/h)")]
        [Category("Параметры")]
        public double Vd
        {
            get;
            set;
        }

        [Description("(nM)")]
        [Category("Параметры")]
        public double Ki
        {
            get;
            set;
        }

        [Description("(nM)")]
        [Category("Параметры")]
        public double Km
        {
            get;
            set;
        }

        [Description("(nM)")]
        [Category("Параметры")]
        public double Kd
        {
            get;
            set;
        }

        [Description("(1/h)")]
        [Category("Параметры")]
        public double k1
        {
            get;
            set;
        }

        [Description("(1/h)")]
        [Category("Параметры")]
        public double k2
        {
            get;
            set;
        }

        [Description("(1/h)")]
        [Category("Параметры")]
        public double ks
        {
            get;
            set;
        }
    }
}
