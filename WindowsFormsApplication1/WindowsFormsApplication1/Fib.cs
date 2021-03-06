﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SawafOS;

namespace WindowsFormsApplication1
{
    class Fib
    {
        private int processID;
        private int numOfWordsToType;
        private int startPoint = 0;
        private int timeQuantum = 0;

        private int counter = 0;

        private bool done;
        private FileManager fileManager = new FileManager();
        private Thread thread;

        public Fib(int processID, int numberOfWordsToType)
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
                int perv = 1, vtor = 1, sum = 0, count = 0;
                while (count <= getTimeQuantum())
                {
                    sum = perv + vtor;
                    fileManager.WriteIntoFile(sum.ToString());

                    perv = vtor;
                    vtor = sum;
                    count++;
                }
                fileManager.WriteIntoFile("Count " + count.ToString());

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


}