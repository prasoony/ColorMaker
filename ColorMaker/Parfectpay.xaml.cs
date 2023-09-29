namespace ColorMaker;

public partial class Parfectpay : ContentPage
{
	decimal bill;
	int tip;
	int noperson = 1;


	public Parfectpay()
	{
		InitializeComponent();
	}

    private void txtbill_Completed(object sender, EventArgs e)
    {   
        bill = decimal.Parse(txtbill.Text);
        calculate();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if(sender is Button)
        {
            var btn = (Button)sender;
            var percentage= int.Parse(btn.Text.Replace("%",""));
            slidertip.Value = percentage;
        }
        calculate();
    }

    private void calculate()
    {
        //tip
        var totaltip = (bill * tip) / 100;

        var tipbyperson = (totaltip / noperson);
        lbltipbyperson.Text = $"{tipbyperson:C}";

        var subTotal = (bill / noperson);
        lblsubTotal.Text = $"{subTotal:C}";

        var totalbyperson = (bill + totaltip) / noperson;
        lblTotal.Text = $"{totalbyperson:C}";


    }

    private void btnmin_Clicked(object sender, EventArgs e)
    {
        if(noperson >1)
        {
            noperson--;
        }
        lblnoperson.Text = noperson.ToString();
        calculate();
    }

    private void btnplus_Clicked(object sender, EventArgs e)
    {
        noperson++;
        lblnoperson.Text = noperson.ToString();
        calculate();
    }

    private void slidertip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)slidertip.Value;
        lblTip.Text = $"Tip: {tip}%";
        calculate();

    }
}