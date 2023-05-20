namespace ExpenseManagerDesktop
{
    public class FormManager : ApplicationContext
    {
        private Form CurrentForm;

        public FormManager()
        {

        }

        public FormManager(Form currentForm)
        {
            CurrentForm = currentForm;
            CurrentForm.FormClosed += (sender, e) => CloseApplication();
            CurrentForm.Show();
        }

        public void OpenNewForm(Form currentForm)
        {
            if (CurrentForm != null)
                CurrentForm.Hide();

            CurrentForm = currentForm;
            CurrentForm.FormClosed += (sender, e) => CloseApplication();

            CurrentForm.Show();
        }

        public void CloseCurrentForm(Form currentForm)
        {
            if (currentForm != null)
            {
                currentForm.FormClosed -= (sender, e) => CloseApplication();
                currentForm.Close();
                currentForm.Dispose();
                currentForm = null;
                CloseApplication();
            }
        }

        public void CloseCurrentForm()
        {
            CloseCurrentForm(CurrentForm);
        }

        private void CloseApplication()
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
                ForceDispose();
            }
        }

        private void ForceDispose()
        {
            GC.Collect();
        }
    }
}
