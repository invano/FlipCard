using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using System.Windows.Media.Animation;
using Microsoft.Phone.Tasks;
using System.Windows.Resources;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;

namespace FlipCard_WP
{

    public struct CardInfo
    {
        public string name;
        public Image img;
        public string source;
        public bool isUp;
    }

    public partial class RandomGame : PhoneApplicationPage
    {
        private CardInfo[] cards = new CardInfo[8];
        Card[] table = new Card[Const.PLACES_ON_TABLE];
        bool playerPlayed; //states if the last move was made by the player or by the CPU
        int[] tiltBackIndex = new int[4]; //needed to perform the tiltback animation
        string[] tmpPath= new string[4]; //needed to perform the tiltback animation
        Image[] img2 = new Image[4]; //needed to perform the tilt animation
        int[] checkDone = new int[4]; 
        Player player = new Player();
        Player cpu = new Player();
        Game myGame = new Game();
        int step = 0;
        Random rgn = new Random();
        bool PBegin = false;
        IsolatedStorageSettings appStats = IsolatedStorageSettings.ApplicationSettings;

        int playerOverall = 0;
        int cpuOverall = 0;
        bool shared = false;

        public RandomGame()
        {
            InitializeComponent();

           

            cards[0].img = Card0;
            cards[0].name = "Card0";
            cards[1].img = Card1;
            cards[1].name = "Card1";
            cards[2].img = Card2;
            cards[2].name = "Card2";
            cards[3].img = Card3;
            cards[3].name = "Card3";
            cards[4].img = Card4;
            cards[4].name = "Card4";
            cards[5].img = Card5;
            cards[5].name = "Card5";
            cards[6].img = Card6;
            cards[6].name = "Card6";
            cards[7].img = Card7;
            cards[7].name = "Card7";

            updateScore();
 

            CardsLibrary cardsLibrary = new CardsLibrary();
            Deck playerDeck = cardsLibrary.generateRandomDeckWithSize(40);
            playerDeck.set_no_cards(40);
            Deck cpuDeck  = cardsLibrary.generateRandomDeckWithSize(40);
            cpuDeck.set_no_cards(40);

            DeckShuffle.Shuffle<Card>(playerDeck.cardArray);
            DeckShuffle.Shuffle<Card>(cpuDeck.cardArray);

            player.hand = new Card[8];
            cpu.hand = new Card[8];
              
            for (int i = 0; i < 8; i++)
            {
                
                player.hand[i] = playerDeck.getRandomCard();
                player.hand[i].setColor(Const.RED);
                updateHand(i, player.hand[i]);
                cpu.hand[i] = cpuDeck.getRandomCard();
                cpu.hand[i].setColor(Const.BLUE);
            }
            //GGfinqui
           
            int q = rgn.Next(1, 10);

            if (q % 2 == 0)
            {
                PBegin = true;
                spimage.ImageSource = new ImageSourceConverter().ConvertFromString("/Images/Misc/YouStart.png") as ImageSource;                
            }
            else
            {
                PBegin = false;
                spimage.ImageSource = new ImageSourceConverter().ConvertFromString("/Images/Misc/CPUStarts.png") as ImageSource;               
            }

            AnimateStart.Begin();

            if (PBegin == false)
            {
                PositionAndCard pc = CPUBrain.generateMoveWithModel(myGame, cpu);
                if (cpu.hand[pc.getCard()] != null) { 
                Card carri = new Card();
                carri.clone(cpu.hand[pc.getCard()]);
                playerPlayed = false; //should be set every time, before updatetiles is called
                updateTiles(pc.getPosition(), carri);
                table[pc.getPosition()] = cpu.hand[pc.getCard()];
                cpu.hand[pc.getCard()] = null;
                updateScore();
                step++;
            }
            }

           

        }

        private void Card_Tap(object sender, GestureEventArgs e)
        {
            Image img = (Image)sender;
            TranslateTransform translation;
            translation = new TranslateTransform();


            for (int i = 0; i < cards.Length; i++)
            {
                if (img.Name.Equals(cards[i].name))
                {
                    if (cards[i].isUp)
                    {
                        img.RenderTransform = translation;
                        translation.Y += 0;
                        cards[i].isUp = false;

                    }
                    else
                    {
                        for (int j = 0; j < cards.Length; j++)
                        {
                            if (cards[j].isUp)
                            {
                                Image img2 = cards[j].img;
                                TranslateTransform translation2 = new TranslateTransform();
                                img2.RenderTransform = translation2;
                                translation2.Y += 0;
                                cards[j].isUp = false;
                            }
                        }
                            img.RenderTransform = translation;
                        translation.Y -= 20;
                        cards[i].isUp = true;
                    }
                }
            }

        }

        private void board_Tap(object sender, GestureEventArgs e)
        {
            int index=0;
            Image img = (Image)sender;

            for (int k = 0; k < cards.Length; k++)
            {               
                if (cards[k].isUp)
                {
                    string s = img.Name;
                   
                    string[] words = s.Split('c');
                    index = Convert.ToInt32(words[1]);

                    if (table[index] == null)
                    {
                        if (player.hand[k] == null) continue;
                        Card carro = new Card();
                        carro.clone(player.hand[k]);
                        playerPlayed = true;
                        updateTiles(index, carro);
                        table[index] = carro;
                        player.hand[k] = null;
                        hideFromHand(k);
                        myGame.setCardsOnTable(table);
                        step++;
                        checkVictory();
                    }
                    break;
                }
            }


            

                
        }

        public void updateTiles(int index , Card newCard)
        {
            int tmp = newCard.idNumber;
            string targetSource = "/Assets/ImagesCards/Card" + tmp;
            if (newCard.isBlue()) targetSource += "Blue.png";
            else targetSource += "Red.png";

            string target = "c" + index;
            Image img = (Image)this.FindName(target);


            img.Source = new ImageSourceConverter().ConvertFromString(targetSource) as ImageSource;

            switch (index)
            {
                case 0:
                    CardOnTable0.Begin();
                    break;
                case 1:
                    CardOnTable1.Begin();
                    break;
                case 2:
                    CardOnTable2.Begin();
                    break;
                case 3:
                    CardOnTable3.Begin();
                    break;
                case 4:
                    CardOnTable4.Begin();
                    break;
                case 5:
                    CardOnTable5.Begin();
                    break;
                case 6:
                    CardOnTable6.Begin();
                    break;
                case 7:
                    CardOnTable7.Begin();
                    break;
                case 8:
                    CardOnTable8.Begin();
                    break;
                case 9:
                    CardOnTable9.Begin();
                    break;
                case 10:
                    CardOnTable10.Begin();
                    break;
                case 11:
                    CardOnTable11.Begin();
                    break;
                case 12:
                    CardOnTable12.Begin();
                    break;
                case 13:
                    CardOnTable13.Begin();
                    break;
                case 14:
                    CardOnTable14.Begin();
                    break;
                case 15:
                    CardOnTable15.Begin();
                    break;

            }

            //Controlla carte adiacenti
            bool isCPUMove = false;
            if (newCard.isBlue()) isCPUMove = true;
            int tmpIndex = 0;
            for (int u = 0; u < 4; u++)
            {
                checkDone[u] = 0;
            }

            tmpIndex = myGame.abovePositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].downValue < newCard.upValue)
            {
                int tmp2 = table[tmpIndex].idNumber;
                string targetSource2 = "/Assets/ImagesCards/Card" + tmp2;
                //table[tmpIndex].color != newCard.color
                if (true)
                {
                    if (isCPUMove)
                    {
                        newCard.color = 2;
                        targetSource2 += "Blue.png";
                        table[tmpIndex].setColor(Const.BLUE);
                    }
                    else
                    {
                        newCard.color = 1;
                        targetSource2 += "Red.png";
                        table[tmpIndex].setColor(Const.RED);
                    }
                    


                    string target2 = "c" + tmpIndex;

                    int t;
                    for (t = 0; t < 4; t++)
                    {
                        if (checkDone[t] == 0)
                        {
                            checkDone[t] = 1;
                            break;
                        }

                    }
                    //Use t to set global variables;
                    //img2 defined as a global variable
                    img2[t] = (Image)this.FindName(target2);

                    tiltBackIndex[t] = tmpIndex;
                    //tmpPath is a global string to be passed to the tiltBack method
                    tmpPath[t] = string.Copy(targetSource2);

                    tiltCardAtIndex(tmpIndex);

                    // img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;
                   
             
                }
            }

            tmpIndex = myGame.leftPositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].rightValue < newCard.leftValue)
            {
                int tmp2 = table[tmpIndex].idNumber;
                string targetSource2 = "/Assets/ImagesCards/Card" + tmp2;
                if (true)
                {
                    if (isCPUMove)
                    {
                        newCard.color = 2;
                        targetSource2 += "Blue.png";
                        table[tmpIndex].setColor(Const.BLUE);
                    }
                    else
                    {
                        newCard.color = 1;
                        targetSource2 += "Red.png";
                        table[tmpIndex].setColor(Const.RED);
                    }
                    string target2 = "c" + tmpIndex;

                     int t;
                    for (t = 0; t < 4; t++)
                    {
                        if (checkDone[t] == 0)
                        {
                            checkDone[t] = 1;
                            break;
                        }
                    }
                    //Use t to set global variables;
                    //img2 defined as a global variable
                    img2[t] = (Image)this.FindName(target2);

                    tiltBackIndex[t] = tmpIndex;
                    //tmpPath is a global string to be passed to the tiltBack method
                    tmpPath[t] = string.Copy(targetSource2);

                    tiltCardAtIndex(tmpIndex);

                    // img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;
                    
                }
            }

            tmpIndex = myGame.belowPositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].upValue < newCard.downValue)
            {
                int tmp2 = table[tmpIndex].idNumber;
                string targetSource2 = "/Assets/ImagesCards/Card" + tmp2;
                if (true)
                {
                    if (isCPUMove)
                    {
                        newCard.color = 2;
                        targetSource2 += "Blue.png";
                        table[tmpIndex].setColor(Const.BLUE);
                    }
                    else
                    {
                        newCard.color = 1;
                        targetSource2 += "Red.png";
                        table[tmpIndex].setColor(Const.RED);
                    }
                    string target2 = "c" + tmpIndex;

                     int t;
                    for (t = 0; t < 4; t++)
                    {
                        if (checkDone[t] == 0)
                        {
                            checkDone[t] = 1;
                            break;
                        }
                    }
                    //Use t to set global variables;
                    //img2 defined as a global variable
                    img2[t] = (Image)this.FindName(target2);

                    tiltBackIndex[t] = tmpIndex;
                    //tmpPath is a global string to be passed to the tiltBack method
                    tmpPath[t] = string.Copy(targetSource2);

                    tiltCardAtIndex(tmpIndex);

                    // img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;
                }
            }

            tmpIndex = myGame.rightPositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].leftValue < newCard.rightValue)
            {
                int tmp2 = table[tmpIndex].idNumber;
                string targetSource2 = "/Assets/ImagesCards/Card" + tmp2;
                if (true)
                {
                    if (isCPUMove)
                    {
                        newCard.color = 2;
                        targetSource2 += "Blue.png";
                        table[tmpIndex].setColor(Const.BLUE);
                    }
                    else
                    {
                        newCard.color = 1;
                        targetSource2 += "Red.png";
                        table[tmpIndex].setColor(Const.RED);
                    }
                    string target2 = "c" + tmpIndex;
                     int t;
                    for (t = 0; t < 4; t++)
                    {
                        if (checkDone[t] == 0)
                        {
                            checkDone[t] = 1;
                            break;
                        }
                    }
                    //Use t to set global variables;
                    //img2 defined as a global variable
                    img2[t] = (Image)this.FindName(target2);

                    tiltBackIndex[t] = tmpIndex;
                    //tmpPath is a global string to be passed to the tiltBack method
                    tmpPath[t] = string.Copy(targetSource2);

                    tiltCardAtIndex(tmpIndex);

                    // img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;
                }
            }
            updateScore();
            //int counterRed = 0;
            //int counterBlue = 0;
            //for (int h = 0; h < 16; h++)
            //{
            //    if (table[h] != null && table[h].color == Const.RED)
            //        counterRed++;
            //    if (table[h] != null && table[h].color == Const.BLUE)
            //        counterBlue++;
            //}

            //string tmpScore = "You " + counterRed + " | CPU " + counterBlue;
            //ActualScore.Text=tmpScore;


        }

        private void updateScore()
        {
            int counterRed = 0;
            int counterBlue = 0;
            for (int h = 0; h < 16; h++)
            {
                if (table[h] != null && table[h].color == Const.RED)
                    counterRed++;
                if (table[h] != null && table[h].color == Const.BLUE)
                    counterBlue++;
            }

            string tmpScoreYou = "You " + counterRed;
            string tmpScoreCpu = "CPU " + counterBlue;
            ActualScoreYou.Text = tmpScoreYou;
            ActualScoreCPU.Text = tmpScoreCpu;
        }

        public void updateHand(int index, Card newCard)
        {
           
            int tmp = newCard.idNumber;
            string targetSource = "/Assets/ImagesCards/Card" + tmp;
            if (newCard.isBlue()) targetSource += "Blue.png";
            else targetSource += "Red.png";

            string target = "Card" + index;
        
            Image img = (Image)this.FindName(target);
         
            img.Source = new ImageSourceConverter().ConvertFromString(targetSource) as ImageSource;
     

        }

        public void hideFromHand(int index)
        {
            string target = "Card" + index;
            Image img = (Image)this.FindName(target);
            img.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void sharestatus_Click(object sender, EventArgs e)
        {
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            String cpuwin = " CPU is beating me :(";
            String playerwin = " I'm winning! :D";
            String tie = " We're even! :)";
            String res = playerOverall.ToString() + " " + cpuOverall.ToString();
            if (cpuOverall == playerOverall)
                shareStatusTask.Status = "First twitter message from #FlipCard! " + res + tie;
            else
                shareStatusTask.Status = "First twitter message from #FlipCard! " + res + (cpuOverall > playerOverall ? cpuwin : playerwin);
            this.shared = true;
            shareStatusTask.Show();
        }


        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Go back?", "Exit menu", MessageBoxButton.OKCancel);
            
            if (Result == MessageBoxResult.Cancel)
                        e.Cancel = true;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String id = "";
            String cpuScore = "";
            String playerScore = "";

            if (NavigationContext.QueryString.TryGetValue("player", out playerScore))
                this.playerOverall = int.Parse(playerScore);

            if (NavigationContext.QueryString.TryGetValue("cpu", out cpuScore))
                this.cpuOverall = int.Parse(cpuScore);

            if (NavigationContext.QueryString.TryGetValue("id", out id))
            {
                if (NavigationService.CanGoBack && !this.shared)
                {
                    NavigationService.RemoveBackEntry();
                }
            }
        }

        private void CardOnTable_Completed(object sender, EventArgs e)
        {
            if (playerPlayed && step < 16)
            {

                PositionAndCard pc = CPUBrain.generateMoveWithModel(myGame, cpu);
                Card carri = new Card();
                carri.clone(cpu.hand[pc.getCard()]);
                playerPlayed = false;
                updateTiles(pc.getPosition(), carri);
                table[pc.getPosition()] = carri;
                cpu.hand[pc.getCard()] = null;
                step++;
                checkVictory();
            }

        }
        private void checkVictory()
        {
            if (step == 16)
            {

                int counterRed = 0;
                int counterBlue = 0;
                for (int h = 0; h < 16; h++)
                {
                    if (table[h].color == Const.RED)
                        counterRed++;
                    else
                        counterBlue++;
                }

                String res = null;
                if (counterRed < counterBlue)
                {
                    res = Const.CPU_WINS;
                    if (appStats.Contains("Losses"))
                {
                    int i = (int)appStats["Losses"];
                    i++;
                    appStats["Losses"] = i;
                    appStats["Row"] = 0;

                }
                    else
                    {
                        appStats.Add("Losses", 1);
                    }

                }
                if (counterBlue < counterRed)
                {
                    res = Const.PLAYER_WINS;
                    if (appStats.Contains("Wins"))
                {
                    int i = (int)appStats["Wins"];
                    i++;
                    appStats["Wins"] = i;
                    appStats["Row"] = (int)appStats["Row"] + 1;

                }
                    else
                    {
                        appStats.Add("Wins", 1);
                    }
                }
                if (counterRed == counterBlue){
                    res = Const.TIES;
                    if (appStats.Contains("Ties"))
                {
                    int i = (int)appStats["Ties"];
                    i++;
                    appStats["Ties"] = i;

                }
                    else
                    {
                        appStats.Add("Ties", 1);
                    }
                }

                updateScore();
                CheckStars();
                //MessageBox.Show("Wins: " + appStats["Wins"] + " Ties: " + appStats["Ties"] + " Losses: " + appStats["Losses"]);
                ExpandTopBar(res, Const.RETRY);
          return;
            }
        }

        void CheckStars(){
            switch ((int)appStats["Stars"])
                {
                    case 0:
                        if ((int)appStats["Row"] == 1)
                        {
                            appStats["Stars"] = 1;
                            appStats["Row"] = 0;
                            MessageBox.Show("Una stella");
                        }
                        break;
                    case 1:
                        if ((int)appStats["Row"] == 2)
                        {
                            appStats["Stars"] = 2;
                            appStats["Row"] = 0;
                            MessageBox.Show("Due stelle");
                        }
                        break;
                    case 2:
                        if ((int)appStats["Row"] == 3)
                        {
                            appStats["Stars"] = 3;
                            appStats["Row"] = 0;
                            MessageBox.Show("Tre stelle");
                        }
                        break;
                    case 3:
                        if ((int)appStats["Row"] == 4)
                        {
                            appStats["Stars"] = 4;
                            appStats["Row"] = 0;
                            MessageBox.Show("Quattro stelle");
                        }
                        break;
                    case 4:
                        if ((int)appStats["Row"] == 5)
                        {
                            appStats["Stars"] = 5;
                            appStats["Row"] = 0;
                            MessageBox.Show("Cinque stelle");
                        }
                        //call score...
                        break;
                }
            return;
        }


        private void tiltCardAtIndex(int index)
        {
            switch (index)
            {
                case 0:
                    Tilting0.Begin();
                    break;
                case 1:
                    Tilting1.Begin();
                    break;
                case 2:
                    Tilting2.Begin();
                    break;
                case 3:
                    Tilting3.Begin();
                    break;
                case 4:
                    Tilting4.Begin();
                    break;
                case 5:
                    Tilting5.Begin();
                    break;
                case 6:
                    Tilting6.Begin();
                    break;
                case 7:
                    Tilting7.Begin();
                    break;
                case 8:
                    Tilting8.Begin();
                    break;
                case 9:
                    Tilting9.Begin();
                    break;
                case 10:
                    Tilting10.Begin();
                    break;
                case 11:
                    Tilting11.Begin();
                    break;
                case 12:
                    Tilting12.Begin();
                    break;
                case 13:
                    Tilting13.Begin();
                    break;
                case 14:
                    Tilting14.Begin();
                    break;
                case 15:
                    Tilting15.Begin();
                    break;

            }
        }


        private void TiltBack_Completed(object sender, EventArgs e)
        {
            int i;

            for(i=0;i<4;i++){
                if(checkDone[i]==1){
                    checkDone[i]=2;
                    break;
                }

            }

            img2[i].Source = new ImageSourceConverter().ConvertFromString(tmpPath[i]) as ImageSource;
            switch (tiltBackIndex[i])
            {
                case 0:
                    TiltingBack0.Begin();
                    break;
                case 1:
                    TiltingBack1.Begin();
                    break;
                case 2:
                    TiltingBack2.Begin();
                    break;
                case 3:
                    TiltingBack3.Begin();
                    break;
                case 4:
                    TiltingBack4.Begin();
                    break;
                case 5:
                    TiltingBack5.Begin();
                    break;
                case 6:
                    TiltingBack6.Begin();
                    break;
                case 7:
                    TiltingBack7.Begin();
                    break;
                case 8:
                    TiltingBack8.Begin();
                    break;
                case 9:
                    TiltingBack9.Begin();
                    break;
                case 10:
                    TiltingBack10.Begin();
                    break;
                case 11:
                    TiltingBack11.Begin();
                    break;
                case 12:
                    TiltingBack12.Begin();
                    break;
                case 13:
                    TiltingBack13.Begin();
                    break;
                case 14:
                    TiltingBack14.Begin();
                    break;
                case 15:
                    TiltingBack15.Begin();
                    break;

            }
            updateScore();
        }

        private void ExpandTopBar(String title, String description)
        {
            Title_RetryPanel.Text = title;
            Description_RetryPanel.Text = description;
            if ((int)appStats["Stars"] < 5)
            {
                string tmp = "You have collected " + appStats["Stars"] + " star(s) so far... Win " + ((int)appStats["Stars"] + 1 - (int)appStats["Row"]) + " matches in a row to get a new star!";
     
                EndMatchStatsBox.Text = tmp;
            }
            else
            {
                string fin = "You got 5 stars! This is your final score: " + countScore(); 
                EndMatchStatsBox.Text = fin;
            }
            RetryPanel.Visibility = Visibility.Visible;
        }

        decimal countScore()
        {
            decimal score;

            decimal tmp = (1 / (int)appStats["Wins"] + 1 / (int)appStats["Losses"] +
                                1 / (int)appStats["Ties"] + (int)appStats["Losses"] / (int)appStats["Wins"]);
            decimal tmp2 = Math.Round(tmp);
            score = Math.Round(1/tmp)*10000;

            return score;
        }


        private void RetryButton_RetryPanel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(String.Format("/RandomGame.xaml?id={0}&player={1}&cpu={2}", Guid.NewGuid().ToString(), playerOverall.ToString(), cpuOverall.ToString()), UriKind.Relative));
        }

        private void CancelButton_RetryPanel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}