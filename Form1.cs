namespace RabbitMQSample;

public partial class Form1 : Form
{
    public Form1()
{
    InitializeComponent();

    var formHelper = new FormHelper(this);
    

    // Set form size
    this.Width = 700;
    this.Height = 500;

    // Create a Panel container
    var panel = new Panel();
    panel.Height = 40;
    panel.Dock = DockStyle.Top; // Stick to TOP of the form
    panel.Padding = new Padding(10);
    panel.BackColor = Color.LightGray; // Optional: for visibility

    // Label
    var label = new Label();
    label.Text = "Connection String:";
    label.AutoSize = true;
    label.Location = new Point(0, 10);

    // TextBox
    var textBox = new TextBox();
    textBox.Width = 250;
    textBox.Location = new Point(label.Right + 50, 6);

    // Button
    var button = new Button();
    button.Text = "Connect";
    button.Size = new Size(75,30);
    button.Location = new Point(textBox.Right + 10, 5);
    button.Click += formHelper.ButtonClickHandler;
    // Add controls to the panel
    panel.Controls.Add(label);
    panel.Controls.Add(textBox);
    panel.Controls.Add(button);

    // Add the panel to the form
    this.Controls.Add(panel);

    var buttondocument = new Button();
    buttondocument.Text = "Create Document";
    buttondocument.Location = new Point(200,panel.Bottom+70);
    buttondocument.Size = new Size(200,70);
    buttondocument.Click += formHelper.ButtonDocumentClickHandler;

    this.Controls.Add(buttondocument);

     var textArea = new TextBox();
    textArea.Multiline = true; // Enable multi-line
    textArea.Width = this.ClientSize.Width; // Width of the TextBox
    textArea.Height = 100; // Height for the TextBox (TextArea)
    textArea.Location = new Point(20, this.ClientSize.Height - textArea.Height - 20); // Position it at the bottom
    textArea.ScrollBars = ScrollBars.Vertical; // Optional: vertical scroll

    // Add the TextArea to the form
    this.Controls.Add(textArea);
}

}
