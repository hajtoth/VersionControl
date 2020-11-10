using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _7_gyak.Entities;

namespace _7_gyak
{
    public partial class Form1 : Form
    {
        string path;

        public List<Person> Population { get; }
        public List<BirthProbability> BirthProbabilities { get; }
        public List<DeathProbability> DeathProbabilities { get; }

        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }

        private List<DeathProbability> GetDeathProbabilities(string path)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                string[] rawData = line.Split(';');
                DeathProbability deathProbability = new DeathProbability()
                {
                    Age = int.Parse(rawData[0]),
                    Gender = (Gender)Enum.Parse(typeof(Gender), rawData[1]),
                    Probability = double.Parse(rawData[2])
                };
                deathProbabilities.Add(deathProbability);
            }

            return deathProbabilities;
        }

        private List<BirthProbability> GetBirthProbabilities(string path)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                string[] rawData = line.Split(';');
                BirthProbability birthProbability = new BirthProbability()
                {


                    Age = int.Parse(rawData[0]),
                    NbrOfChildren = int.Parse(rawData[1]),
                    Probability = double.Parse(rawData[2])
                };
                birthProbabilities.Add(birthProbability);
            }

            return birthProbabilities;
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }
            return population;
        }
        public List<BirthProbability> GetBirthProbability(string csvpath)
        {
            List<BirthProbability> birth = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birth.Add(new BirthProbability()
                    {
                        Age = byte.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        Probability = double.Parse(line[2]),
                    });
                }
            }
            return birth;
        }

        public List<DeathProbability> GetDeathProbability(string csvpath)
        {
            List<DeathProbability> death = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    death.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = byte.Parse(line[1]),
                        Probability = double.Parse(line[2]),
                    });
                }
            }
            return death;
        }
        private void Browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                population_txt.Text = ofd.FileName;
                path = ofd.FileName;
            }
        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
            List<Person> People = new List<Person>();
            List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
            List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
            People = GetPopulation(path);
            BirthProbabilities = GetBirthProbability(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbability(@"C:\Temp\halál.csv");
            StreamWriter sw = new StreamWriter("népesség.txt");

            Random rng = new Random();

            for (int year = 2005; year <= endyear_nUD.Value; year++)
            {
                //Végigmegyünk az összes személyen
                for (int i = 0; i < People.Count; i++)
                {
                    Person person = People[i];
                    if (!person.IsAlive) continue; //Ha halott, ugrunk a ciklus következõ lépésére
                    byte age = (byte)(year - person.BirthYear);

                    //Halál kezelése
                    double pDeath = (from x in DeathProbabilities
                                     where x.Gender == person.Gender && x.Age == age + 1
                                     select x.Probability).First();
                    if (rng.NextDouble() <= pDeath) person.IsAlive = false;

                    //Születés kezelése -- csak nõk szülnek
                    if (person.Gender == Gender.Female)
                    {
                        //Szülési valószínûség kikeresése
                        double pBirth = (from x in BirthProbabilities
                                         where x.Age == age
                                         select x.Probability).FirstOrDefault();

                        //Születik gyermek?
                        if (rng.NextDouble() <= pBirth)
                        {
                            Person újszülött = new Person();
                            újszülött.BirthYear = year;
                            újszülött.NbrOfChildren = 0;
                            újszülött.Gender = (Gender)(rng.Next(1, 3));
                            People.Add(újszülött);
                        }
                    }
                }

                int nbrOfMales = (from x in People
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in People
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();

                result_txt.Text += "Szimulációs év: " + year + "\r \n Fiuk: " + nbrOfMales + "\r \n Lányok: " + nbrOfFemales + Environment.NewLine;
                sw.WriteLine("Szimulációs év: " + year + "  Fiuk: " + nbrOfMales + "  Lányok: " + nbrOfFemales);

            }
            sw.Close();
        }
    }
}

