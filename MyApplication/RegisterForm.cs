﻿
using System.Linq;
using System.Windows.Forms;

namespace MyApplication
{
    public partial class RegisterForm : Infrastructure.BaseForm
    {
        private object usernameTextbo;

        public RegisterForm()
        {
            InitializeComponent();
        }


        private void loginButton_Click(object sender, System.EventArgs e)
        {
            // **************************************************
            // **************************************************
            // **************************************************
            // علامت|| علامت یای منطقی است
            //برای بررسی پر یا خالی بودن کنترل های فرم ، کدهای زیر را استفاده می کنیم
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                //usernameTextBox.Text =
                //	usernameTextBox.Text.Trim();

                //passwordTextBox.Text =
                //	passwordTextBox.Text.Trim();

                usernameTextBox.Text =
                    usernameTextBox.Text.Replace(" ", string.Empty);

                passwordTextBox.Text =
                    passwordTextBox.Text.Replace(" ", string.Empty);

                System.Windows.Forms.MessageBox.Show("Username and Password is requied!");

                if (usernameTextBox.Text == string.Empty)
                {
                    usernameTextBox.Focus();
                }
                else
                {
                    passwordTextBox.Focus();
                }

                return;
            }
            // **************************************************
            // **************************************************
            // **************************************************

            // از این قسمت به بعد باید سر کلاس نوشته شود

            Models.DatabaseContext databaseContext = null;

            try
            {
                databaseContext =
                    new Models.DatabaseContext();

                Models.User foundedUser =
                    databaseContext.Users
                    //در دستور زیر به معنی این است که بزرگی و کوچکی حروف برای ما مهم نیستTrue
                    .Where(current => string.Compare(current.Username, usernameTextBox.Text, true) == 0)
                   .FirstOrDefault();

                if (foundedUser == null)
                {
                    //System.Windows.Forms.MessageBox
                    //	.Show("Username is not correct!");
                    // دقت کنید که در این حالت پیغام باید گنگ باشد

                    System.Windows.Forms.MessageBox
                        .Show("Username and/or Password is not correct!");

                    usernameTextBox.Focus();

                    return;
                }


                if (string.Compare(foundedUser.Password, passwordTextBox.Text, ignoreCase: false) != 0)
                {
                    //System.Windows.Forms.MessageBox
                    //	.Show("Password is not correct!");

                    // دقت کنید که در این حالت پیغام باید گنگ باشد

                    System.Windows.Forms.MessageBox
                        .Show("Username and/or Password is not correct!");

                    usernameTextBox.Focus();

                    return;
                }


                if (foundedUser.IsActive == false)
                {
                    System.Windows.Forms.MessageBox
                        .Show("You can not login to this application! Please contact support team.");

                    usernameTextBox.Focus();

                    return;
                }

                // **************************************************
                // **************************************************
                // **************************************************
                System.Windows.Forms.MessageBox.Show("Welcome!");
                // **************************************************

                // **************************************************
                //Infrastructure.Utility.AuthenticatedUser = foundedUser;

                //Hide();
                // **************************************************

                // **************************************************
                //MainForm mainForm = new MainForm();

                //mainForm.InitializeMainForm();

                //mainForm.Show();
                // **************************************************

                // **************************************************
                //Infrastructure.Utility.MainForm.InitializeMainForm();

                //Infrastructure.Utility.MainForm.Show();
                // **************************************************
                // **************************************************
                // **************************************************
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (databaseContext != null)
                {
                    databaseContext.Dispose();
                    databaseContext = null;
                }
            }
            ////******************************************************
            ////******************************************************
            ////******************************************************
            //if ((string.IsNullOrWhiteSpace(usernameTextBox.Text)) ||
            //    (string.IsNullOrWhiteSpace(passwordTextBox.Text)))
            //{
            //    //usernameTextBox.Text = usernameTextBox.Text.Trim();
            //    //passwordTextBox.Text = passwordTextBox.Text.Trim();

            //    usernameTextBox.Text = usernameTextBox.Text.Replace(" ", string.Empty);
            //    passwordTextBox.Text = passwordTextBox.Text.Replace(" ", string.Empty);

            //    System.Windows.Forms.MessageBox.Show("Username And Password Is Required");
            //    if (usernameTextBox.Text==string.Empty)
            //    {
            //        usernameTextBox.Focus();
            //    }
            //    else
            //    {
            //        passwordTextBox.Focus();
            //    }

            //    return ;
            //}
            ////******************************************************
            ////******************************************************
            ////******************************************************
        }

        private void resetButton_Click(object sender, System.EventArgs e)
        {
            resetForm();
        }

        private void resetForm()
        {
            usernameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
            fullnameTextBox.Text = string.Empty;

            usernameTextBox.Focus();
        }


        

        private void registerButton_Click(object sender, System.EventArgs e)
        {
            Models.DatabaseContext databaseContext = null;

            try
            {
                databaseContext = new Models.DatabaseContext();
                Models.User user =
                    databaseContext.Users
                    .Where(current => string.Compare(current.Username, usernameTextBox.Text, true) == 0)
                    .FirstOrDefault();

                if (user != null) ; 
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void exitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}

