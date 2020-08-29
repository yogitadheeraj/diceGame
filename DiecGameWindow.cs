using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Dice_Game
{
	public partial class DiceGameWindow : Form
	{
		#region default Properties 
		string imgaePathName = System.AppDomain.CurrentDomain.BaseDirectory;
		Random rnumber = new Random();
		Button[] playerOneBtns = new Button[6];
		Button[] playerTwoBtns = new Button[6];
		Image[] diceImg = new Image[6];
		int playerOneScore;
		int playerTwoScore;
		Timer timer = new Timer();
		string startAnimation = "Start animation";
		string stopAnimation = "Stop animation";
		#endregion

		public DiceGameWindow()
		{
			InitializeComponent();
			imgaePathName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Assets\\");
			this.BackgroundImage = Image.FromFile(imgaePathName + "b5.jpg");

			timer.Interval = 1000;
			timer.Tick += new EventHandler(timer_Tick);
			timer.Start();
			button1.Text = stopAnimation;
		}

		private void DiceGameWindow_Load(object sender, EventArgs e)
		{
			OnLoadAndNewGame();
		}

		void timer_Tick(object sender, EventArgs e)
		{

			//set color in background  
			var colors = new[] { "b1.jpg", "b2.jpg", "b3.jpg", "b4.jpg", "b5.jpg" };
			var index = DateTime.Now.Second % colors.Length;
			this.BackgroundImage = Image.FromFile(imgaePathName + colors[index]);
		}
		private void btn_Player_One_roll_dice_Click(object sender, EventArgs e)
		{
			//player 1 roll 
			foreach (Button btn in playerOneBtns)
			{
				if (btn.Enabled == true)
				{
					int x = rnumber.Next(1, 7);
					btn.Text = x.ToString();
					btn.Image = diceImg[x - 1];
				}

			}
			playerOneRollDice();
		}
		private void btn_Player_two_roll_dice_Click(object sender, EventArgs e)
		{
			//player 2 roll 
			foreach (Button btn in playerTwoBtns)
			{
				if (btn.Enabled == true)
				{
					int x = rnumber.Next(1, 7);
					btn.Text = x.ToString();
					btn.Image = diceImg[x - 1];
				}
			}
			playerTwoRollDice();
		}
		private void playerOneRollDice()
		{
			try
			{
				int score = 0;
				foreach (Button btn in playerOneBtns)
				{
					if (!string.IsNullOrEmpty(btn.Text))
						score += Convert.ToInt32(btn.Text);
				}
				int roll = 30 - score;
				playerOneScore -= roll;
				if (playerOneScore <= 0)
				{
					labelPlayer1.Text = "Player One - WINNER";
					textToSpeech(labelPlayer1.Text);
					labelPlayer2.Text = "Player Two - 0";
					labelEndTime.Text = "Game End On : " + DateTime.Now.ToString("hh:mm:ss dddd MMMM dd, yyyy");
					labelPlayer1.ForeColor = System.Drawing.Color.Green;
					btn_Player_One_roll_dice.Enabled = false;
					btn_Player_two_roll_dice.Enabled = false;
					resetButton();
				}
				else
				{
					labelPlayer1.Text = "Player One - " + playerOneScore.ToString();
					btn_Player_One_roll_dice.Enabled = false;
					btn_Player_two_roll_dice.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, "playerOneRollDice Click");
			}
		}
		private void playerTwoRollDice()
		{
			try
			{
				int score = 0;
				foreach (Button btn in playerTwoBtns)
				{
					if (!string.IsNullOrEmpty(btn.Text))
						score += Convert.ToInt32(btn.Text);
				}
				int roll = 30 - score;
				playerTwoScore -= roll;
				if (playerTwoScore <= 0)
				{
					labelPlayer2.Text = "Player Two - WINNER";
					textToSpeech(labelPlayer2.Text);
					labelPlayer1.Text = "Player One - 0";
					labelPlayer2.ForeColor = System.Drawing.Color.Green;
					btn_Player_One_roll_dice.Enabled = false;
					btn_Player_two_roll_dice.Enabled = false;
					labelEndTime.Text = "Game End On : " + DateTime.Now.ToString("hh:mm:ss dddd MMMM dd, yyyy");
					resetButton();
				}
				else
				{
					labelPlayer2.Text = "Player Two - " + playerTwoScore.ToString();
					btn_Player_One_roll_dice.Enabled = true;
					btn_Player_two_roll_dice.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, "playerTwoRollDice Click");
			}
		}
		private void textToSpeech(string text)
		{
			SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
			speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
			speechSynthesizer.SetOutputToDefaultAudioDevice();
			speechSynthesizer.Volume = 100;  
			speechSynthesizer.Rate = 0;  
			PromptBuilder builder = new PromptBuilder();
			builder.AppendText(text);
			speechSynthesizer.Speak(builder);
			speechSynthesizer.Dispose();
		}
		private void btnPlyOne_one_Click(object sender, EventArgs e)
		{

			btnPlyOne_One.Enabled = false;
		}

		private void btnPlyOne_two_Click(object sender, EventArgs e)
		{
			btnPlyOne_two.Enabled = false;
		}

		private void btnPlyOne_three_Click(object sender, EventArgs e)
		{
			btnPlyOne_three.Enabled = false;
		}

		private void btnPlyOne_four_Click(object sender, EventArgs e)
		{
			btnPlyOne_four.Enabled = false;
		}

		private void btnPlyOne_five_Click(object sender, EventArgs e)
		{
			btnPlyOne_five.Enabled = false;
		}

		private void btnPlyOne_six_Click(object sender, EventArgs e)
		{
			btnPlyOne_six.Enabled = false;
		}

		private void btnPlyTwo_one_Click(object sender, EventArgs e)
		{
			btnPlyTwo_one.Enabled = false;
		}

		private void btnPlyTwo_two_Click(object sender, EventArgs e)
		{
			btnPlyTwo_two.Enabled = false;
		}

		private void btnPlyTwo_three_Click(object sender, EventArgs e)
		{
			btnPlyTwo_three.Enabled = false;
		}

		private void btnPlyTwo_four_Click(object sender, EventArgs e)
		{
			btnPlyTwo_four.Enabled = false;
		}

		private void btnPlyTwo_five_Click(object sender, EventArgs e)
		{
			btnPlyTwo_five.Enabled = false;
		}

		private void btnPlyTwo_six_Click(object sender, EventArgs e)
		{
			btnPlyTwo_six.Enabled = false;
		}

		private void btnNewGameStart_Click(object sender, EventArgs e)
		{
			OnLoadAndNewGame();
		}
		private void OnLoadAndNewGame()
		{

			labelStartTime.Text = "Game Start On : " + DateTime.Now.ToString("hh:mm:ss dddd MMMM dd, yyyy");
			playerOneScore = 30;
			labelPlayer1.ForeColor = labelPlayer2.ForeColor = System.Drawing.Color.Black;
			labelPlayer1.Text = "Player One - " + playerOneScore.ToString();
			playerTwoScore = 30;
			labelPlayer2.Text = "Player Two - " + playerTwoScore.ToString();
			resetButton();
			btn_Player_One_roll_dice.Enabled = true;
			btn_Player_two_roll_dice.Enabled = false;
		}
		private void resetButton()
		{

			try
			{
				playerOneBtns[0] = btnPlyOne_One;
				playerOneBtns[1] = btnPlyOne_two;
				playerOneBtns[2] = btnPlyOne_three;
				playerOneBtns[3] = btnPlyOne_four;
				playerOneBtns[4] = btnPlyOne_five;
				playerOneBtns[5] = btnPlyOne_six;
				playerTwoBtns[0] = btnPlyTwo_one;
				playerTwoBtns[1] = btnPlyTwo_two;
				playerTwoBtns[2] = btnPlyTwo_three;
				playerTwoBtns[3] = btnPlyTwo_four;
				playerTwoBtns[4] = btnPlyTwo_five;
				playerTwoBtns[5] = btnPlyTwo_six;
				foreach (Button btn in playerOneBtns)
				{
					btn.Text = "";
					btn.Enabled = true;
					btn.Image = null;
				}
				foreach (Button btn in playerTwoBtns)
				{
					btn.Text = "";
					btn.Enabled = true;
					btn.Image = null;
				}
				imgaePathName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Assets\\");
				diceImg[0] = Image.FromFile(imgaePathName + "d1.png");
				diceImg[1] = Image.FromFile(imgaePathName + "d2.png");
				diceImg[2] = Image.FromFile(imgaePathName + "d3.png");
				diceImg[3] = Image.FromFile(imgaePathName + "d4.png");
				diceImg[4] = Image.FromFile(imgaePathName + "d5.png");
				diceImg[5] = Image.FromFile(imgaePathName + "d6.png");
			}
			catch (Exception ex)
			{
				ErrorLogger.WriteToErrorLog(ex.Message, ex.StackTrace, "resetButton Click");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (button1.Text == stopAnimation)
			{
				button1.Text = startAnimation;
				timer.Stop();
			}
			else
			{
				timer.Start();
				button1.Text = stopAnimation;
			}
		}
	}
}