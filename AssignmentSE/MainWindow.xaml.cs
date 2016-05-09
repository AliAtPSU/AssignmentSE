using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VectorSpaceModel.Components;
namespace AssignmentSE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initializeKNearest();
            initializeNaiveBaise();
            initializePageRank();
            initializeRcchio();

        }
        BayesClassifier.Classifier naiveBayseClassifier = new BayesClassifier.Classifier();
        List<Document> politicsKNearest = new List<Document>();
        List<Document> economyKNearest = new List<Document>();
        List<Document> sportsKNearest = new List<Document>();
        List<Document> technologyKNearest = new List<Document>();

        List<Document> politicsNaiveBaise = new List<Document>();
        List<Document> economyNaiveBaise = new List<Document>();
        List<Document> sportsNaiveBaise = new List<Document>();
        List<Document> technologyNaiveBaise = new List<Document>();

        List<Document> politicsRocchio = new List<Document>();
        List<Document> economyRocchio = new List<Document>();
        List<Document> sportsRocchio = new List<Document>();
        List<Document> technologyRocchio = new List<Document>();

        List<Document> politicsPageRank = new List<Document>();
        List<Document> economyPageRank = new List<Document>();
        List<Document> sportsPageRank = new List<Document>();
        List<Document> technologyPageRank = new List<Document>();

        void initializeKNearest()
        {
            politicsKNearest.Add(turnFileToDocument("documents/politics/Backlash after Barack Obama EU referendum intervention.txt",Category.Politics));
            politicsKNearest.Add(turnFileToDocument("documents/politics/Migrant crisis Merkel and EU officials visit Turkey to promote deal.txt", Category.Politics));
            politicsKNearest.Add(turnFileToDocument("documents/politics/Syria conflict Truce in danger of collapse Obama and UN.txt", Category.Politics));
            economyKNearest.Add(turnFileToDocument("documents/economy/India's population explosion will make or break its economy.txt", Category.Economy));
            economyKNearest.Add(turnFileToDocument("documents/economy/Saudi Arabia racing to raise tons of cash.txt",Category.Economy));
            economyKNearest.Add(turnFileToDocument("documents/economy/Stocks haven't been this expensive in 7 years.txt",Category.Economy));
            sportsKNearest.Add(turnFileToDocument("documents/technology/Alcatel's new tablet offers Android Marshmallow and LTE for $130.txt", Category.Technology));
            sportsKNearest.Add(turnFileToDocument("documents/technology/Government withdraws from New York iPhone unlocking case.txt", Category.Technology));
            sportsKNearest.Add(turnFileToDocument("documents/technology/Windows 10 testers can now try Windows Ink and lots more features.txt", Category.Technology));
            technologyKNearest.Add(turnFileToDocument("documents/sports/Kevin Friend Which teams do Premier League referees support.txt", Category.Technology));
            technologyKNearest.Add(turnFileToDocument("documents/sports/Premier League and Football League Ups and downs.txt", Category.Technology));
            technologyKNearest.Add(turnFileToDocument("documents/sports/Roberto Martinez Everton boss faces critical FA Cup match.txt", Category.Technology));
        }

        void initializeRcchio()
        {
            politicsRocchio.Add(turnFileToDocument("documents/politics/Backlash after Barack Obama EU referendum intervention.txt", Category.Politics));
            politicsRocchio.Add(turnFileToDocument("documents/politics/Migrant crisis Merkel and EU officials visit Turkey to promote deal.txt", Category.Politics));
            politicsRocchio.Add(turnFileToDocument("documents/politics/Syria conflict Truce in danger of collapse Obama and UN.txt", Category.Politics));
            economyRocchio.Add(turnFileToDocument("documents/economy/India's population explosion will make or break its economy.txt", Category.Economy));
            economyRocchio.Add(turnFileToDocument("documents/economy/Saudi Arabia racing to raise tons of cash.txt", Category.Economy));
            economyRocchio.Add(turnFileToDocument("documents/economy/Stocks haven't been this expensive in 7 years.txt", Category.Economy));
            sportsRocchio.Add(turnFileToDocument("documents/technology/Alcatel's new tablet offers Android Marshmallow and LTE for $130.txt", Category.Technology));
            sportsRocchio.Add(turnFileToDocument("documents/technology/Government withdraws from New York iPhone unlocking case.txt", Category.Technology));
            sportsRocchio.Add(turnFileToDocument("documents/technology/Windows 10 testers can now try Windows Ink and lots more features.txt", Category.Technology));
            technologyRocchio.Add(turnFileToDocument("documents/sports/Kevin Friend Which teams do Premier League referees support.txt", Category.Technology));
            technologyRocchio.Add(turnFileToDocument("documents/sports/Premier League and Football League Ups and downs.txt", Category.Technology));
            technologyRocchio.Add(turnFileToDocument("documents/sports/Roberto Martinez Everton boss faces critical FA Cup match.txt", Category.Technology));
        }

        void initializeNaiveBaise()
        {
            naiveBayseClassifier.TeachCategory("Politics", new System.IO.StreamReader("documents/politics/Backlash after Barack Obama EU referendum intervention.txt"));
            naiveBayseClassifier.TeachCategory("Politics", new System.IO.StreamReader("documents/politics/Migrant crisis Merkel and EU officials visit Turkey to promote deal.txt"));
            naiveBayseClassifier.TeachCategory("Politics", new System.IO.StreamReader("documents/politics/Syria conflict Truce in danger of collapse Obama and UN.txt"));
            naiveBayseClassifier.TeachCategory("Economy", new System.IO.StreamReader("documents/economy/India's population explosion will make or break its economy.txt"));
            naiveBayseClassifier.TeachCategory("Economy", new System.IO.StreamReader("documents/economy/Saudi Arabia racing to raise tons of cash.txt"));
            naiveBayseClassifier.TeachCategory("Economy", new System.IO.StreamReader("documents/economy/Stocks haven't been this expensive in 7 years.txt"));
            naiveBayseClassifier.TeachCategory("Sports", new System.IO.StreamReader("documents/technology/Alcatel's new tablet offers Android Marshmallow and LTE for $130.txt"));
            naiveBayseClassifier.TeachCategory("Sports", new System.IO.StreamReader("documents/technology/Government withdraws from New York iPhone unlocking case.txt"));
            naiveBayseClassifier.TeachCategory("Sports", new System.IO.StreamReader("documents/technology/Windows 10 testers can now try Windows Ink and lots more features.txt"));
            naiveBayseClassifier.TeachCategory("Technology", new System.IO.StreamReader("documents/sports/Kevin Friend Which teams do Premier League referees support.txt"));
            naiveBayseClassifier.TeachCategory("Technology", new System.IO.StreamReader("documents/sports/Premier League and Football League Ups and downs.txt"));
            naiveBayseClassifier.TeachCategory("Technology", new System.IO.StreamReader("documents/sports/Roberto Martinez Everton boss faces critical FA Cup match.txt"));

        }

        void initializePageRank()
        {
            politicsPageRank.Add(turnFileToDocument("documents/politics/Backlash after Barack Obama EU referendum intervention.txt", Category.Politics));
            politicsPageRank.Add(turnFileToDocument("documents/politics/Migrant crisis Merkel and EU officials visit Turkey to promote deal.txt", Category.Politics));
            politicsPageRank.Add(turnFileToDocument("documents/politics/Syria conflict Truce in danger of collapse Obama and UN.txt", Category.Politics));
            economyPageRank.Add(turnFileToDocument("documents/economy/India's population explosion will make or break its economy.txt", Category.Politics));
            economyPageRank.Add(turnFileToDocument("documents/economy/Saudi Arabia racing to raise tons of cash.txt", Category.Economy));
            economyPageRank.Add(turnFileToDocument("documents/economy/Stocks haven't been this expensive in 7 years.txt", Category.Economy));
            sportsPageRank.Add(turnFileToDocument("documents/technology/Alcatel's new tablet offers Android Marshmallow and LTE for $130.txt", Category.Technology));
            sportsPageRank.Add(turnFileToDocument("documents/technology/Government withdraws from New York iPhone unlocking case.txt", Category.Technology));
            sportsPageRank.Add(turnFileToDocument("documents/technology/Windows 10 testers can now try Windows Ink and lots more features.txt", Category.Technology));
            technologyPageRank.Add(turnFileToDocument("documents/sports/Kevin Friend Which teams do Premier League referees support.txt", Category.Technology));
            technologyPageRank.Add(turnFileToDocument("documents/sports/Premier League and Football League Ups and downs.txt", Category.Technology));
            technologyPageRank.Add(turnFileToDocument("documents/sports/Roberto Martinez Everton boss faces critical FA Cup match.txt", Category.Technology));
        }

        Document turnFileToDocument(string address,Category category)
        {
            string[] logFile = File.ReadAllLines(address);
            Document LogList = new Document(address,category,logFile);
            return LogList;
        }
        private Document turnFileToDocument(string address)
        {
            string[] logFile = File.ReadAllLines(address);
            Document LogList = new Document(address, logFile);
            return LogList;
        }

        FileStream fileToOpen;

        private void filePicker_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = false;
            file.ShowDialog();

            filePath.Text = file.FileName;

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            fileToOpen = new FileStream(filePath.Text, FileMode.Open);
            kNearestNeighbor();
            NaiveBaise();
            rocchioCalculate();
            pageRank();
        }

        private void pageRank()
        {
            //VectorSpaceModel.Components.VectorSpaceModel vsm = new VectorSpaceModel.Components.VectorSpaceModel(politics.ElementAt(1), politics.ElementAt(0));
        }

        private void rocchioCalculate()
        { 
            List<Document> listOfAllDocuments = new List<Document>();
            listOfAllDocuments.AddRange(politicsRocchio);
            listOfAllDocuments.AddRange(sportsRocchio);
            listOfAllDocuments.AddRange(technologyRocchio);
            listOfAllDocuments.AddRange(economyRocchio);
            Corpus corpusOfAllDocuments = new Corpus(listOfAllDocuments.ToArray());
            List<Centroid> listOfCentroids = corpusOfAllDocuments.calculateCentroids();
            double closestCentroidDistance = double.MaxValue;
            Category closestCentroid = Category.unassigned;
            Document documentToAdd = new Document(filePath.Text, File.ReadAllLines(filePath.Text));
            foreach(Centroid centroid in listOfCentroids)
            {
                double distance = centroid.AugumentedSimilarity(documentToAdd, corpusOfAllDocuments._documents.Cast<VectorSpaceModel.Components.Vector>().ToList());
                if (distance > closestCentroidDistance)
                {
                    closestCentroidDistance = distance;
                    closestCentroid = centroid.category;
                }
            }

            if (closestCentroid==Category.Politics)
            {
                rocchio.Content = "Politics";
                politicsRocchio.Add(documentToAdd);
            } else if (closestCentroid == Category.Economy)
            {
                rocchio.Content = "Economy";
                politicsRocchio.Add(documentToAdd);
            }
            else if (closestCentroid == Category.Sports)
            {
                rocchio.Content = "Sports";
                politicsRocchio.Add(documentToAdd);
            }
            else if (closestCentroid == Category.Economy)
            {
                rocchio.Content = "Economy";
                politicsRocchio.Add(documentToAdd);
            }



        }

        private void NaiveBaise()
        {
            Dictionary<string, double> classification = naiveBayseClassifier.Classify(new System.IO.StreamReader(filePath.Text));
            string category = "";
            double maxValue = Double.MinValue;
            foreach (KeyValuePair<string, double> item in classification)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                    category = item.Key;
                }
            }
            naiveBaiseResult.Content = category;
            System.IO.StreamReader addFileStreamReader = new StreamReader(filePath.Text);
            if (category.Equals("Politics"))
            {
                naiveBayseClassifier.TeachCategory("Politics", addFileStreamReader);
            }
            else if (category.Equals("Economy"))
            {
                naiveBayseClassifier.TeachCategory("Economy", addFileStreamReader);
            }
            else if (category.Equals("Sports"))
            {
                naiveBayseClassifier.TeachCategory("Sports", addFileStreamReader);
            }
            else if (category.Equals("Technology"))
            {
                naiveBayseClassifier.TeachCategory("Technology", addFileStreamReader);
            }
            
        }

        private void kNearestNeighbor()
        {

            Document documentToParse = turnFileToDocument(filePath.Text);
            List<VectorSpaceModel.Components.Vector> listOfAllDocuments = new List<VectorSpaceModel.Components.Vector>();
            listOfAllDocuments.AddRange(politicsKNearest);
            listOfAllDocuments.AddRange(sportsKNearest);
            listOfAllDocuments.AddRange(economyKNearest);
            listOfAllDocuments.AddRange(technologyKNearest);
            Dictionary<Document, double> listOfDistances = new Dictionary<Document, double>();
            foreach (Document document in listOfAllDocuments)
            {
                listOfDistances.Add(document,documentToParse.AugumentedSimilarity(document,listOfAllDocuments));
            }
            List<KeyValuePair<Document,double>> sortedListOfDistances = (from kv in listOfDistances orderby kv.Value select kv).ToList();
            int sports = 0;
            int politics = 0;
            int technology = 0;
            int economy = 0;

            for (int i = 0; i < 5; i++)
            {
                KeyValuePair<Document, double> closeDocument = sortedListOfDistances.ElementAt(i);
                if (closeDocument.Key.category == Category.Sports)
                {
                    sports++;
                }
                else if (closeDocument.Key.category == Category.Politics)
                {
                    politics++;
                }
                else if (closeDocument.Key.category == Category.Technology)
                {
                    technology++;
                }
                else if(closeDocument.Key.category == Category.Economy)
                {
                    economy++;
                }else
                {
                    Console.WriteLine("Error: no category assigned for this document: " + closeDocument.Key.ID);
                }
            }


            if (sports > politics && sports > technology && sports > economy)
            {
                kNearestResult.Content = "sports";
                documentToParse.category = Category.Sports;
                sportsKNearest.Add(documentToParse);
            }
            else if (politics > sports && politics > technology && politics > economy)
            {
                kNearestResult.Content = "politics";
                documentToParse.category = Category.Politics;
                politicsKNearest.Add(documentToParse);
            }
            else if (technology > sports && technology > politics && technology > economy)
            {
                kNearestResult.Content = "technology";
                documentToParse.category = Category.Technology;
                technologyKNearest.Add(documentToParse);
            }
            else if (economy > sports && economy > technology && economy > politics)
            {
                kNearestResult.Content = "economy";
                documentToParse.category = Category.Economy;
                economyKNearest.Add(documentToParse);
            }

        }


    }
    public enum Category
    {
        Politics,Economy,Sports,Technology,unassigned
    }
    

}
