using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Kiran
{
    public class LetterService
    {
        public int itr = 0;
        public int G;

        public List<string> GenerateLetterStrings(List<int> inputArray, List<int>[] markerSets)
        {
            List<List<int>> list = new List<List<int>>();

            foreach (List<int> e in markerSets)
            {
                list.Add(e);
            }

            List<string> letterStrings = new List<string>();
          
            foreach (List<int> markerSet in list)
            {
                List<Alphabet> letterSet = new List<Alphabet>();
                string letterString = "";
                for (int i = 0; i < inputArray.Count; i++)
                {
                    if (markerSet.Contains(i))
                    {
                        int doubleDigitNumber = 0;
                        doubleDigitNumber += 10 * inputArray[i];
                        doubleDigitNumber += inputArray[i + 1];
                        if (doubleDigitNumber < 27)
                        {
                            Alphabet letter = (Alphabet)doubleDigitNumber;
                            letterSet.Add(letter);
                            ++i;
                        }
                        else
                        {
                            Alphabet letter = (Alphabet)inputArray[i];
                            letterSet.Add(letter);
                        }
                    }
                    else
                    {
                        Alphabet letter = (Alphabet)inputArray[i];
                        letterSet.Add(letter);
                    }
                }
                foreach (Alphabet letter in letterSet)
                {
                    letterString = letterString + letter.ToString();
                }
                letterStrings.Add(letterString);
            }
            return letterStrings;
        }

        public List<int>[] GenerateMarkerSets(List<int> inputArray)
        {
            int fib = Fibonacci(inputArray.Count + 1);
            List<int>[] markerSets = new List<int>[fib];
            int N = inputArray.Count / 2;
            G = inputArray.Count / 2;

            List<int> markerSet = new List<int>();
            List<int> m0 = new List<int>();
            for (int j = 0; j < N; j++)
            {
                markerSet.Add(-1);
                m0.Add(-1);
            }
          
            markerSets[0] = m0;

            ++itr;
 
            Recursive(markerSets, markerSet, N, inputArray, -1);

            return markerSets;
        }


        public void Recursive(List<int>[] markerSets, List<int> markerSet, int N, List<int> inputArray, int level)
        {
            int i = N;    

                if (i == 1)//base
                {
                    for (int j = 0; j < inputArray.Count - 1; j++)
                    {
                        if ((level != -1) && (level + 2) > j) j = level + 2;                      
                        markerSet[G-1] = j;
                    if (G > 1)
                    {
                        if ((markerSet[G - 1] < (markerSet[G - 2] + 2))&&markerSet[G-2]!=-1)
                        {
                            markerSet[G - 1] = markerSet[G - 2] + 2;
                            j = markerSet[G - 1];
                        }
                    }
                   
                    
                        List<int> m = new List<int>();
                        foreach (int v in markerSet)
                        {
                            m.Add(v);
                        }
                
                        markerSets.SetValue(m, itr);
                        ++itr;                     
                    }
                   
                    return;
                }

                else if (i > 1)
                {
                    int x = inputArray.Count - 1 - 2 * (N - 1);
       
                    for (int j = -1; j < x; j++)
              
                    {                                               
                        markerSet[G-N] = j; 

                        for (int u = 0; u < (G - 1); u++)
                        {
                            if (markerSet[u + 1] < markerSet[u])
                            {
                                markerSet[u + 1] = markerSet[u] + 2;
                                j = markerSet[u + 1];
                            }
                           
                        }            

                        Recursive(markerSets, markerSet, N - 1, inputArray,j);            
                    }
                }

                else return;           
        }

        public int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
           
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }




        public void DB()
        {

            String _ConnectionString = @"SERVER=(local);Integrated Security=True; Database=dbdb";
            SqlConnection conn = new SqlConnection(_ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("spAuthenticateUser", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", "arctrade1");
            cmd.Parameters.AddWithValue("@Password", "arctrade");

            SqlParameter pvNewId = new SqlParameter();
            pvNewId.ParameterName = "@IsValid";
            pvNewId.DbType = DbType.Boolean;
            pvNewId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pvNewId);

            cmd.ExecuteNonQuery();

            bool b = (bool)cmd.Parameters["@IsValid"].Value;
            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    Boolean isValid = (bool)reader["isValid"];
            //    Console.Write(isValid);
            //    Console.Write("lol");
            //    // person.PersonId = Convert.ToInt32(reader["PersonId"]);

            //}

            conn.Close();
        }
    }
}
















