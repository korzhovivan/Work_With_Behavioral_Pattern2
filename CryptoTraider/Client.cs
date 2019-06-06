using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTraider
{
    public class Client : IObserver
    {
        public double USD { get; set; }
        public double BTC { get; set; }
        public double CourseForSell { get; set; }
        public double SumForSell { get; set; }
        public double CourseForBuy { get; set; }
        public double SumForBuy { get; set; }
        public string Login { get; set; }
        public void Update(IMyObservable observable)
        {
            Stock stock = observable as Stock;
            if (stock.BTCCourse <= this.CourseForBuy)
            {
                if (this.SumForBuy * stock.BTCCourse < this.USD)
                {
                    this.BTC += this.SumForBuy;
                    this.USD -= this.SumForBuy * stock.BTCCourse;
                    this.SumForBuy = 0;
                }
            }
            else
                if (stock.BTCCourse >= this.CourseForSell)
            {
                if (this.BTC > this.CourseForSell)
                {
                    this.USD += this.SumForSell * stock.BTCCourse;
                    this.BTC -= this.SumForSell;
                    this.SumForSell = 0;
                }
            }
        }
        public override string ToString()
        {
            return this.Login;
        }
    }
}
