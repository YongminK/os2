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
            InitializeComponent(); //инициализация компонентов окна
            Start(); //создание элементов и проверки
        }
        //Список элементов управления 'ProgressBar'
        private List<ProgressBar> m_ProcessBars;
        //Список элементов управления 'TextBox' для вывода статистики
        private List<TextBox> m_ProcessTextBoxes;
        


        public void Start()
        {
            //Инициализация элементов 
            if (m_ProcessBars != null)
            {
                foreach (ProgressBar _bar in m_ProcessBars)
                    this.tabPageThreadsRace.Controls.Remove(_bar);

                m_ProcessBars.Clear();
            }
            else
            {
                m_ProcessBars = new List<ProgressBar>();
            }

            if (m_ProcessTextBoxes != null)
            {
                foreach (TextBox _txt in m_ProcessTextBoxes)
                    this.tabPageThreadsRace.Controls.Remove(_txt);

                m_ProcessTextBoxes.Clear();
            }
            else
            {
                m_ProcessTextBoxes = new List<TextBox>();
            }

            //Количество потоков
            int _ThreadsCount = 9;
            //Длина бара
            int _BarLength = 100;

            //Размещение элементов управления
            for (int i = 0; i < _ThreadsCount; i++)
            {
                ProgressBar _bar = new ProgressBar() { Minimum = 0, Maximum = _BarLength, Value = 0, Left = 5, Top = 5 + i * 25, Width = btnStart.Left - 170, Height = 20 };
                TextBox _txt = new TextBox() { Left = 565 , Top = _bar.Top, Width = 170, Height = _bar.Height };

                this.tabPageThreadsRace.Controls.Add(_bar);
                this.tabPageThreadsRace.Controls.Add(_txt);

                _bar.Visible = true;
                _txt.Visible = true;

                m_ProcessBars.Add(_bar);
                m_ProcessTextBoxes.Add(_txt);
            }
        }
    
             //Старт
        private void btnStart_Click(object sender, EventArgs e)
        {
            ProcessInit();
           
        }
        private void ProcessInit()
        {
            Process _currentProcess;
            bool[] R = { false, false, false };
            bool[] result = { false, false, false, false,false,false,false,false};
            bool[] isStarted = { false, false, false, false, false, false, false, false,false };
            bool[] isCompleted = { false, false, false, false, false, false, false, false, false };
            _currentProcess = new Process(0,1,R,result,isCompleted, isStarted);

            Thread _Thread = new Thread(ProcessA);
            //Все создаваемые потоки - фоновые и завершаются вместе с основным приложением
            _Thread.IsBackground = true;
            //Старт
            _Thread.Start(_currentProcess);


        }
        //Потоки
        //Process A
        private void ProcessA(object state)
        {
            
            Process _currentProcess = (Process)state;
            ProgressBar _bar = m_ProcessBars[_currentProcess.Index];
            TextBox _txt = m_ProcessTextBoxes[_currentProcess.Index];
            BooleanGenerator boolGen = new BooleanGenerator();
            _currentProcess.isStarted[0] = true;
            //Основной цикл
            while (_bar.Value < _bar.Maximum)
            {
                if (_currentProcess.CurrentDuration < _currentProcess.Duration) //генерируются случайные R
                {
                    _currentProcess.R[0] = boolGen.NextBoolean();
                    _currentProcess.R[1] = boolGen.NextBoolean();
                    _currentProcess.R[2] = boolGen.NextBoolean();
                    _txt.Text = "A: R1=" + _currentProcess.R[0].ToString() 
                        + " R2=" + _currentProcess.R[1].ToString() + " R3=" + _currentProcess.R[2].ToString(); //вывод
                }
                //отрисовка шкалы загрузки
                int _newValue = _bar.Value + 100 / _currentProcess.Duration*25;
                _currentProcess.ChangeDurration();
                
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));
                Thread.Sleep(800);               //приостановка процесса  
            }
            _currentProcess.isCompleted[0] = true;            
            _currentProcess.isStarted[0] = false;
            //Если А завершен - стартуют B, D, C
            if(_currentProcess.isCompleted[0])
            {
                for (int i = 1; i < 4; i++)
                {
                    if (i == 1) //B
                    {
                        Thread _Thread1;
                        Process _currentProcess1 = new Process(i, 2, _currentProcess.R, 
                            _currentProcess.result,_currentProcess.isCompleted,_currentProcess.isStarted);
                        _Thread1 = new Thread(MakeProcess);
                        _Thread1.IsBackground = true;
                        _Thread1.Start(_currentProcess1);
                    }
                    else if (i == 3) //D
                    {
                        Thread _Thread3;
                        Process _currentProcess3 = new Process(i, 2, _currentProcess.R,
                            _currentProcess.result, _currentProcess.isCompleted, _currentProcess.isStarted);
                        _Thread3 = new Thread(MakeProcess);
                        _Thread3.IsBackground = true;
                        _Thread3.Start(_currentProcess3);
                    }
                    else //C
                    {
                        Thread _Thread2;
                        Process _currentProcess2 = new Process(i, 1, _currentProcess.R,
                            _currentProcess.result, _currentProcess.isCompleted, _currentProcess.isStarted);
                        _Thread2 = new Thread(MakeProcess);
                        _Thread2.IsBackground = true;
                        _Thread2.Start(_currentProcess2);
                    }

                }
            }
        }
        private void MakeProcess(object state)
        {
            Process _currentProcess = (Process)state;
            ProgressBar _bar = m_ProcessBars[_currentProcess.Index];
            TextBox _txt = m_ProcessTextBoxes[_currentProcess.Index];
            int sleep = 0;
            _currentProcess.isStarted[_currentProcess.Index] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_currentProcess.CurrentDuration < _currentProcess.Duration)
                {
                    switch(_currentProcess.Index)
                    {
                        case 1: //B
                            {
                                _currentProcess.result[_currentProcess.Index - 1] = 
                                    !_currentProcess.R[0] & _currentProcess.R[1] & _currentProcess.R[2];
                                _txt.Text = 
                                    "B: F1= !R1 & R2 & R3 = " + _currentProcess.result[_currentProcess.Index - 1].ToString();
                                sleep = 400;
                                break;
                            }
                        case 2: //C
                            {
                                _currentProcess.result[1] = _currentProcess.R[0] | _currentProcess.R[1] | _currentProcess.R[2];
                                _txt.Text = "C: F2= R1 | R2 | R3 = " + _currentProcess.result[1].ToString();
                                sleep = 300;
                                break;
                            }
                        case 3: //D
                            {
                                _currentProcess.result[_currentProcess.Index - 1] =
                                    _currentProcess.R[0] | _currentProcess.R[1] & _currentProcess.R[2];
                                _txt.Text =
                                    "D: F3= R1 | R2 & R3 = " + _currentProcess.result[_currentProcess.Index - 1].ToString();
                                sleep = 400;
                                break;
                            }
                        default:
                            break;
                    }
                }
                _currentProcess.ChangeDurration();
                int _newValue = _bar.Value + 100 / _currentProcess.Duration;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));

                Thread.Sleep(sleep);
            }
            _currentProcess.isCompleted[_currentProcess.Index] = true;
            _currentProcess.isStarted[_currentProcess.Index] = false;

            //Если заверешн С- старт Е
            if (_currentProcess.isCompleted[2])
            {
                Thread _Thread4;
                Process _currentProcess4 = new Process(4, 1, _currentProcess.R,
                    _currentProcess.result, _currentProcess.isCompleted, _currentProcess.isStarted);
                _Thread4 = new Thread(ProcessE);
                _Thread4.IsBackground = true;
                _Thread4.Start(_currentProcess4);
            }

        }
       
        
        private void ProcessE(object state)
        {
            Process _currentProcess = (Process)state;
            ProgressBar _bar = m_ProcessBars[_currentProcess.Index];
            TextBox _txt = m_ProcessTextBoxes[_currentProcess.Index];
            BooleanGenerator boolGen = new BooleanGenerator();
            _currentProcess.isStarted[4] = true;

            while (_bar.Value < _bar.Maximum)
            {
                if (_currentProcess.CurrentDuration < _currentProcess.Duration)
                {
                    _currentProcess.result[3] = _currentProcess.result[1];
                    _txt.Text = "E: F3 = F2 = " + _currentProcess.result[3].ToString();

                }

                _currentProcess.ChangeDurration();
                int _newValue = _bar.Value + 100 / _currentProcess.Duration;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                    
                }));
                Thread.Sleep(1000);
            }
            _currentProcess.isCompleted[4] = true;
            _currentProcess.isStarted[4] = false;
            //Если завершен Е - старт F,G,H
            if (_currentProcess.isCompleted[4] && _currentProcess.isCompleted[1] && _currentProcess.isCompleted[3])
            {
                for (int i = 5; i < 8; i++)
                {
                    if (i == 5)
                    {
                        Thread _Thread5;
                        Process _currentProcess5 = new Process(i, 1, _currentProcess.R,
                            _currentProcess.result, _currentProcess.isCompleted, _currentProcess.isStarted);
                        _Thread5 = new Thread(ProcessF);
                        _Thread5.IsBackground = true;
                        _Thread5.Start(_currentProcess5);
                    }
                    else if (i == 6)
                    {
                        Thread _Thread6;
                        Process _currentProcess6 = new Process(i ,1, _currentProcess.R,
                            _currentProcess.result, _currentProcess.isCompleted, _currentProcess.isStarted);
                        _Thread6 = new Thread(ProcessG);
                        _Thread6.IsBackground = true;
                        _Thread6.Start(_currentProcess6);
                    }
                    else
                    {
                        Thread _Thread7;
                        Process _currentProcess7 = new Process(i, 1, _currentProcess.R,
                            _currentProcess.result, _currentProcess.isCompleted, _currentProcess.isStarted);
                        _Thread7 = new Thread(ProcessH);
                        _Thread7.IsBackground = true;
                        _Thread7.Start(_currentProcess7);
                    }
                }
            }

        }

        private void ProcessF(object state)
        {
            Process _currentProcess = (Process)state;
            ProgressBar _bar = m_ProcessBars[_currentProcess.Index];
            TextBox _txt = m_ProcessTextBoxes[_currentProcess.Index];
            _currentProcess.isStarted[5] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_currentProcess.CurrentDuration < _currentProcess.Duration)
                {
                    _currentProcess.result[4] = _currentProcess.result[0] & _currentProcess.result[2] | _currentProcess.result[3];
                    _txt.Text = "F: F5= F1 & F3 | F4 = " + _currentProcess.result[4].ToString();
                }

                _currentProcess.ChangeDurration();
                int _newValue = _bar.Value + 100 / _currentProcess.Duration;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));
                Thread.Sleep(400);
            }
            _currentProcess.isCompleted[5] = true;
            _currentProcess.isStarted[5] = false;
        }

        private void ProcessG(object state)
        {
            Process _currentProcess = (Process)state;
            ProgressBar _bar = m_ProcessBars[_currentProcess.Index];
            TextBox _txt = m_ProcessTextBoxes[_currentProcess.Index];
            _currentProcess.isStarted[6] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_currentProcess.CurrentDuration < _currentProcess.Duration)
                {
                    _currentProcess.result[5] = _currentProcess.result[0] | _currentProcess.result[2] | _currentProcess.result[3];
                    _txt.Text = "G: F6= F1 | F3 | F4 = " + _currentProcess.result[5].ToString();
                }

                _currentProcess.ChangeDurration();
                int _newValue = _bar.Value + 100 / _currentProcess.Duration;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));

                Thread.Sleep(400);
            }
            _currentProcess.isCompleted[6] = true;
            _currentProcess.isStarted[6] = false;
        }

        private void ProcessH(object state)
        {
            Process _currentProcess = (Process)state;
            ProgressBar _bar = m_ProcessBars[_currentProcess.Index];
            TextBox _txt = m_ProcessTextBoxes[_currentProcess.Index];
            _currentProcess.isStarted[7] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_currentProcess.CurrentDuration < _currentProcess.Duration)
                {
                    _currentProcess.result[6] = _currentProcess.result[0] | !_currentProcess.result[2] & _currentProcess.result[3];
                    _txt.Text = "H: F7= F1 | !F3 & F4 = " + _currentProcess.result[6].ToString();
                }

                _currentProcess.ChangeDurration();
                int _newValue = _bar.Value + 100 / _currentProcess.Duration;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));

                Thread.Sleep(1000);
            }
            _currentProcess.isCompleted[7] = true;
            _currentProcess.isStarted[7] = false;
            if(_currentProcess.isCompleted[7] && _currentProcess.isCompleted[6] && _currentProcess.isCompleted[5])
            {
                Thread _Thread8;
                Process _currentProcess8 = new Process(8, 1, _currentProcess.R,
                    _currentProcess.result, _currentProcess.isCompleted, _currentProcess.isStarted);
                _Thread8 = new Thread(ProcessK);
                _Thread8.IsBackground = true;
                _Thread8.Start(_currentProcess8);
            }
        }

        private void ProcessK(object state)
        {
            Process _currentProcess = (Process)state;
            ProgressBar _bar = m_ProcessBars[_currentProcess.Index];
            TextBox _txt = m_ProcessTextBoxes[_currentProcess.Index];
            _currentProcess.isStarted[8] = true;
            while (_bar.Value < _bar.Maximum)
            {
                if (_currentProcess.CurrentDuration < _currentProcess.Duration)
                {
                    _currentProcess.result[7] = _currentProcess.result[6] | _currentProcess.result[5] | _currentProcess.result[4];
                    _txt.Text = "K: F8= F7 | F6 | F5 = " + _currentProcess.result[7].ToString();
                }

                _currentProcess.ChangeDurration();
                int _newValue = _bar.Value + 100 / _currentProcess.Duration;
                _bar.Invoke(new MethodInvoker(() =>
                {
                    if (_newValue < _bar.Maximum)
                        _bar.Value = _newValue;
                    else
                        _bar.Value = _bar.Maximum;
                }));

                Thread.Sleep(400);
            }
            _currentProcess.isCompleted[8] = true;
            _currentProcess.isStarted[8] = false;
        }

        //Генератор рандомных булевых
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
           
            public Process(int _Index, int _Duration, bool[] _R,bool[] _result,bool[] _isCompleted,bool[] _isStarted)
            {
                this.Index = _Index;
                this.Duration = _Duration;               
                this.CurrentDuration = 0;                
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
            //Длительность
            public int Duration { get; private set; }
            //Текущая 
            public int CurrentDuration { get; private set; }
       
            public void ChangeDurration()
            {
                if (this.CurrentDuration > this.Duration)
                    return;
                //Изменение состояния
                int _newCurrentDuration = this.CurrentDuration + 1;

                if (_newCurrentDuration > this.Duration)
                    this.CurrentDuration = this.Duration;
                else
                    this.CurrentDuration = _newCurrentDuration;
            }
        }
    }
}
