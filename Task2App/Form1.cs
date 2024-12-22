namespace Task2App {

    public partial class Form1 : Form {

        enum BtnType { Letter, Backspace, ClearAll }

        private static IEnumerable<Button> GenerateKeyboard() {
            for (char letter = 'A'; letter <= 'Z'; letter++) {
                yield return new Button { Text = letter.ToString(), Tag = BtnType.Letter };
            }

            yield return new Button { Text = "BACKSPACE", Tag = BtnType.Backspace };
            yield return new Button { Text = "CLEAR", Tag = BtnType.ClearAll };
        }

        public Form1() {
            InitializeComponent();

            foreach (Button btn in GenerateKeyboard()) {
                btn.Click += LetterBtn_Click;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void LetterBtn_Click(object? sender, EventArgs e) {

            if (sender is Button btn && btn.Tag is BtnType btnType) {

                switch (btnType) {
                    case BtnType.Letter:
                        if (string.IsNullOrEmpty(textBox1.Text)) {
                            textBox1.Text = btn.Text;
                        }
                        else {
                            textBox1.Text += btn.Text;
                        }
                        break;
                    case BtnType.Backspace:
                        if (textBox1.Text.Length > 0)
                            textBox1.Text = textBox1.Text[..^1];
                        break;
                    case BtnType.ClearAll:
                        textBox1.Clear();
                        break;
                }
            }
        }
    }
}
