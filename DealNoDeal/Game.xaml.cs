using System;
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
/*Да се направи игра тип „Сделка или не“.
Автоматично (и случайно разпределение на определени суми в кутиите).
 Да се направи елементарен алгоритъм за предложенията на банкера.*/

namespace DealNoDeal
{
  
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
            SetBoxes();
            
        }

       // List<Box> bo = BoxData.CurentBoxesR;
        List<Box> bo = BoxData.CurentBoxes;
        List<Button> ButonBoxes =new List<Button>();
        

        //Seting function
        private void SetBoxes()
        {
            Box22.IsEnabled = false;

            foreach (Button btn in GameGrid.Children)
            {
                if (btn.Name.StartsWith("Box"))
                {
                    
                    btn.Content = bo[GameGrid.Children.IndexOf(btn)].boxNumber;
                    
                    ButonBoxes.Add(btn);
                    
                }
                
            }
            
        }
        //Swaping Function
        private void SwapBoxes(int boxToSwap)
        {
            foreach(Button sb in ButonBoxes)
            {
                if (sb.IsEnabled)
                {
                    if (int.Parse(sb.Content.ToString()) == boxToSwap)
                    {
                        Smqna.Visibility = Visibility.Hidden;
                        swapIndex.Visibility = Visibility.Hidden;
                        
                        NqmaZdelka.IsEnabled = false;

                        ListBoxItem SwapLog = new ListBoxItem
                        {
                            Content = ">>Сменихте кутия: " + Box22.Content + " за кутия: " + sb.Content
                        };
                        steps.Items.Add(SwapLog);
                        steps.ScrollIntoView(SwapLog);

                        int boxIndex = ButonBoxes.IndexOf(sb);


                        Box temp = bo[21];
                        bo[21] = bo[boxIndex];
                        bo[boxIndex] = temp;


                        Button tempbtn = new Button()
                        {
                            Content = Box22.Content
                        };
                        Box22.Content = sb.Content;
                        sb.Content = tempbtn.Content;


                    }
                   
                }
            }
        }
        //Starting rules
        public void Start()
        {
            
            ListBoxItem rule1 = new ListBoxItem
            {
                Content = "Отворете 5 кутии по избор."
            };
            steps.Items.Add(rule1);
            Smqna.Visibility = Visibility.Hidden;
            swapIndex.Visibility = Visibility.Hidden;
            offerLable.Visibility = Visibility.Hidden;
            Zdelka.IsEnabled = false;
            NqmaZdelka.IsEnabled = false;
        }




        private void GamePlay()
        {
            Zdelka.IsEnabled = false;
            NqmaZdelka.IsEnabled = false;
            Smqna.Visibility = Visibility.Hidden;
            swapIndex.Visibility = Visibility.Hidden;
            offerLable.Visibility = Visibility.Hidden;
            offerLable.Content = "";

            switch (BoxesOpened())
            {
                 
               
                case 5:
                    ListBoxItem fiveOpened = new ListBoxItem
                    {
                        Content = "Отворихте 5 кутии. Предстои оферта на Банкера"
                    };
                    steps.Items.Add(fiveOpened);
                    BankOffer();

                     break;
                case 9:
                    ListBoxItem nineOpened = new ListBoxItem
                    {
                        Content = "Отворихте 9 кутии. Предстои оферта на Банкера"
                    };
                    steps.Items.Add(nineOpened);
                    BankOffer();

                    break;
                case 12:
                    ListBoxItem twelveOpened = new ListBoxItem
                    {
                        Content = "Отворихте 12 кутии. Предстои оферта на Банкера"
                    };
                    steps.Items.Add(twelveOpened);
                    BankOffer();

                    break;
                case 14:
                    ListBoxItem fourteenOpened = new ListBoxItem
                    {
                        Content = "Отворихте 14 кутии. Предстои оферта на Банкера"
                    };
                    steps.Items.Add(fourteenOpened);
                    BankOffer();

                    break;
                case 16:
                    ListBoxItem sxsOpened = new ListBoxItem
                    {
                        Content = "Отворихте 16 кутии. Предстои оферта на Банкера"
                    };
                    steps.Items.Add(sxsOpened);
                    BankOffer();

                    break;
                case 18:
                    ListBoxItem eighteenOpened = new ListBoxItem
                    {
                        Content = "Отворихте 18 кутии. Предстои оферта на Банкера"
                    };
                    steps.Items.Add(eighteenOpened);
                    BankOffer();

                    break;
                case 20:
                    ListBoxItem twnOpened = new ListBoxItem
                    {
                        Content = "Отворихте 20 кутии. Предстои оферта на Банкера"
                    };
                    steps.Items.Add(twnOpened);
                    BankOffer();

                    break;


                case 21:
                    if(bo[21].boxValue == "Предмет")
                    {
                        MessageBox.Show("Честито вие спечелихте: " + bo[21].boxValue + "!");
                        Box22.Content = bo[21].boxValue;
                    }
                    else
                    {
                         MessageBox.Show("Честито вие спечелихте: "+bo[21].boxValue + "лева!");
                         Box22.Content = bo[21].boxValue;
                    }

                   
                    ListBoxItem endGame = new ListBoxItem
                    {
                        Content = "Честитоо! \n Вие завършихте играта. "
                    };
                    steps.Items.Add(endGame);
                    steps.ScrollIntoView(endGame);
                    MessageBox.Show("Започнете нова Игра.");
                    
                    this.Close();
                    break;
                default:
                    break;

            }
            
               
            
            

        }
        int BOInt =0;
        private void BankOffer()
        {
            
            NqmaZdelka.IsEnabled = true;
           Random rnd = new Random(DateTime.Now.Millisecond);
           int ofer = rnd.Next(1, 6);
            int[] pari = new int[5] { 200, 500, 800, 1000, 3000 };

            switch (ofer)
            {
                case 1:
                    Smqna.Visibility = Visibility.Visible;
                    swapIndex.Visibility = Visibility.Visible;
                    ListBoxItem Ofer1 = new ListBoxItem
                    {
                        Content = ">>Банкера ви предлага смяна на кутиите."
                    };
                    steps.Items.Add(Ofer1);
                    steps.ScrollIntoView(Ofer1);
                    break;
                case 2:
                    Zdelka.IsEnabled = true;
                    ListBoxItem Ofer2 = new ListBoxItem
                    {
                        Content = ">>Банкера ви предлага парична сума."
                    };
                    steps.Items.Add(Ofer2);
                    steps.ScrollIntoView(Ofer2);
                    offerLable.Visibility = Visibility.Visible;
                    int p = rnd.Next(5);
                    offerLable.Content = "Банкера ви предлага" + pari[p]+" Лева!";
                    BOInt = pari[p];

                    break;
                case 3:
                    Zdelka.IsEnabled = true;
                    ListBoxItem Ofer3 = new ListBoxItem
                    {
                        Content = ">>Банкера ви предлага парична сума."
                    };
                    steps.Items.Add(Ofer3);
                    steps.ScrollIntoView(Ofer3);
                    offerLable.Visibility = Visibility.Visible;
                    int q = rnd.Next(5);
                    offerLable.Content = "Банкера ви предлага" + pari[q] +" Лева!";
                    BOInt = pari[q];


                    break;
                case 4:
                    Smqna.Visibility = Visibility.Visible;
                    swapIndex.Visibility = Visibility.Visible;
                    ListBoxItem Ofer4 = new ListBoxItem
                    {
                        Content = ">>Банкера ви предлага смяна на кутиите."
                    };
                    steps.Items.Add(Ofer4);
                    steps.ScrollIntoView(Ofer4);
                    break;
                case 5:
                    Smqna.Visibility = Visibility.Visible;
                    swapIndex.Visibility = Visibility.Visible;
                    ListBoxItem Ofer5 = new ListBoxItem
                    {
                        Content = ">>Банкера ви предлага смяна на кутиите."
                    };
                    steps.Items.Add(Ofer5);
                    steps.ScrollIntoView(Ofer5);
                    break;
                default:
                    break;
                   
            }

            
        }

       
        private int BoxesOpened()
        {
            int openBoxes = -1;

            foreach (Button bt in ButonBoxes)
            {
                if(bt.IsEnabled == false)
                {
                    openBoxes++;
                }
               
            } 
            return openBoxes;
        }

        private void Smqna_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {

                int index = int.Parse(swapIndex.Text);
                if (index <= 22 && index >= 1)
                {
                    SwapBoxes(index);
                
                }
                else { MessageBox.Show("Въведете Номер на кутия от полето!"); }
            } catch(Exception ex)
            
            {
                MessageBox.Show("Въведете правилен номер на кутията!\n" + ex);
            }
            
            swapIndex.Clear();

        }


        private void Box1_Click(object sender, RoutedEventArgs e)
        {
            Box1.Content =">" +bo[0].boxValue +"<";
            Box1.IsEnabled = false;
            

            GamePlay();
            
        }

        private void Box2_Click(object sender, RoutedEventArgs e)
        {
            Box2.Content = ">" + bo[1].boxValue + "<";
            Box2.IsEnabled = false;
            GamePlay();
            
        }

        private void Box3_Click(object sender, RoutedEventArgs e)
        {
            Box3.Content = ">" + bo[2].boxValue + "<";
            Box3.IsEnabled = false;
            GamePlay();
           
        }

        private void Box4_Click(object sender, RoutedEventArgs e)
        {
            Box4.Content = ">" + bo[3].boxValue + "<";
            Box4.IsEnabled = false;
            GamePlay();
        }

        private void Box5_Click(object sender, RoutedEventArgs e)
        {
            Box5.Content = ">" + bo[4].boxValue + "<";
            Box5.IsEnabled = false;
            GamePlay();
        }

        private void Box6_Click(object sender, RoutedEventArgs e)
        {
            Box6.Content = ">" + bo[5].boxValue + "<";
            Box6.IsEnabled = false;
            GamePlay();
        }
               
        private void Box7_Click(object sender, RoutedEventArgs e)
        {
            Box7.Content = ">" + bo[6].boxValue + "<";
            Box7.IsEnabled = false;
            GamePlay();
        }

        private void Box8_Click(object sender, RoutedEventArgs e)
        {
            Box8.Content = ">" + bo[7].boxValue + "<";
            Box8.IsEnabled = false;
            GamePlay();
        }

        private void Box9_Click(object sender, RoutedEventArgs e)
        {
            Box9.Content = ">" + bo[8].boxValue + "<";
            Box9.IsEnabled = false;
            GamePlay();
        }

        private void Box10_Click(object sender, RoutedEventArgs e)
        {
            Box10.Content = ">" + bo[9].boxValue + "<";
            Box10.IsEnabled = false;
            GamePlay();
        }

        private void Box11_Click(object sender, RoutedEventArgs e)
        {
            Box11.Content = ">" + bo[10].boxValue + "<";
            Box11.IsEnabled = false;
            GamePlay();
        }

        private void Box12_Click(object sender, RoutedEventArgs e)
        {
            Box12.Content = ">" + bo[11].boxValue + "<";
            Box12.IsEnabled = false;
            GamePlay();
        }

        private void Box13_Click(object sender, RoutedEventArgs e)
        {
            Box13.Content = ">" + bo[12].boxValue + "<";
            Box13.IsEnabled = false;
            GamePlay();
        }

        private void Box14_Click(object sender, RoutedEventArgs e)
        {
            Box14.Content = ">" + bo[13].boxValue + "<";
            Box14.IsEnabled = false;
            GamePlay();
        }

        private void Box15_Click(object sender, RoutedEventArgs e)
        {
            Box15.Content = ">" + bo[14].boxValue + "<";
            Box15.IsEnabled = false;
            GamePlay();
        }

        private void Box16_Click(object sender, RoutedEventArgs e)
        {
            Box16.Content = ">" + bo[15].boxValue + "<";
            Box16.IsEnabled = false;
            GamePlay();
        }

        private void Box17_Click(object sender, RoutedEventArgs e)
        {
            Box17.Content = ">" + bo[16].boxValue + "<";
            Box17.IsEnabled = false;
            GamePlay();
        }

        private void Box18_Click(object sender, RoutedEventArgs e)
        {
            Box18.Content = ">" + bo[17].boxValue + "<";
            Box18.IsEnabled = false;
            GamePlay();
        }

        private void Box19_Click(object sender, RoutedEventArgs e)
        {
            Box19.Content = ">" + bo[18].boxValue + "<";
            Box19.IsEnabled = false;
            GamePlay();
        }

        private void Box20_Click(object sender, RoutedEventArgs e)
        {
            Box20.Content = ">" + bo[19].boxValue + "<";
            Box20.IsEnabled = false;
            GamePlay();
        }

        private void Box21_Click(object sender, RoutedEventArgs e)
        {
            Box21.Content = ">" + bo[20].boxValue + "<";
            Box21.IsEnabled = false;
            GamePlay();
        }

        private void Box22_Click(object sender, RoutedEventArgs e)
        {
            Box22.Content = ">" + bo[21].boxValue + "<";

        }


        private void Zdelka_Click(object sender, RoutedEventArgs e)
        {
            
            if(offerLable.Content.ToString() == "")
            {
              //MessageBox.Show("Cestito vie specelihte: " + bo[21].boxValue + "leva!");
              //Box22.Content = bo[21].boxValue;
                
            }
            else
            {
                MessageBox.Show("Честито вие спечелихте: " + BOInt + "лева!");
            }
            
            
            foreach(Button bn in ButonBoxes)
            {
                bn.IsEnabled = false;
                bn.Content = bo[ButonBoxes.IndexOf(bn)].boxValue;
            }

            MessageBox.Show("Започнете нова Игра.");

            this.Close();
        }

        private void NqmaZdelka_Click(object sender, RoutedEventArgs e)
        {
            Zdelka.IsEnabled = false;
            NqmaZdelka.IsEnabled = false;
            Smqna.Visibility = Visibility.Hidden;
            swapIndex.Visibility = Visibility.Hidden;
            offerLable.Visibility = Visibility.Hidden;

            ListBoxItem NoDeal = new ListBoxItem
            {
                Content = "Няма Зделка!!!\n Продължете с отварянето."
            };
            steps.Items.Add(NoDeal);
            steps.ScrollIntoView(NoDeal);
        }


        
    }



}
