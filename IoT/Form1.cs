using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cardCB.DisplayMember = "email";
            cardCB.ValueMember = "CardId";
            BillsCB.DisplayMember = "DateTime";
            BillsCB.ValueMember = "BillId";
            var response = CallApi.Get("token", "cards").Content.ReadAsStringAsync().Result;
            var des = JsonConvert.DeserializeObject<List<Card>>(response);
            cardCB.DataSource = des;
        }

        private void CardCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedValue != null)
            {
                textBox1.Text = JsonConvert.DeserializeObject<Card>(CallApi.Get("", "cards",
                (sender as ComboBox).SelectedValue.ToString()).Content.ReadAsStringAsync().Result).Balance.ToString();
            BillsCB.DataSource = JsonConvert.DeserializeObject<List<Bill>>(CallApi.Get("", "bills/uncompleted")
                .Content.ReadAsStringAsync().Result).ToList();


                dataGridView1.Rows.Clear();
                foreach (CardWaste waste in JsonConvert.DeserializeObject<List<CardWaste>>(CallApi.Get("", "cardWastes/CardId", (sender as ComboBox).SelectedValue.ToString())
                .Content.ReadAsStringAsync().Result).ToList())
                {
                    dataGridView1.Rows.Add(waste.Waste.Name, waste.Waste.RecyclingPrice, waste.Amount);
                }
            }

        }

        private void BillsCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if((sender as ComboBox).SelectedValue != null)
            {
                billProducts.Rows.Clear();
                foreach (ProductDetails product in JsonConvert.DeserializeObject<BillDetails>(CallApi.Get("", "bills/details", (sender as ComboBox).SelectedValue.ToString())
                .Content.ReadAsStringAsync().Result).ProductDetails.ToList())
                {
                    billProducts.Rows.Add(product.Product.Name, product.Product.BasePrice, product.Amount);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var response = CallApi.Post("", "bills/create/"+ BillsCB.SelectedValue.ToString()+"/"+cardCB.SelectedValue.ToString(),new object() );
        }
    }
}
