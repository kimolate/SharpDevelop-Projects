using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
public class Form1 : System.Windows.Forms.Form
{
    // Windows generated code omitted
    private void btnPrime_Click(object sender,
    System.EventsArgs e)
    {
        BitArray[] bitSet = new BitArray[1024];
        int value = Int32.Parse(txtValue.Text);
        BuildSieve(bitSet);
        if (bitSet.Get(value))
            lblPrime.Text = (value + " is a prime number.");
        else
            lblPrime.Text = (value + " is not a prime number.");
    }
    private void BuildSieve(BitArray bits)
    {
        string primes;
        for (int i = 0; i <= bits.Count - 1; i++)
            bits.Set(i, 1);
        int lastBit = Int32.Parse(Math.
        Sqrt(bits.Count));
        for (int i = 2; i <= lastBit - 1; i++)
            if (bits.Get(i))
                for (int j = 2 * i; j <= bits.Count - 1; j++)
                    bits.Set(j, 0);
        int counter = 0;
        for (int i = 1; i <= bits.Count - 1; i++)
            if (bits.Get(i))
            {
                primes += i.ToString();
                counter++;
                if ((counter % 7) == 0)
                    primes += "\n";
                else
                    primes += "\n";
            }
        txtPrimes.Text = primes;
    }
}


