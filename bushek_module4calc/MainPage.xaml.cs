namespace bushek_module4calc
{
    public partial class MainPage : ContentPage
    {
        bool maleSelected = false;
        bool femaleSelected = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void heightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            heightLabel.Text = ((int)e.NewValue) + "in";
        }

        private void weightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            weightLabel.Text = ((int)e.NewValue) + "Lbs";
        }

        private void maleTap_Tapped(object sender, EventArgs e)
        {
            maleSelected = true;
            femaleSelected = false;
            maleBorder.Stroke = Colors.Blue;
            femaleBorder.Stroke = Colors.Transparent;
        }

        private void femaleTap_Tapped(object sender, EventArgs e)
        {
            maleSelected = false;
            femaleSelected = true;
            maleBorder.Stroke = Colors.Transparent;
            femaleBorder.Stroke = Colors.Red;
        }

        private async void calculateBtn_Clicked(object sender, EventArgs e)
        {
            double bmi = (weightSlider.Value * 703) / (heightSlider.Value * heightSlider.Value);
            string bmiString = bmi.ToString("0.00");

            if (!maleSelected && !femaleSelected)
            {
                await DisplayAlert("Error", "Please select a gender.", "OK");
                return;
            }

            if (bmi < 18.5)
            {
                await DisplayAlert("BMI Result",
                    "Your BMI is " + bmiString +
                    "\nHealth Status: Underweight" +
                    "\nRecommendations: Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains)." +
                    "\nIncorporate strength training to build muscle mass." +
                    "\nConsult your doctor before taking any actions. BMI does not consider body composition.",
                    "OK");
            }
            else if (bmi < 25)
            {
                await DisplayAlert("BMI Result",
                    "Your BMI is " + bmiString +
                    "\nHealth Status: Normal weight" +
                    "\nRecommendations: Maintain a balanced diet with proteins, healthy fats, and fiber." +
                    "\nStay physically active with at least 150 minutes of exercise per week." +
                    "\nConsult your doctor before taking any actions. BMI does not consider body composition.",
                    "OK");
            }
            else if (bmi < 30)
            {
                await DisplayAlert("BMI Result",
                    "Your BMI is " + bmiString +
                    "\nHealth Status: Overweight" +
                    "\nRecommendations: Reduce processed foods and focus on portion control." +
                    "\nEngage in regular aerobic exercises (e.g., jogging, swimming) and strength training." +
                    "\nDrink plenty of water and track your progress." +
                    "\nConsult your doctor before taking any actions. BMI does not consider body composition.",
                    "OK");
            }
            else
            {
                await DisplayAlert("BMI Result",
                    "Your BMI is " + bmiString +
                    "\nHealth Status: Obese" +
                    "\nRecommendations: Consult a doctor for personalized guidance." +
                    "\nStart with low-impact exercises (e.g., walking, cycling)." +
                    "\nFollow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes." +
                    "\nAvoid sugary drinks and maintain a consistent sleep schedule." +
                    "\nConsult your doctor before taking any actions. BMI does not consider body composition.",
                    "OK");
            }
        }
    }
}