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

    public partial class Page1 : PhoneApplicationPage
    {
        private CardInfo[] cards = new CardInfo[8];
        Card[] table = new Card[Const.PLACES_ON_TABLE];
        Player player = new Player();
        Player cpu = new Player();
        Game myGame = new Game();
        int step = 0;
        Random rgn = new Random();
        bool PBegin = false;

        public Page1()
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
                updateTiles(pc.getPosition(), carri);
                table[pc.getPosition()] = cpu.hand[pc.getCard()];
                cpu.hand[pc.getCard()] = null;
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

                    if (table[index] == null && PBegin==false)
                    {
                        if (player.hand[k] == null) continue;
                        Card carro = new Card();
                        carro.clone(player.hand[k]);
                        updateTiles(index, carro);
                        table[index] = player.hand[k];
                        player.hand[k] = null;
                        hideFromHand(k);
                        myGame.setCardsOnTable(table);
                        step++;

                       
                       if(step!=8){

                        PositionAndCard pc = CPUBrain.generateMoveWithModel(myGame, cpu);
                        if (cpu.hand[pc.getCard()] == null) continue;
                        Card carri = new Card();
                        carri.clone(cpu.hand[pc.getCard()]);
                        updateTiles(pc.getPosition(), carri);
                        table[pc.getPosition()] = cpu.hand[pc.getCard()];
                        cpu.hand[pc.getCard()] = null;
                        
                        break;
                       }
                    }

                    if (table[index] == null && PBegin == true)
                    {
                        if (player.hand[k] == null) continue;
                        Card carro = new Card();
                        carro.clone(player.hand[k]);
                        updateTiles(index, carro);
                        table[index] = player.hand[k];
                        player.hand[k] = null;
                        hideFromHand(k);
                        myGame.setCardsOnTable(table);
                        

                            PositionAndCard pc = CPUBrain.generateMoveWithModel(myGame, cpu);
                            if (cpu.hand[pc.getCard()] == null) continue;
                            Card carri = new Card();
                            carri.clone(cpu.hand[pc.getCard()]);
                            updateTiles(pc.getPosition(), carri);
                            table[pc.getPosition()] = cpu.hand[pc.getCard()];
                            cpu.hand[pc.getCard()] = null;
                        step++;
                        break;
                        
                    }
                    //else if (table[index] == null && PBegin == false)
                    //{
                    //    PositionAndCard pc = CPUBrain.generateMoveWithModel(myGame, cpu);
                    //    if (cpu.hand[pc.getCard()] == null) continue;
                    //    Card carri = new Card();
                    //    carri.clone(cpu.hand[pc.getCard()]);
                    //    updateTiles(pc.getPosition(), carri);
                    //    table[pc.getPosition()] = cpu.hand[pc.getCard()];
                    //    cpu.hand[pc.getCard()] = null;
                    //    step++;

                    //    if (step != 8)
                    //    {

                    //        if (player.hand[k] == null) continue;
                    //        Card carro = new Card();
                    //        carro.clone(player.hand[k]);
                    //        updateTiles(index, carro);
                    //        table[index] = player.hand[k];
                    //        player.hand[k] = null;
                    //        hideFromHand(k);
                    //        myGame.setCardsOnTable(table);
                    //        break;

                    //    }


                    //}
                    break;
                }
            }


            if (step == 8)
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
                MessageBoxResult Result = MessageBox.Show(Const.RETRY, res, MessageBoxButton.OK);
                switch (Result)
                {
                    case MessageBoxResult.OK:
                        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
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

            //Controlla carte adiacenti
            bool isCPUMove = false;
            if (newCard.isBlue()) isCPUMove = true;
            int tmpIndex=0;

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
                    Image img2 = (Image)this.FindName(target2);


                    img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;

                }
            }

            tmpIndex = myGame.leftPositionWRTLocation(index);
            if (tmpIndex!=-1 && table[tmpIndex] != null && table[tmpIndex].rightValue < newCard.leftValue)
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
                    Image img2 = (Image)this.FindName(target2);


                    img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;

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
                    Image img2 = (Image)this.FindName(target2);


                    img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;

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
                    Image img2 = (Image)this.FindName(target2);


                    img2.Source = new ImageSourceConverter().ConvertFromString(targetSource2) as ImageSource;

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
            MessageBoxResult Result = MessageBox.Show(Const.RETRY, "prova", MessageBoxButton.OKCancel);
            
            if (Result == MessageBoxResult.Cancel)
                        e.Cancel = true;
            
        }

    }
}