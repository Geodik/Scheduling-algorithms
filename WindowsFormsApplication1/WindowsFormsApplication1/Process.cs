using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using RR;

namespace SawafOS
{
    class Process
    {
        private int processID;
        private int numOfWordsToType;
        private int startPoint = 0;
        private int timeQuantum = 0;

        private int counter = 0;

        private bool done;
        private FileManager fileManager = new FileManager();
        private Thread thread;

        public Process(int processID, int numberOfWordsToType)
        {
            this.processID = processID;
            this.numOfWordsToType = numberOfWordsToType;
            this.thread = new Thread(() => processWriteIntoFile(numOfWordsToType));

        }

        private bool tempDone = false;

        public bool getTempDone() { return tempDone; }

        public void processWriteIntoFile(int numberOfWords)
        {
            Console.WriteLine("Process " + processID + " Entering process WriteIntoFile()" + " StartPoint: " + getStartPoint() + " time Quantum: " + getTimeQuantum());

            for (int i = getStartPoint(); i < getTimeQuantum(); i++)
            {
                fileManager.WriteIntoFile(i + " Written by Process # " + processID);
                counter++;
            }
            tempDone = true;
            Console.WriteLine("Process " + processID + " Exiting loop with startPoint: " + getStartPoint());

            if (counter == numberOfWords)
            {
                Console.WriteLine("Process: " + processID + " is done." + " counter = " + counter + "\n");
                done = true;
            }
            if (numberOfWords % 2 != 0 && counter > numberOfWords)
            {
                counter = counter - 1;
                if (counter == numberOfWords)
                {
                    Console.WriteLine("Process: " + processID + " is done." + " counter = " + counter + "\n");
                    done = true;
                }
            }
            fileManager.WriteIntoFile("\n");
        }

        public void setStartPoint(int startPoint)
        {
            this.startPoint = startPoint;
        }

        public int getStartPoint()
        {
            return startPoint;
        }

        public bool isDone()
        {
            return done;
        }

        public void setTimeQuantum(int time)
        {
            this.timeQuantum = time;
        }

        public int getTimeQuantum()
        {
            tempDone = false;
            return this.timeQuantum;
        }

        public int getProcessID()
        {
            return processID;
        }

        public int getNumberOfWords()
        {
            return this.numOfWordsToType;
        }

    }

    class Program
    {
        private FileManager fileManager = new FileManager();
        private object lockObj = new object();

        public int N = 0;

        public void FCFS(ProgressBar bar)
        {
            Task firstThread = new Task(FirstThread);
            firstThread.Start();
            firstThread.Wait();
            bar.Value = ++N;
            

            Task secondThread = new Task(SecondThread);
            secondThread.Start();
            secondThread.Wait();
            bar.Value = ++N;

            Task thirdThread = new Task(ThirdThread);
            thirdThread.Start();
            thirdThread.Wait();
            bar.Value = ++N;

            Task fourthThread = new Task(FourthThread);
            fourthThread.Start();
            fourthThread.Wait();
            bar.Value = ++N;

            Task fifthThread = new Task(FifthThread);
            fifthThread.Start();
            fifthThread.Wait();
            bar.Value = ++N;

            Task fibThread = new Task(FibRec);
            fibThread.Start();
            fibThread.Wait();
            bar.Value = ++N;

            MessageBox.Show("Готово!");
        }

        public void FCLS(ProgressBar bar)
        {
            Task fibThread = new Task(FibRec);
            fibThread.Start();
            fibThread.Wait();
            bar.Value = ++N;

            Task fifthThread = new Task(FifthThread);
            fifthThread.Start();
            fifthThread.Wait();
            bar.Value = ++N;

            Task fourthThread = new Task(FourthThread);
            fourthThread.Start();
            fourthThread.Wait();
            bar.Value = ++N;

            Task thirdThread = new Task(ThirdThread);
            thirdThread.Start();
            thirdThread.Wait();
            bar.Value = ++N;

            Task secondThread = new Task(SecondThread);
            secondThread.Start();
            secondThread.Wait();
            bar.Value = ++N;

            Task firstThread = new Task(FirstThread);
            firstThread.Start();
            firstThread.Wait();
            bar.Value = ++N;

            MessageBox.Show("Готово!");
        }

        private void FirstThread()
        {
            lock (lockObj)
            {
                fileManager.WriteIntoFile("\n");
                for (int i = 0; i < 5; i++)
                {
                    fileManager.WriteIntoFile(i + " Written by Thread #1");
                }
            }
        }

        private void SecondThread()
        {
            lock (lockObj)
            {
                fileManager.WriteIntoFile("\n");
                for (int i = 0; i < 10; i++)
                {
                    fileManager.WriteIntoFile(i + " Written by Thread #2");
                }
            }
        }

        private void ThirdThread()
        {
            lock (lockObj)
            {
                fileManager.WriteIntoFile("\n");
                for (int i = 0; i < 15; i++)
                {
                    fileManager.WriteIntoFile(i + " Written by Thread #3");
                }
            }
        }

        private void FourthThread()
        {
            lock (lockObj)
            {
                fileManager.WriteIntoFile("\n");
                for (int i = 0; i < 20; i++)
                {
                    fileManager.WriteIntoFile(i + " Written by Thread #4");
                }
            }
        }

        private void FifthThread()
        {
            lock (lockObj)
            {
                fileManager.WriteIntoFile("\n");
                for (int i = 0; i < 25; i++)
                {
                    fileManager.WriteIntoFile(i + " Written by Thread #5");
                }
            }
        }

        private void FibRec()
        {
            int perv = 1, vtor = 1, sum = 0, count = 0;
            fileManager.WriteIntoFile("\n");
            while (10000 >= sum)
            {
                sum = perv + vtor;
                fileManager.WriteIntoFile(sum.ToString());

                perv = vtor;
                vtor = sum;
                count++;
            }
            fileManager.WriteIntoFile("Count "+count.ToString());

        }

        /*       static void Main(string[] args)
               {
            
                   Program program = new Program();
                   //program.FCFS();
                   RoundRobin rr = new RoundRobin();
                   rr.doRoundRobin();
                   Console.ReadLine();
        
               }*/
    }
}
