using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Подключение параллельный вычислений
using System.Threading;
using System.Threading.Tasks;

namespace ParallelComputingSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Start();

        }
        //Список элементов управления 'ProgressBar'
        private List<ProgressBar> m_ThreadRaceBars;
        //Список элементов управления 'TextBox' для вывода статистики
        private List<TextBox> m_ThreadRaceTextBoxes;
        


        public void Start()
        {
            //Инициализация элементов управления
            if (m_ThreadRaceBars != null)
            {
                foreach (ProgressBar _bar in m_ThreadRaceBars)
                    this.tabPageThreadsRace.Controls.Remove(_bar);

                m_ThreadRaceBars.Clear();
            }
            else
            {
                m_ThreadRaceBars = new List<ProgressBar>();
            }

            if (m_ThreadRaceTextBoxes != null)
            {
                foreach (TextBox _txt in m_ThreadRaceTextBoxes)
                    this.tabPageThreadsRace.Controls.Remove(_txt);

                m_ThreadRaceTextBoxes.Clear();
            }
            else
            {
                m_ThreadRaceTextBoxes = new List<TextBox>();
            }

            //Количество потоков
            int _ThreadsCount = 9;
            //Длина бара
            int _RaceLength = 100;

            //Размещение элементов управления
            for (int i = 0; i < _ThreadsCount; i++)
            {
                ProgressBar _bar = new ProgressBar() { Minimum = 0, Maximum = _RaceLength, Value = 0, Left = 5, Top = 5 + i * 25, Width = btnStartThreadRace.Left - 170, Height = 20 };
                TextBox _txt = new TextBox() { Left = 565 , Top = _bar.Top, Width = 170, Height = _bar.Height };

                this.tabPageThreadsRace.Controls.Add(_bar);
                this.tabPageThreadsRace.Controls.Add(_txt);

                _bar.Visible = true;
                _txt.Visible = true;

                m_ThreadRaceBars.Add(_bar);
                m_ThreadRaceTextBoxes.Add(_txt);
            }
        }
    
             //Старт
        private void btnStartThreadRace_Click(object sender, EventArgs e)
        {
            ProcessInit();
           
        }
        private void ProcessInit()
        {
            Process _competitor;
            bool[] R = { false, false, false };
            bool[] result = { false, false, false, false,false,false,false,false};
            bool[] isStarted = { false, false, false, false, false, false, false, false,false };
            bool[] isCompleted = { false, false, false, false, false, false, false, false, false };
            _competitor = new Process(0,1,R,result,isCompleted, isStarted);

            Thread _Thread = new Thread(ProcessA);
            //Все создаваемые потоки - фоновые и завершаются вместе с основным приложением
            _Thread.IsBackground = true;
            //Старт
            _Thread.Start(_competitor);


        }
        //Потоки
        private void ProcessA(object state)
        {
            
            Process _competitor = (Process)state;
            ProgressBar _bar = m_ThreadRaceBars[_competitor.Index];
            TextBox _txt = m_ThreadRaceTextBoxes[_competitor.Index];
            BooleanGenerator boolGen = new BooleanGenerator();
            _competitor.isStarted[0] = true;
            //Основной цикл
            while (_bar.Value < _bar.Maximum)
            {
                if (_competitor.Speed < _competitor.MaxSpeed)
                {
                    _competitor.R[0] = boolGen.NextBoolean();
                    _competitor.R[1] = boolGen.NextBoolean();
                    _competitor.R[2] = boolGen.NextBoolean();
                    _txt.Text = "A: R1=" + _competitor.R[0].ToString() 
                        + " R2=" + _competitor.R[1].ToString() + " R3=" + _competitor.R[2].ToString();
                }
                int _newValue = _bar.Value + 100 / _competitor.MaxSpeed*25;
                _competitor.Accelerate();
                //Обновление элементов управления в потоке пользовательского интерфейса
                //В качестве параметра передаем экземпляр Delegate, параметризованного лямбда - выражением.
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));
                Thread.Sleep(800);                
            }
            _competitor.isCompleted[0] = true;            
            _competitor.isStarted[0] = false;
            {
                for (int i = 1; i < 4; i++)
                {
                    if (i == 1)
                    {
                        Thread _Thread1;
                        Process _competitor1 = new Process(i, 2, _competitor.R, 
                            _competitor.result,_competitor.isCompleted,_competitor.isStarted);
                        _Thread1 = new Thread(MakeProcess);
                        _Thread1.IsBackground = true;
                        _Thread1.Start(_competitor1);
                    }
                    else if (i == 3)
                    {
                        Thread _Thread3;
                        Process _competitor3 = new Process(i, 2, _competitor.R,
                            _competitor.result, _competitor.isCompleted, _competitor.isStarted);
                        _Thread3 = new Thread(MakeProcess);
                        _Thread3.IsBackground = true;
                        _Thread3.Start(_competitor3);
                    }
                    else
                    {
                        Thread _Thread2;
                        Process _competitor2 = new Process(i, 1, _competitor.R,
                            _competitor.result, _competitor.isCompleted, _competitor.isStarted);
                        _Thread2 = new Thread(MakeProcess);
                        _Thread2.IsBackground = true;
                        _Thread2.Start(_competitor2);
                    }

                }
            }
        }
        private void MakeProcess(object state)
        {
            Process _competitor = (Process)state;
            ProgressBar _bar = m_ThreadRaceBars[_competitor.Index];
            TextBox _txt = m_ThreadRaceTextBoxes[_competitor.Index];
            int sleep = 0;
            _competitor.isStarted[_competitor.Index] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_competitor.Speed < _competitor.MaxSpeed)
                {
                    switch(_competitor.Index)
                    {
                        case 1:
                            {
                                _competitor.result[_competitor.Index - 1] = 
                                    _competitor.R[0] & _competitor.R[1] & _competitor.R[2];
                                _txt.Text = 
                                    "B: F1=" + _competitor.result[_competitor.Index - 1].ToString();
                                sleep = 400;
                                break;
                            }
                        case 2:
                            {
                                _competitor.result[1] = _competitor.R[0] | _competitor.R[1] | _competitor.R[2];
                                _txt.Text = "C: F2=" + _competitor.result[1].ToString();
                                sleep = 300;
                                break;
                            }
                        case 3:
                            {
                                _competitor.result[_competitor.Index - 1] =
                                    _competitor.R[0] | _competitor.R[1] & _competitor.R[2];
                                _txt.Text =
                                    "D: F3=" + _competitor.result[_competitor.Index - 1].ToString();
                                sleep = 400;
                                break;
                            }
                        default:
                            break;
                    }
                }
                _competitor.Accelerate();
                int _newValue = _bar.Value + 100 / _competitor.MaxSpeed;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));

                Thread.Sleep(sleep);
            }
            _competitor.isCompleted[_competitor.Index] = true;
            _competitor.isStarted[_competitor.Index] = false;

            
            if (_competitor.isCompleted[2])
            {
                Thread _Thread4;
                Process _competitor4 = new Process(4, 1, _competitor.R,
                    _competitor.result, _competitor.isCompleted, _competitor.isStarted);
                _Thread4 = new Thread(ProcessE);
                _Thread4.IsBackground = true;
                _Thread4.Start(_competitor4);
            }

        }
       
        
        private void ProcessE(object state)
        {
            Process _competitor = (Process)state;
            ProgressBar _bar = m_ThreadRaceBars[_competitor.Index];
            TextBox _txt = m_ThreadRaceTextBoxes[_competitor.Index];
            BooleanGenerator boolGen = new BooleanGenerator();
            _competitor.isStarted[4] = true;

            while (_bar.Value < _bar.Maximum)
            {
                if (_competitor.Speed < _competitor.MaxSpeed)
                {
                    _competitor.result[3] = _competitor.R[0] | _competitor.R[1] | _competitor.R[2];
                    _txt.Text = "E: F3=" + _competitor.result[3].ToString();

                }

                _competitor.Accelerate();
                int _newValue = _bar.Value + 100 / _competitor.MaxSpeed;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;


                }));

                Thread.Sleep(1000);
            }
            _competitor.isCompleted[4] = true;
            _competitor.isStarted[4] = false;



            if (_competitor.isCompleted[4] && _competitor.isCompleted[1] && _competitor.isCompleted[3])
            {
                for (int i = 5; i < 8; i++)
                {
                    if (i == 5)
                    {
                        Thread _Thread5;
                        Process _competitor5 = new Process(i, 1, _competitor.R,
                            _competitor.result, _competitor.isCompleted, _competitor.isStarted);
                        _Thread5 = new Thread(ProcessF);
                        _Thread5.IsBackground = true;
                        _Thread5.Start(_competitor5);
                    }
                    else if (i == 6)
                    {
                        Thread _Thread6;
                        Process _competitor6 = new Process(i ,1, _competitor.R,
                            _competitor.result, _competitor.isCompleted, _competitor.isStarted);
                        _Thread6 = new Thread(ProcessG);
                        _Thread6.IsBackground = true;
                        _Thread6.Start(_competitor6);
                    }
                    else
                    {
                        Thread _Thread7;
                        Process _competitor7 = new Process(i, 1, _competitor.R,
                            _competitor.result, _competitor.isCompleted, _competitor.isStarted);
                        _Thread7 = new Thread(ProcessH);
                        _Thread7.IsBackground = true;
                        _Thread7.Start(_competitor7);
                    }

                }
            }

        }
        private void ProcessF(object state)
        {
            Process _competitor = (Process)state;
            ProgressBar _bar = m_ThreadRaceBars[_competitor.Index];
            TextBox _txt = m_ThreadRaceTextBoxes[_competitor.Index];
            _competitor.isStarted[5] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_competitor.Speed < _competitor.MaxSpeed)
                {
                    _competitor.result[4] = _competitor.R[0] | _competitor.R[1] | _competitor.R[2];
                    _txt.Text = "F: F3=" + _competitor.result[4].ToString();

                }

                _competitor.Accelerate();
                int _newValue = _bar.Value + 100 / _competitor.MaxSpeed;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;


                }));

                Thread.Sleep(400);
            }
            _competitor.isCompleted[5] = true;
            _competitor.isStarted[5] = false;
        }
        private void ProcessG(object state)
        {
            Process _competitor = (Process)state;
            ProgressBar _bar = m_ThreadRaceBars[_competitor.Index];
            TextBox _txt = m_ThreadRaceTextBoxes[_competitor.Index];
            _competitor.isStarted[6] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_competitor.Speed < _competitor.MaxSpeed)
                {
                    _competitor.result[5] = _competitor.R[0] | _competitor.R[1] | _competitor.R[2];
                    _txt.Text = "G: F3=" + _competitor.result[5].ToString();

                }

                _competitor.Accelerate();
                int _newValue = _bar.Value + 100 / _competitor.MaxSpeed;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;


                }));

                Thread.Sleep(400);
            }
            _competitor.isCompleted[6] = true;
            _competitor.isStarted[6] = false;
        }
        private void ProcessH(object state)
        {
            Process _competitor = (Process)state;
            ProgressBar _bar = m_ThreadRaceBars[_competitor.Index];
            TextBox _txt = m_ThreadRaceTextBoxes[_competitor.Index];
            _competitor.isStarted[7] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_competitor.Speed < _competitor.MaxSpeed)
                {
                    _competitor.result[6] = _competitor.R[0] | _competitor.R[1] | _competitor.R[2];
                    _txt.Text = "H: F3=" + _competitor.result[6].ToString();

                }

                _competitor.Accelerate();
                int _newValue = _bar.Value + 100 / _competitor.MaxSpeed;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;


                }));

                Thread.Sleep(1000);
            }
            _competitor.isCompleted[7] = true;
            _competitor.isStarted[7] = false;
            if(_competitor.isCompleted[7] && _competitor.isCompleted[6] && _competitor.isCompleted[5])
            {
                Thread _Thread8;
                Process _competitor8 = new Process(8, 1, _competitor.R,
                    _competitor.result, _competitor.isCompleted, _competitor.isStarted);
                _Thread8 = new Thread(ProcessK);
                _Thread8.IsBackground = true;
                _Thread8.Start(_competitor8);
            }
        }
        private void ProcessK(object state)
        {
            Process _competitor = (Process)state;
            ProgressBar _bar = m_ThreadRaceBars[_competitor.Index];
            TextBox _txt = m_ThreadRaceTextBoxes[_competitor.Index];
            _competitor.isStarted[8] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_competitor.Speed < _competitor.MaxSpeed)
                {
                    _competitor.result[7] = _competitor.R[0] | _competitor.R[1] | _competitor.R[2];
                    _txt.Text = "K: F3=" + _competitor.result[7].ToString();

                }

                _competitor.Accelerate();
                int _newValue = _bar.Value + 100 / _competitor.MaxSpeed;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;


                }));

                Thread.Sleep(400);
            }
            _competitor.isCompleted[8] = true;
            _competitor.isStarted[8] = false;
        }
        public class BooleanGenerator
        {
            Random rnd;

            public BooleanGenerator()
            {
                rnd = new Random();
            }

            public bool NextBoolean()
            {
                return Convert.ToBoolean(rnd.Next(0, 2));
            }
        }

        


        public class Process
        {
           
            public Process(int _Index, int _MaxSpeed, bool[] _R,bool[] _result,bool[] _isCompleted,bool[] _isStarted)
            {
                this.Index = _Index;
                this.MaxSpeed = _MaxSpeed;               
                this.Speed = 0;                
                this.R = _R;
                this.result = _result;
                this.isCompleted = _isCompleted;
                this.isStarted = _isStarted;

            }
            public bool[] R;
            public bool[] result;
            public bool[] isStarted;
            public bool[] isCompleted;

            //Индекс
            public int Index;
            //Максимальная скорость
            public int MaxSpeed { get; private set; }
            

            //Текущая скорость
            public int Speed { get; private set; }
       
            public void Accelerate()
            {
                if (this.Speed > this.MaxSpeed)
                    return;
                //Изменение скорости
                int _newSpeed = this.Speed + 1;

                if (_newSpeed > this.MaxSpeed)
                    this.Speed = this.MaxSpeed;
                else
                    this.Speed = _newSpeed;
            }
        }
    }
}
