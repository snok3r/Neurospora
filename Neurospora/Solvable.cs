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
        [Category("Для решения")]
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
        [Category("Параметры")]
        public int n
        {
            get;
            set;
        }

        [Description("Интервал [0,T] (h)")]
        [Category("Для решения")]
        public double T
        {
            get;
            set;
        }

        [Description("(nM/h)")]
        [Category("Параметры")]
        public double Vs
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
