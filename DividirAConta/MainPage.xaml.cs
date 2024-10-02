namespace DividirAConta;

public partial class MainPage : ContentPage
{
    private decimal conta;
    private int gorjeta;
    private int numeroPessoas = 1;

    public MainPage()
    {
        InitializeComponent();
    }

    private void txtConta_Completed(object sender, EventArgs e)
    {
        conta = decimal.Parse(txtConta.Text);
        CalcularTotal();
    }

    private void CalcularTotal()
    {
        //Total gorjeta
        var totalGorjeta =
             (conta * gorjeta) / 100;

        var gorjetaPorPessoa = (totalGorjeta / numeroPessoas);
        lblGorjetaPessoa.Text = $"{gorjetaPorPessoa} €";

        //Subtotal
        var subtotal = (conta / numeroPessoas);
        lblSubtotal.Text = $"{subtotal} €";

        //Total
        var totalPorPessoa =
             (conta + totalGorjeta) / numeroPessoas;
        lblTotal.Text = $"{totalPorPessoa} €";
    }

    private void sldGorjeta_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        gorjeta = (int)sldGorjeta.Value;
        lblGorjeta.Text = $"Gorjeta: {gorjeta}%";
        CalcularTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percentage =
                 int.Parse(btn.Text.Replace("%", ""));
            sldGorjeta.Value = percentage;
        }
    }

    private void btnMenos_Clicked(object sender, EventArgs e)
    {
        if (numeroPessoas > 1)
        {
            numeroPessoas--;
        }
        lblNoPessoas.Text = numeroPessoas.ToString();
        CalcularTotal();
    }

    private void btnMais_Clicked(object sender, EventArgs e)
    {
        numeroPessoas++;
        lblNoPessoas.Text = numeroPessoas.ToString();
        CalcularTotal();
    }

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        conta = 0.00m;
        gorjeta = 0;
        txtConta.Text = "";
        sldGorjeta.Value = 0;
        lblNoPessoas.Text = "1";
        numeroPessoas = 1;
        CalcularTotal();
    }
}