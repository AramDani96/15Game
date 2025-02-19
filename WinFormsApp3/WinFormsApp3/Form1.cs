namespace WinFormsApp3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            List<Button> buttons = new List<Button>() {button1,button2, button3, button4, button5, button6,
                button7, button8, button9, button10, button11, button12, button13, button14, button15, button16 };
            int[] ints = RandombuttonText();
            int count = 0;

            foreach (Button button in buttons)
            {
                if (ints[count] != 16)
                {
                    button.Text = ints[count].ToString();
                    
                }
                else
                {
                    button.Text = "";
                }
                count++;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
       
        private void Click_Button(object sender, EventArgs e)
        {
            Button temp = new Button();
            var button = (Button)sender;
            Button[,] Buttons = new Button[4, 4]{ { button1, button2, button3, button4 }, {button5, button6,
                button7, button8 }, {button9, button10, button11, button12 }, {button13, button14, button15, button16 } };

            if (button.Text != null)
            {
                for (int i = 0; i < Buttons.GetLength(0); i++)
                {
                    for (int j = 0; j < Buttons.GetLength(1); j++)
                    {
                            if (i - 1 >= 0 && Buttons[i - 1, j].Text == "")
                            {
                                temp.Text = button.Text;
                                button.Text = "";
                                Buttons[i - 1, j].Text = temp.Text;
                                return;
                            }
                            else if (i + 1 <= 3 && Buttons[i + 1, j].Text == "")
                            {
                                temp.Text = button.Text;
                                button.Text = "";
                                Buttons[i + 1, j].Text = temp.Text;
                                return;
                            }
                            else if (j - 1 >= 0 && Buttons[i, j - 1].Text == "")
                            {
                                temp.Text = button.Text;
                                button.Text = "";
                                Buttons[i, j - 1].Text = temp.Text;
                                return;
                            }
                            else if (j + 1 <= 3 && Buttons[i, j + 1].Text == "")
                            {
                                temp.Text = button.Text;
                                button.Text = "";
                                Buttons[i, j + 1].Text = temp.Text;
                                return;
                            }
                    }
                }
            }

            if (WinGame(Buttons))
            {
                MessageBox.Show("Win");
            }
        }
        private bool WinGame(Button[,] buttons)
        {
            int count = 1;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j].Text != count.ToString())
                    {
                        return false;
                    }
                    count++;
                }
            }
            return true;
        }

        private int[] RandombuttonText()
        {
            int[] numbers = new int[16];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            Random random = new Random();

            for (int i = 15; i > 0; i--)
            { 
            int j = random.Next(i+1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            return numbers;
        }
    }
}
