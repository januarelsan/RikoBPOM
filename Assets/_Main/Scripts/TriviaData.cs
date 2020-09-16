using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaData : Singleton<TriviaData>
{
    private string[] questStrings = new string[]{
    "Siapa Presiden Pertama Indonesia?",
    "Tanggal Berapa Indonesia Merdeka?",
    "Bulan Berapa Indonesia Merdeka?",
    "Tahun Berapa Indonesia Merdeka?",
    "Sekarang Tahun Berapa?",    
    };

    private string[,] choiceStrings = new string[,] { 
        { "Januar", "Zaman", "Fahry", "Soekarno"}, 
        {"12 Januari", "14 Agustus", "17 Agustus", "17 September"},
        {"Bulan September", "Bulan Agustus", "Bulan Januari", "Bulan Maret"},
        {"Tahun 1995", "Tahun 1945", "Tahun 2020", "Tahun Lalu"},
        {"Tahun 2020", "Tahun 2021", "Tahun 2220", "Tahun 1995"}
         };

    private int[] trueAnswers = new int[]{3,2,1,1,0};

    public string GetQuestString(int index){
        return questStrings[index];
    }

    public string GetChoiceString(int questIndex, int choiceIndex){
        return choiceStrings[questIndex, choiceIndex];
    }

    public int GetTrueAnswer(int questIndex){
        return trueAnswers[questIndex];
    }
}
