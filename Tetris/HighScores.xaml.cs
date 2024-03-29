﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    /// 

    /*
     * HIGH SCORES PAGE
     * 
     * Page for displaying the top 5 high scores
     * This will distinguish between player and AI users
     * 
     */

    public partial class HighScores : Window
    {     
        public HighScores()
        {
            InitializeComponent();
            TextBlock[] scores = new TextBlock[] { First, Second, Third, Fourth, Fifth};

            // Read high scores file
            string[] fileContents = ReadFile().Split(';');
            List<string> fileContentsCopy = new List<string>();

            for (int i = 0; i < fileContents.Length-1; i++)
            {
                fileContentsCopy.Add(fileContents[i]);
            }

            // Sort High Scores
            fileContentsCopy = RecursiveQuickSort(fileContentsCopy);

            // Display top 5 scores
            for (int i = 0;i < scores.Length; i++)
            {
                if (fileContentsCopy[i][fileContentsCopy[i].Length - 1] == 'P')
                {
                    scores[i].Text = "Player: " + fileContentsCopy[i].Substring(0, fileContentsCopy[i].Length - 1);
                }
                else
                {
                    scores[i].Text = "AI: " + fileContentsCopy[i].Substring(0, fileContentsCopy[i].Length - 1);
                }
            }

        }

        public string ReadFile()
        {
            string fileContents = "";
            int count = 0;
            // Try to access file, otherwise throw an exception
            try
            {
                using (StreamReader reader = new StreamReader("C:\\Users\\hashi\\OneDrive\\Desktop\\Scores.txt"))
                {
                    while (reader.Peek() != -1)
                    {
                        fileContents += reader.ReadLine();
                        count++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error reading file");
            }

            return fileContents;
        }

        static List<string> RecursiveQuickSort(List<string> scores)
        {
            // Recursively call quick sort to sort the high scores

            // Define pivot
            int pivot = Convert.ToInt32(scores[0].Remove(0,1));
            string pivotPlayer = Convert.ToString(scores[0][0]);

            List<string> lower = new List<string>();
            List<string> higher = new List<string>();

            // Assign elements based on their value relative to the pivot
            for (int i = 1; i < scores.Count; i++)
            {
                if (Convert.ToInt32(scores[i].Remove(0,1)) > pivot)
                {
                    lower.Add(scores[i]);
                }
                else
                {
                    higher.Add(scores[i]);
                }

            }
            // Recursively call QuickSort to sort the list
            if (lower.Count != 0)
            {
                lower = RecursiveQuickSort(lower);
            }
            if (higher.Count != 0)
            {
                higher = RecursiveQuickSort(higher);
            }

            lower.Add(pivot + pivotPlayer);
            lower.AddRange(higher);
            return lower;
        }
    }
}
