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
        bool stopCheckAdj; //needed. Don't touch it!
        int[] checkDone = new int[4]; 
        Player player = new Player();
        Player cpu = new Player();
        Game myGame = new Game();
        int step = 0;
        Random rgn = new Random();
        bool PBegin = false;

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
                MessageBox.Show("Player begins");
            }
            else
            {
                PBegin = false;
                MessageBox.Show("CPU begins");
            }

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
                stopCheckAdj = false;

            tmpIndex = myGame.abovePositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].downValue < newCard.upValue)
            {
                stopCheckAdj = true;
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

            //while (stopCheckAdj) { } //this make it wait until previous check is performed
            tmpIndex = myGame.leftPositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].rightValue < newCard.leftValue)
            {
                stopCheckAdj = true;
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

           // while (stopCheckAdj) { } //this make it wait until previous check is performed
            tmpIndex = myGame.belowPositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].upValue < newCard.downValue)
            {
                stopCheckAdj = true;
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

           // while (stopCheckAdj) { } //this make it wait until previous check is performed
            tmpIndex = myGame.rightPositionWRTLocation(index);
            if (tmpIndex != -1 && table[tmpIndex] != null && table[tmpIndex].leftValue < newCard.rightValue)
            {
                stopCheckAdj = true;
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

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Go back?", "Exit menu", MessageBoxButton.OKCancel);
            
            if (Result == MessageBoxResult.Cancel)
                        e.Cancel = true;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String id = "";
            if(NavigationContext.QueryString.TryGetValue("id",out id)){
               if(NavigationService.CanGoBack) {
                    NavigationService.RemoveBackEntry();
                }
            }


            //MessageBox.Show("Sono qua");
            //if(e.Uri==(new Uri("/RandomGame.xaml", UriKind.Relative))){
            //    MessageBox.Show("Sono proprio qua");
            //    NavigationService.RemoveBackEntry();
             // }   
                
            
        }

        private void CardOnTable_Completed(object sender, EventArgs e)
        {
            if (playerPlayed && step <= 16)
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
                    res = Const.CPU_WINS;
                if (counterBlue < counterRed)
                    res = Const.PLAYER_WINS;
                if (counterRed == counterBlue)
                    res = Const.TIES;
                MessageBoxResult Result = MessageBox.Show(Const.RETRY, res, MessageBoxButton.OKCancel);
                switch (Result)
                {
                    case MessageBoxResult.OK:
                        NavigationService.Navigate(new Uri(String.Format("/RandomGame.xaml?id={0}", Guid.NewGuid().ToString()), UriKind.Relative));
                        break;

                    case MessageBoxResult.Cancel:
                        NavigationService.GoBack();
                        break;
                }
                return;
            }
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
            int i , j;

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

            stopCheckAdj = false;
        }

    }
}